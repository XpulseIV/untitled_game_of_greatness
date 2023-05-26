using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Building : MonoBehaviour
{
    public GameObject building1Prefab; // Prefab of building 1
    public GameObject building2Prefab; // Prefab of building 2
    public GameObject building3Prefab; // Prefab of building 3
    public GameObject building4Prefab; // Prefab of building 4
    public Material ghost;

    public GameObject ghostBuilding; // Ghost building object
    public int selectedBuilding; // Selected building index (1, 2, 3, or 4)
    public int prevSelectedBuilding; // Selected building index (1, 2, 3, or 4)
    private bool m_isPlacing;
    private enum PressedKey { None, One, Two, Three, Four }

    void Update()
    {
        if (Input.anyKeyDown)
        {
            if (IsNumberKeyPressed(out PressedKey pressed))
            {
                if (!m_isPlacing)
                {
                    selectedBuilding = (int)pressed;
                    prevSelectedBuilding = selectedBuilding;
                    m_isPlacing = true;
                }
                else
                {
                    selectedBuilding = (int)pressed;
                }

                Destroy(ghostBuilding);
                PlaceGhostBuilding(); // Place ghost
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (PlaceBuilding())
                {
                    Destroy(ghostBuilding);
                    m_isPlacing = false;
                }
            }

            if (Input.GetKeyDown(KeyCode.Escape) && (ghostBuilding != null))
            {
                Destroy(ghostBuilding);
                m_isPlacing = false;
            }
        }

        if (m_isPlacing)
        {
            UpdateGhostPos();
        }
    }

    bool IsNumberKeyPressed(out PressedKey pressed)
    {
        pressed = PressedKey.None;
        KeyCode[] numberKeys = { KeyCode.Alpha1, KeyCode.Alpha2, KeyCode.Alpha3, KeyCode.Alpha4 };

        foreach (KeyCode key in numberKeys)
        {
            if (Input.GetKeyDown(key))
            {
                pressed = GetPressedKeyFromKeyCode(key);

                return true;
            }
        }

        return false;
    }

    PressedKey GetPressedKeyFromKeyCode(KeyCode key)
    {
        return key switch
        {
            KeyCode.Alpha1 => PressedKey.One,
            KeyCode.Alpha2 => PressedKey.Two,
            KeyCode.Alpha3 => PressedKey.Three,
            KeyCode.Alpha4 => PressedKey.Four,
            var _ => throw new ArgumentOutOfRangeException()
        };
    }


    private void UpdateGhostPos()
    {
        Vector3 playerRot = transform.rotation.eulerAngles;

        Quaternion newRotQuat = Quaternion.Euler
        (
            playerRot.x,
            playerRot.y,
            playerRot.z
        );

        ghostBuilding.transform.position = transform.position + (Vector3)(Vector2.up.Rotate(transform.rotation.eulerAngles.z)) * 2.5f;
        ghostBuilding.transform.rotation = newRotQuat;
    }

    private bool PlaceBuilding()
    {
        var colliders = new List<Collider2D>();
        ghostBuilding.GetComponent<BoxCollider2D>().OverlapCollider
            (new ContactFilter2D().NoFilter(), colliders);

        if (colliders.Count != 0)
        {
            return false;
        }

        Money moneySript = GetComponent<Money>();

        switch (selectedBuilding)
        {
        case 1:
            if (moneySript.playerMoney < 30) return false;

            Instantiate(building1Prefab, ghostBuilding.transform.position, ghostBuilding.transform.rotation);
            moneySript.playerMoney -= 30;

            break;
        case 2:
            if (moneySript.playerMoney < 150) return false;

            Instantiate(building2Prefab, ghostBuilding.transform.position, ghostBuilding.transform.rotation);
            moneySript.playerMoney -= 150;

            break;
        case 3:
            if (moneySript.playerMoney < 65) return false;

            Instantiate(building3Prefab, ghostBuilding.transform.position, ghostBuilding.transform.rotation);
            moneySript.playerMoney -= 65;

            break;

        case 4:
            if (moneySript.playerMoney < 45) return false;

            Instantiate(building4Prefab, ghostBuilding.transform.position, ghostBuilding.transform.rotation);
            moneySript.playerMoney -= 45;

            break;
        }

        return true;
    }

    private void PlaceGhostBuilding()
    {
        Vector3 playerRot = transform.rotation.eulerAngles;

        Quaternion newRotQuat = Quaternion.Euler
        (
            playerRot.x,
            playerRot.y,
            playerRot.z
        );

        Vector3 newPos = transform.position + (Vector3)(Vector2.up.Rotate(transform.rotation.eulerAngles.z)) * 2.5f;

        ghostBuilding = selectedBuilding switch
        {
            1 => Instantiate(building1Prefab, newPos, newRotQuat),
            2 => Instantiate(building2Prefab, newPos, newRotQuat),
            3 => Instantiate(building3Prefab, newPos, newRotQuat),
            4 => Instantiate(building4Prefab, newPos, newRotQuat),
            var _ => throw new ArgumentOutOfRangeException()
        };

        switch (selectedBuilding)
        {
        case 2:
            SpriteRenderer[] turretSpriteRenderers = ghostBuilding.GetComponentsInChildren<SpriteRenderer>();
            for (int i = 0; i < turretSpriteRenderers.Length; i++) turretSpriteRenderers[i].material = ghost;

            break;
        default:
            ghostBuilding.GetComponent<SpriteRenderer>().material = ghost;

            break;
        }
    }
}
