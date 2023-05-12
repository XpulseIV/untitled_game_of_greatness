//using System;
//using System.Collections;
//using System.Collections.Generic;
//using Unity.VisualScripting;
//using UnityEngine;
//using static UnityEngine.EventSystems.EventTrigger;
//using UnityEngine.UIElements;

//public class BurstDamage : MonoBehaviour
//{
//    private TrapStats _trapStats;
//    private ActivateSelf _activateSelf;

//    //public float burstDamage = 10f;
//    //public float burstSpeed = 0.5f;

//    private bool _hasActivated;

//    void Start()
//    {
//        _trapStats = GetComponent<TrapStats>();
//        _activateSelf = GetComponent<ActivateSelf>();
//    }

//    private void OnTriggerStay2D(Collider2D collision)
//    {


//        if (_activateSelf.isActivated && Input.GetKey("space"))
//        {


//            if (collision.gameObject.CompareTag("Enemy") && !_hasActivated)
//            {


//                _hasActivated = true;

//                var enemyStats = collision.gameObject.GetComponent<EnemyStats>();
//                if (enemyStats != null)
//                {
//                    enemyStats.enemyHealth -= _trapStats.burstDamage;

//                    if (enemyStats.enemyHealth <= 0)
//                    {
//                        Destroy(collision.gameObject);
//                    }

//                    Invoke("ResetActivation", _trapStats.burstSpeed);
//                }
//            }
//        }


//    }

//    private void ResetActivation()
//    {
//        _hasActivated = false;
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
    private EnemyStats _enemyStats;
    //private ActivateSelf _activateSelf;

    //public float burstDamage = 10f;
    //public float burstSpeed = 0.5f;

    private bool _hasActivated;

    void Start()
    {
        _enemyStats = GetComponent<EnemyStats>();

        _hasActivated = false;
        //_activateSelf = GetComponent<ActivateSelf>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        
        if(collision.gameObject.GetComponent<TrapStats>() != null)
        {
            var _trapStats = collision.gameObject.GetComponent<TrapStats>();
            var _activateSelf = collision.gameObject.GetComponent<ActivateSelf>();

            if (_activateSelf.isActivated && Input.GetKey("space") && collision.gameObject.CompareTag("ActivatedTrap") && !_hasActivated)
            {


                Debug.Log("Should take damage");

                _hasActivated = true;

                _enemyStats.enemyHealth -= _trapStats.burstDamage;

                if (_enemyStats.enemyHealth <= 0)
                {
                    Destroy(gameObject, 0);
                }

                Invoke("ResetActivation", _trapStats.burstSpeed);
            }
        }
        


    }

    private void ResetActivation()
    {
        _hasActivated = false;
    }
}







