using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float health;
    [SerializeField] private GameObject _canvasHP;
    private UpdateHealthBar _updateHealthBar;


    // Start is called before the first frame update
    void Start()
    {
        _updateHealthBar = _canvasHP.GetComponent<UpdateHealthBar>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") == true)
        {
            health--;
            //_updateHealthBar.SetHealth(health);
        }
    }
}
