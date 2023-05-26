using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class HitByNormalBullet : MonoBehaviour
{
    private EnemyStats _enemyStats;
    public float normalBulletDamage;
    // Start is called before the first frame update
    void Start()
    {
        _enemyStats = GetComponent<EnemyStats>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            _enemyStats.enemyHealth -= normalBulletDamage;
        }
        if (_enemyStats.enemyHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
