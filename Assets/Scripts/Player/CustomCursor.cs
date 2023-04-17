using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomCursor : MonoBehaviour
{
    public Sprite normalCursor;
    public Sprite utilityCursor;

    public bool inUtility;

    void Start()
    {
        Cursor.visible = false;
    }

    private void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;

        transform.position = mousePos;
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKey(KeyCode.E) && !inUtility) // check if left mouse button is pressed down
        {
            if (collision.gameObject.tag == "Traps")
            {
                Debug.Log("Collided with trap");
                collision.gameObject.tag = "ActivatedTrap";
                Invoke("UtilityYes", 0.1f);
            }
            else if (collision.gameObject.tag == "ConveyourBelt")
            {
                Debug.Log("Collided with ConveyourBelt");
                collision.gameObject.tag = "ActivatedConveyourBelt";
                Invoke("UtilityYes", 0.1f);
            }
            else if (collision.gameObject.tag == "Turrets")
            {
                Debug.Log("Collided with Turrets");
                collision.gameObject.tag = "ActivatedTurrets";
                Invoke("UtilityYes", 0.1f);
            }
        }
    }

    public void UtilityYes()
    {
        inUtility = true;
    }

}
