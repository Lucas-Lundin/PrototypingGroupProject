using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttributes : MonoBehaviour
{
    private int amountStars;

    private float currentHealth;
    [SerializeField] private float maxHealth;
    [SerializeField] private Slider slider;


    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        slider.value = currentHealth;
        // on hurt visual effects go here
        if (currentHealth <= 0)
        {
            gameObject.GetComponent<MeshRenderer>().material.color = Color.green;
        }
    }

    public void GetStars(int amount)
    {
        amountStars += amount;
    }

    public void HealDamage(float amount)
    {
        currentHealth += amount;
        slider.value = currentHealth;
        slider.value = Mathf.Clamp(currentHealth, 0, maxHealth);
        // on heal visual effects go here
    }
}
