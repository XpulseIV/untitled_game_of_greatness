using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurstDamage : MonoBehaviour
{
    public EnemyStats enemyStats;
    //public float enemyHealth;
    private bool _hasTakenDamage;
    public GameObject traps;
    private TrapStats _trapStats;
    private ActivateSelf _activateSelf;

    // Start is called before the first frame update
    void Start()
    {
        _trapStats = traps.GetComponent<TrapStats>();
        enemyStats = GetComponent<EnemyStats>();
        _activateSelf = GetComponent<ActivateSelf>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (_activateSelf.isActivated && Input.GetKey("space"))
        {
            if (collision.gameObject.tag == "Traps")
            {
                if (!_hasTakenDamage)
                {
                    enemyStats.enemyHealth -= _trapStats.burstDamage;
                    _hasTakenDamage = true;
                    Invoke("HasTakenDamage", _trapStats.burstSpeed);
                }

                if (enemyStats.enemyHealth <= 0)
                {
                    Destroy(gameObject, 0);
                }
            }
        }
    }
    private void HasTakenDamage()
    {
        _hasTakenDamage = false;
    }
}
