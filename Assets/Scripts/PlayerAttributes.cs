using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttributes : MonoBehaviour
{
    private int amountKeys;

    private float currentHealth;
    [SerializeField] private float maxHealth;
    [SerializeField] private Slider slider;
    public Slider keyAmount; 

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        // on hurt visual effects go here
        if (currentHealth <= 0)
        {
            transform.GetChild(0).GetComponent<MeshRenderer>().material.color = Color.green;
        }
        slider.value = Mathf.Clamp(currentHealth, 0, maxHealth) / maxHealth;
    }

    public void AddKeys(int amount)
    {
        amountKeys += amount;
        keyAmount.value = amountKeys;
    }

    public void HealDamage(float amount)
    {
        currentHealth += amount;
        slider.value = Mathf.Clamp(currentHealth, 0, maxHealth) / maxHealth;
        // on heal visual effects go here
    }
}
