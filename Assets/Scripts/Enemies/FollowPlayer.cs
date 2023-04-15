//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class FollowPlayer : MonoBehaviour
//{
//    public EnemyStats enemyStats;
//    private Rigidbody2D rgb;
//    private GameObject _playerObject;

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
//        rgb.velocity = transform.up * enemyStats.moveSpeed;
//    }

//}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private EnemyStats _enemyStats;
    private Rigidbody2D rgb;
    private GameObject _playerObject;
    //private GameObject _areaEffectorObject;

    void Start()
    {
        _playerObject = GameObject.FindGameObjectWithTag("Player");
        //_areaEffectorObject = GameObject.FindGameObjectWithTag("ConveyourBelt");
        rgb = GetComponent<Rigidbody2D>();
        _enemyStats = GetComponent<EnemyStats>();
    }

    void Update()
    {
        Vector2 targetDirection = _playerObject.transform.position - transform.position;
        float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg - 90f;
        Quaternion q = Quaternion.Euler(new Vector3(0, 0, angle));
        transform.localRotation = Quaternion.Slerp(transform.localRotation, q, _enemyStats.rotateSpeed * Time.deltaTime);

        //     Vector2 forceDirection = (Vector2)_areaEffectorObject.transform.position - (Vector2)transform.position;
        // Get the AreaEffector2D component from the areaEffectorObject
        //     AreaEffector2D areaEffector = _areaEffectorObject.GetComponent<AreaEffector2D>();

        // Set the force angle and magnitude of the AreaEffector2D component
        //areaEffector.forceAngle = 0;
        //areaEffector.forceMagnitude = forceDirection.magnitude * _enemyStats.moveSpeed * 100;

        rgb.velocity = transform.up * _enemyStats.moveSpeed;
    }
}



