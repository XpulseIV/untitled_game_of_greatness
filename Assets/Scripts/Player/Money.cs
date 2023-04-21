using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Money : MonoBehaviour
{
    public TMP_Text coinDispaly;
    public int playerMoney;

    bool makeMoney = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (makeMoney)
        {
            Invoke("MoneyMak", 2f);
            makeMoney = false;
        }
       

        coinDispaly.text = Convert.ToString(playerMoney);
    }

    private void MoneyMak()
    {
        playerMoney += 5;
        makeMoney = true;
    }
}
