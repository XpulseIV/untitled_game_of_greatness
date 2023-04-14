using System;
using UnityEditor.Animations;
using UnityEngine;

public class NormalTurret : MonoBehaviour
{
    private Vector3 mousePos;
    public bool isActive;

    private DateTime timeShot;

    public Animator animsYazz;

    void Update()
    {
        if (this.isActive)
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

            var timeNow = DateTime.Now();
            
            if (Input.GetKey(KeyCode.Space) && (DateTime.Now() - timeShot) > 2500)
            {
                timeShot = DateTime.Now();
                this.animsYazz.Play("TurretShoot");
            }

            return;
        }

        animsYazz.SetBool("IsActive", false);
    }
}