using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float health;
    [SerializeField] private UpdateHealthBar _updateHealthBar;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if(collision.gameObject.CompareTag("Enemy") == true)
        //{
        //    health--;
        //    _updateHealthBar.SetHealth(health);
        //}
    }
}
