using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;

    public void UpdateHealthBar(float maxHealth, float currentHealth)
    {
        _slider.value = currentHealth / maxHealth;
    }
}
