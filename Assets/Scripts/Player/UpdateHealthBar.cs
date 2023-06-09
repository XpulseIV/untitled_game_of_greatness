using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateHealthBar : MonoBehaviour
{

    private Slider _healthSlider;
    // Start is called before the first frame update
    void Start()
    {
        _healthSlider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetMaxHealth(float maxHealth)
    {
        _healthSlider.maxValue = maxHealth;
        _healthSlider.value = maxHealth;
    }

    public void SetHealth(float health)
    {
        _healthSlider.value = health;
    }
}
