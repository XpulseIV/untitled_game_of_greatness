using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomCursor : MonoBehaviour
{
    public GameObject trap;  // Reference to the trap object
    public SpriteRenderer spriteRenderer;  // Reference to the sprite renderer component
    public Sprite normalCursorSprite;  // Reference to the normal cursor sprite
    public Sprite trapCursorSprite;  // Reference to the trap cursor sprite
    public string normalTag = "Traps"; // Normal tag for the trap object
    public string activeTag = "ActivatedTrap"; // Active tag for the trap object
    public GameObject[] traps; // Array of all trap objects with the same tag

    private bool isInTrap = false; // Flag to indicate if the cursor is inside the trap

    void Start()
    {
        Cursor.visible = false;
        spriteRenderer.sprite = normalCursorSprite;
    }

    private void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;

        transform.position = mousePos;

        if (!isInTrap)
        {
            // Check if the left mouse button is clicked
            if (Input.GetMouseButtonDown(0))
            {
                // Check if the mouse is over a trap
                Collider2D[] hits = Physics2D.OverlapCircleAll(mousePos, 0.1f);
                foreach (Collider2D hit in hits)
                {
                    if (hit.gameObject.CompareTag(normalTag))
                    {
                        ActivateTrap(hit.gameObject);
                    }
                }
            }
        }
        else
        {
            // Check if the right mouse button is clicked
            if (Input.GetMouseButtonDown(1))
            {
                DeactivateTrap(trap);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == trap)
        {
            isInTrap = true;
            spriteRenderer.sprite = trapCursorSprite;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == trap)
        {
            isInTrap = false;
            spriteRenderer.sprite = normalCursorSprite;
        }
    }

    private void ActivateTrap(GameObject trapToActivate)
    {
        // Toggle the trap activation state
        trapToActivate.GetComponent<ActivateSelf>().isActivated = true;

        // Change the tag of the trap and all the traps with the same tag
        string tagToActivate = activeTag;
        trapToActivate.tag = tagToActivate;
        foreach (GameObject t in traps)
        {
            if (t != trapToActivate && t.tag == normalTag && Vector2.Distance(t.transform.position, trapToActivate.transform.position) <= 2f)
            {
                t.tag = tagToActivate;
                t.GetComponent<ActivateSelf>().isActivated = true;
            }
        }

        // Show the trap cursor sprite
        spriteRenderer.sprite = trapCursorSprite;
    }


    private void DeactivateTrap(GameObject trapToDeactivate)
    {
        // Toggle the trap activation state
        trapToDeactivate.GetComponent<ActivateSelf>().isActivated = false;

        // Change the tag of the trap and all the traps with the same tag
        trapToDeactivate.tag = normalTag;
        foreach (GameObject t in traps)
        {
            if (t != trapToDeactivate && t.tag == activeTag && Vector2.Distance(t.transform.position, trapToDeactivate.transform.position) <= 2f)
            {
                t.tag = normalTag;
                t.GetComponent<ActivateSelf>().isActivated = false;
            }
        }

        // Hide the trap cursor sprite
        spriteRenderer.sprite = normalCursorSprite;
        isInTrap = false;
    }
}
