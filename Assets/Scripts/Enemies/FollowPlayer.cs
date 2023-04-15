using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public EnemyStats enemyStats;
    private Rigidbody2D rgb;
    private GameObject _playerObject;

    void Start()
    {
        _playerObject = GameObject.FindGameObjectWithTag("Player");
        rgb = GetComponent<Rigidbody2D>();
        enemyStats = GetComponent<EnemyStats>();
    }

    void Update()
    {
        Vector2 targetDirection = _playerObject.transform.position - transform.position;
        float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg - 90f;
        Quaternion q = Quaternion.Euler(new Vector3(0, 0, angle));
        transform.localRotation = Quaternion.Slerp(transform.localRotation, q, enemyStats.rotateSpeed * Time.deltaTime);
        rgb.velocity = transform.up * enemyStats.moveSpeed;
    }

}
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class FollowPlayer : MonoBehaviour
//{
//    public EnemyStats enemyStats;
//    private Rigidbody2D rgb;
//    private GameObject _playerObject;
//    private AreaEffector2D areaEffector; // new field for the Area Effector 2D component
//    private bool isWithinRange = false; // flag to check if the enemy is within range of the Area Effector 2D

//    void Start()
//    {
//        _playerObject = GameObject.FindGameObjectWithTag("Player");
//        rgb = GetComponent<Rigidbody2D>();
//        enemyStats = GetComponent<EnemyStats>();
//    }

//    void Update()
//    {
//        Vector2 targetDirection = _playerObject.transform.position - transform.position;
//        float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg - 90f;
//        Quaternion q = Quaternion.Euler(new Vector3(0, 0, angle));
//        transform.localRotation = Quaternion.Slerp(transform.localRotation, q, enemyStats.rotateSpeed * Time.deltaTime);

//        if (isWithinRange) // check if the enemy is within range of the Area Effector 2D
//        {
//            // calculate the force vector to be applied to the enemy by the Area Effector 2D component
//            Vector2 forceDirection = areaEffector.transform.position - transform.position;
//            Vector2 force = forceDirection.normalized * areaEffector.forceMagnitude;
//            rgb.AddForce(force); // apply the force to the enemy's rigidbody
//        }
//        else // otherwise, find the Area Effector 2D component in the scene
//        {
//            areaEffector = FindObjectOfType<AreaEffector2D>();
//            if (areaEffector != null) // check if an Area Effector 2D component was found
//            {
//                isWithinRange = true; // set the flag to true
//            }
//        }
//    }
//}