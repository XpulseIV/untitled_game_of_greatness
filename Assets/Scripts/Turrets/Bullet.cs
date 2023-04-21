using UnityEngine;

namespace Turrets
{
    public sealed class Bullet : MonoBehaviour
    {
        public float speed; // Speed of the bullet
        public float lifetime; // Time until the bullet is destroyed

        private Vector3 direction; // Direction in which the bullet is moving

        void Start()
        {
            // Set the initial direction of the bullet based on its rotation
            direction = transform.up;

            // Destroy the bullet after its lifetime expires
            Destroy(gameObject, lifetime);
        }

        void Update()
        {
            // Move the bullet in its direction at a constant speed
            transform.position += direction * speed * Time.deltaTime;
        }
    }
}
