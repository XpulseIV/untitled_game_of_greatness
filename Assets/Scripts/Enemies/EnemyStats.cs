using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public float enemyHealth;
    public float moveSpeed;
    public float rotateSpeed;
    public float scaling;
    private GameObject _nightBox;
    private DayNight _dayNight;

    // Start is called before the first frame update
    void Start()
    {
        _nightBox = GameObject.Find("Night");
        _dayNight = _nightBox.GetComponent<DayNight>();

        enemyHealth = (float)(enemyHealth * Math.Pow(scaling, _dayNight.numbersOfDays));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
