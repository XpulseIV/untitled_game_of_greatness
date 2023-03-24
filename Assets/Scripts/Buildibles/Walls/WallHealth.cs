using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallHealth : MonoBehaviour
{
    public float wallHealth;
    private bool _hasTakenDamage;
    
    // Start is called before the first frame update
    void Start()
    {
        _hasTakenDamage = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.tag == "Enemy")
    //    {
    //        if (!_hasTakenDamage)
    //        {
    //            wallHealth--;
    //            _hasTakenDamage = true;
    //            Invoke("HasTakenDamage", 1f);
    //        }

    //        if (wallHealth <= 0)
    //        {
    //            Destroy(gameObject, 0);
    //        }
    //    }
    //}


    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if (!_hasTakenDamage)
            {
                wallHealth--;
                _hasTakenDamage = true;
                Invoke("HasTakenDamage", 1f);
            }

            if (wallHealth <= 0)
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
