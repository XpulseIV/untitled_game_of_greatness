//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class BurstDamage : MonoBehaviour
//{
//    public EnemyStats enemyStats;
//    //public float enemyHealth;
//    private bool _hasTakenDamage;
//    public GameObject traps;
//    private TrapStats _trapStats;
//    private ActivateSelf _activateSelf;

//    // Start is called before the first frame update
//    void Start()
//    {
//        _trapStats = traps.GetComponent<TrapStats>();
//        enemyStats = GetComponent<EnemyStats>();
//        _activateSelf = GetComponent<ActivateSelf>();
//    }

//    // Update is called once per frame
//    void Update()
//    {

//    }

//    private void OnTriggerStay2D(Collider2D collision)
//    {
//        if (_activateSelf.isActivated && Input.GetKey("space"))
//        {
//            if (collision.gameObject.tag == "Enemy")
//            {
//                if (!_hasTakenDamage)
//                {
//                    enemyStats.enemyHealth -= _trapStats.burstDamage;
//                    _hasTakenDamage = true;
//                    Invoke("HasTakenDamage", _trapStats.burstSpeed);
//                }

//                if (enemyStats.enemyHealth <= 0)
//                {
//                    Destroy(gameObject, 0);
//                }
//            }
//        }
//    }
//    private void HasTakenDamage()
//    {
//        _hasTakenDamage = false;
//    }
//}

using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;
using UnityEngine.UIElements;

public class BurstDamage : MonoBehaviour
{
    private TrapStats _trapStats;
    private ActivateSelf _activateSelf;

    //public float burstDamage = 10f;
    //public float burstSpeed = 0.5f;

    private bool _hasActivated;

    void Start()
    {
        _trapStats = GetComponent<TrapStats>();
        _activateSelf = GetComponent<ActivateSelf>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("OnTriggerEnter2D");

        if (_activateSelf.isActivated && Input.GetKey("space"))
        {
            Debug.Log("Trap activated");

            if (collision.gameObject.CompareTag("Enemy") && !_hasActivated)
            {
                Debug.Log("Enemy hit by trap");

                _hasActivated = true;

                var enemyStats = collision.gameObject.GetComponent<EnemyStats>();
                if (enemyStats != null)
                {
                    enemyStats.enemyHealth -= _trapStats.burstDamage;

                    if (enemyStats.enemyHealth <= 0)
                    {
                        Destroy(collision.gameObject);
                    }
                    else
                    {
                        Invoke("ResetActivation", _trapStats.burstSpeed);
                    }
                }
            }
        }
        
        
    }

    private void ResetActivation()
    {
        Debug.Log("ResetActivation");

        _hasActivated = false;
    }
}







