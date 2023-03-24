using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOverTime : MonoBehaviour
{
    public EnemyStats enemyStats;
    //public float enemyHealth;
    private bool _hasTakenDamage;
    public GameObject traps;
    private TrapStats trapStats;

    // Start is called before the first frame update
    void Start()
    {
        trapStats = traps.GetComponent<TrapStats>();
        enemyStats = GetComponent<EnemyStats>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Traps")
        {
            if (!_hasTakenDamage)
            {
                enemyStats.enemyHealth -= trapStats.damageOverTime;
                _hasTakenDamage = true;
                Invoke("HasTakenDamage", trapStats.damageTickSpeed);
            }

            if (enemyStats.enemyHealth <= 0)
            {
                Destroy(gameObject, 0);
            }
        }
    }
    private void HasTakenDamage()
    {
        _hasTakenDamage = false;
    }
}
