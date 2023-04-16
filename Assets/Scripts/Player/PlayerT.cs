using UnityEngine;

public class PlayerT : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 100f;
    [SerializeField] private float rotationSpeed = 700f;

    private Rigidbody2D rb;
    private Vector2 forwardDirection;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        forwardDirection = transform.up;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rb.MovePosition(rb.position + (moveSpeed * 4) * Time.deltaTime * forwardDirection);
        }

        if (Input.GetKey(KeyCode.A))
        {
            forwardDirection = Quaternion.Euler(0, 0, rotationSpeed * Time.deltaTime) * forwardDirection;
        }

        if (Input.GetKey(KeyCode.D))
        {
            forwardDirection = Quaternion.Euler(0, 0, -rotationSpeed * Time.deltaTime) * forwardDirection;
        }

        if (Input.GetKey(KeyCode.S))
        {
            rb.MovePosition(rb.position - (moveSpeed*2) * Time.deltaTime * forwardDirection);
        }
    }

    private void FixedUpdate()
    {
        // Calculate the angle between the current facing direction and the movement direction
        float angle = Mathf.Atan2(forwardDirection.y, forwardDirection.x) * Mathf.Rad2Deg - 90f;
        Quaternion targetRotation = Quaternion.Euler(0f, 0f, angle);

        // Rotate the player towards the movement direction
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.fixedDeltaTime);
    }
}