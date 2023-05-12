using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallHealth : MonoBehaviour
{
    public float wallMaxHealth;
    private float _currentWallHealth;
    private bool _hasTakenDamage;
    public Sprite[] wallSprites;
    private SpriteRenderer _spriteRenderer;
    
    
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();

        _hasTakenDamage = false;
        _currentWallHealth = wallMaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(_currentWallHealth < (wallMaxHealth / 3))
        {
            _spriteRenderer.sprite = wallSprites[2];
        }
        else if(_currentWallHealth < (wallMaxHealth * 0.66f))
        {
            _spriteRenderer.sprite = wallSprites[1];
        }
        else
        {
            _spriteRenderer.sprite = wallSprites[0];
        }
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
                _currentWallHealth--;
                _hasTakenDamage = true;
                Invoke("HasTakenDamage", 1f);
            }

            if (_currentWallHealth <= 0)
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
