using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyDisplay : MonoBehaviour
{
    public Text money;

    public void SetMoney(int money)
    {
        this.money.text = "MONEY: " + money.ToString();
    }
}
