using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform playerTransform;
    public float moveSpeed = 3f;
    public float rotateSpeed = 0.0025f;
    private Rigidbody2D rgb;
    private GameObject _playerObject;
    
    // Start is called before the first frame update
    void Start()
    {
        _playerObject = GameObject.FindGameObjectWithTag("Player");
        rgb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 targetDirection = _playerObject.transform.position - transform.position;
        float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg - 90f;
        Quaternion q = Quaternion.Euler(new Vector3(0, 0, angle));
        transform.localRotation = Quaternion.Slerp(transform.localRotation, q, rotateSpeed * Time.deltaTime);
        rgb.velocity = transform.up * moveSpeed;
    }

}
