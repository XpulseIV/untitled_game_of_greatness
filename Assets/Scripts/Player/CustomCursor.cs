using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomCursor : MonoBehaviour
{
    public GameObject trap;  // Reference to the trap object
    public SpriteRenderer spriteRenderer;  // Reference to the sprite renderer component
    public Sprite normalCursorSprite;  // Reference to the normal cursor sprite
    public Sprite trapCursorSprite;  // Reference to the trap cursor sprite

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

        // Check if the left mouse button is clicked
        if (Input.GetMouseButtonDown(0))
        {
            // Check if the mouse is over the trap
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);
            Debug.Log("Hit object: " + hit.collider.gameObject.name);
            if (hit.collider != null && hit.collider.gameObject == trap)
            {
                // Toggle the trap activation state
                trap.GetComponent<ActivateSelf>().isActivated = !trap.GetComponent<ActivateSelf>().isActivated;

                // Show/hide the trap cursor sprite
                if (trap.GetComponent<ActivateSelf>().isActivated)
                {
                    spriteRenderer.sprite = trapCursorSprite;
                }
                else
                {
                    spriteRenderer.sprite = normalCursorSprite;
                }
            }
        }
    }
}
