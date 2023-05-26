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

    public GameObject ghost1Prefab; // Prefab of ghost 1
    public GameObject ghost2Prefab; // Prefab of ghost 2
    public GameObject ghost3Prefab; // Prefab of ghost 3
    public GameObject ghost4Prefab; // Prefab of ghost 4

    public Material ghost;

    public GameObject ghostBuilding; // Ghost building object
    public int selectedBuilding; // Selected building index (1, 2, 3, or 4)
    public int prevSelectedBuilding; // Selected building index (1, 2, 3, or 4)
    private enum PressedKey { None, One, Two, Three, Four }

    public bool drawMoney = true;

    public void Start()
    {
        prevSelectedBuilding = -2;
        selectedBuilding = -1;
    }

    void Update()
    {
        if (Input.anyKeyDown)
        {
            if (IsNumberKeyPressed(out PressedKey pressed))
            {
                selectedBuilding = (int)pressed;

                if ((ghostBuilding == null))
                {
                    PlaceGhostBuilding();
                }

                if ((ghostBuilding != null) && (selectedBuilding == prevSelectedBuilding)) return;

                if ((ghostBuilding != null) && (selectedBuilding != prevSelectedBuilding))
                {
                    Destroy(ghostBuilding);
                    PlaceGhostBuilding();
                }

                prevSelectedBuilding = selectedBuilding;
                selectedBuilding = -1;
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (PlaceBuilding())
                {
                    Destroy(ghostBuilding);
                }
            }

            if (Input.GetKeyDown(KeyCode.Escape) && (ghostBuilding != null))
            {
                Destroy(ghostBuilding);
            }
        }

        if (ghostBuilding != null)
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
            1 => Instantiate(ghost1Prefab, newPos, newRotQuat),
            2 => Instantiate(ghost2Prefab, newPos, newRotQuat),
            3 => Instantiate(ghost3Prefab, newPos, newRotQuat),
            4 => Instantiate(ghost4Prefab, newPos, newRotQuat),
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

    private bool CanAfford()
    {
        int playerMoney = GetComponent<Money>().playerMoney;

        return selectedBuilding switch
        {
            1 => playerMoney >= 30,
            2 => playerMoney >= 150,
            3 => playerMoney >= 65,
            4 => playerMoney >= 45,
            _ => false
        };
    }

    private bool PlaceBuilding()
    {
        var colliders = new List<Collider2D>();
        ghostBuilding.GetComponent<BoxCollider2D>().OverlapCollider
            (new ContactFilter2D().NoFilter(), colliders);

        if (colliders.Count != 0) return false;

        Money moneySript = GetComponent<Money>();

        switch (selectedBuilding)
        {
        case 1:
            if (CanAfford() && drawMoney) moneySript.playerMoney -= 30;
            else if (!drawMoney)
            {
                goto hmmm;
            }
            else return false;

        hmmm:
            Instantiate(building1Prefab, ghostBuilding.transform.position, ghostBuilding.transform.rotation);

            break;
        case 2:
            if (CanAfford() && drawMoney) moneySript.playerMoney -= 150;
            else return false;

            Instantiate(building2Prefab, ghostBuilding.transform.position, ghostBuilding.transform.rotation);

            break;
        case 3:
            if (CanAfford() && drawMoney) moneySript.playerMoney -= 65;
            else return false;

            Instantiate(building3Prefab, ghostBuilding.transform.position, ghostBuilding.transform.rotation);

            break;

        case 4:
            if (CanAfford() && drawMoney) moneySript.playerMoney -= 45;
            else return false;

            Instantiate(building4Prefab, ghostBuilding.transform.position, ghostBuilding.transform.rotation);

            break;
        }

        return true;
    }
}
