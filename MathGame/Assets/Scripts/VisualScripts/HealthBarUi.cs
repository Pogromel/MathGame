using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarUi : MonoBehaviour
{
    [SerializeField] private Image _healthBarForeground;

    public void UpdateHealth(float healthPercentage)
    {
        _healthBarForeground.fillAmount = healthPercentage;
    }
}