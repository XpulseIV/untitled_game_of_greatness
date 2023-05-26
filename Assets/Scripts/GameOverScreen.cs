using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScreen : MonoBehaviour
{
    public GameObject tPlayer;
    private PlayerHealth _playerHealth;
    private SpriteRenderer _spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        _playerHealth = tPlayer.GetComponent<PlayerHealth>();
        _spriteRenderer = GetComponent<SpriteRenderer>();

        _spriteRenderer.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(_playerHealth.health <= 0)
        {
            _spriteRenderer.enabled = true;
        }
    }
}
