using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ConveyorBelt : MonoBehaviour
{
    public float speed = 1f;
    public Vector2 direction = Vector2.right;

    void FixedUpdate()
    {
        Collider2D[] colliders = Physics2D.OverlapBoxAll(transform.position, transform.localScale / 2f, 0);

        foreach (Collider2D collider in colliders)
        {
            if (collider.gameObject.CompareTag("ConveyorBeltObject"))
            {
                collider.transform.position += (Vector3)direction * speed * Time.deltaTime;
            }
        }
    }
}