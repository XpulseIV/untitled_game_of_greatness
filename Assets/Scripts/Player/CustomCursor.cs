using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomCursor : MonoBehaviour
{
    [SerializeField] public Sprite normalCursor;
    [SerializeField] public Sprite utilityCursor;

    [SerializeField] public bool inUtility;

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
        if (Input.GetKey(KeyCode.E)) // check if left mouse button is pressed down
        {
            if (collision.gameObject.tag == "Traps")
            {
                Debug.Log("Collided with trap");
                collision.gameObject.tag = "ActivatedTrap";

            }
            else if (collision.gameObject.tag == "ConveyourBelt")
            {
                // do something for conveyour belts
            }
            else if (collision.gameObject.tag == "Turrets")
            {
                // do something for turrets
            }
        }
    }

}
