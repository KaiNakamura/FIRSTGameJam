using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    public Slider slider;
    public Text display;

    public void SetHealth(int health)
    {
        slider.value = health;
        display.text = health.ToString();
    }
}
