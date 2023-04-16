using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNight : MonoBehaviour
{
    [SerializeField] private Renderer _nightBox;
    [SerializeField] private float _alpha;
    public float timeSpeed;
    //private float _timeChange = 0;
    private bool _isGettingNight = true;
    private GameObject _enemySpawnController;
    public float numbersOfDays;

    // Start is called before the first frame update
    void Start()
    {
        _enemySpawnController = GameObject.Find("EnemySpawnController");
    }

    // Update is called once per frame
    void Update()
    {
        Color _color = _nightBox.material.color;
        _color.a = _alpha;
        _nightBox.material.color = _color;

        if (_isGettingNight)
        {
            _alpha += timeSpeed * Time.deltaTime;
        }
        else
        {
            _alpha -= timeSpeed * Time.deltaTime;
        }

        if(_alpha > 0.8f)
        {
            _isGettingNight = false;
        }
        if(_alpha < 0)
        {
            _isGettingNight = true;
        }

        if(_alpha > 0.5)
        {
            _enemySpawnController.SetActive(true);
        }
        else
        {
            if (_enemySpawnController.active == true)
            {
                numbersOfDays++;
            }
            _enemySpawnController.SetActive(false);
        }
    }
}
