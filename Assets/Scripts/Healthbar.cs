using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    [SerializeField] private Image healthbar;
    public void updatehealthbar(float maxHealth, float currentHealth)
    {
        healthbar.fillAmount = currentHealth / maxHealth;
    }
}
