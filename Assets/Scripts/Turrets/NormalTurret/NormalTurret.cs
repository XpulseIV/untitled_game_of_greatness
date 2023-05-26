using System;
using UnityEngine;

public class NormalTurret : MonoBehaviour
{
    public Vector3 mousePos;
    private DateTime timeShot;
    public Animator animsYazz;
    public GameObject Bullet;
    public Transform CannonPoint;
    private ActivateSelf _activateSelf;

    public int shootSpeed;
    public int health;

    private void Start()
    {
        _activateSelf = GetComponentInParent<ActivateSelf>();
    }

    void Update()
    {

        if (_activateSelf.isActivated)
        {
            animsYazz.SetBool("IsActive", true);

            // Get the current position of the mouse cursor
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0f;

            // Calculate the direction to rotate the object
            Vector3 direction = mousePos - transform.position;
            direction.Normalize();

            // Calculate the angle to rotate the object
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;

            // Apply the rotation to the object
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            if (Input.GetKey(KeyCode.Space) && ((DateTime.Now - timeShot).TotalMilliseconds > shootSpeed))
            {
                timeShot = DateTime.Now;
                animsYazz.Play("TurretShoot");

                Instantiate(Bullet, CannonPoint.position, transform.rotation);
            }

            return;
        }

        animsYazz.SetBool("IsActive", false);
    }
}