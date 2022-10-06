using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    [SerializeField] private Material damagedMaterial;
    private float currentHealth;


    void Start()
    {
        currentHealth = maxHealth;
    }

    
    void Update()
    {
        
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        /*
        if (GetComponents<DamagedChangeColor>().Length != 0)
        {
            GetComponents<DamagedChangeColor>().ChangeColor();
        }
        */
        if (damagedMaterial != null)
        {
            transform.GetChild(0).GetComponent<Renderer>().material = damagedMaterial;
        }

            if (currentHealth <= 0)
        {
            EnemyManager.EnemyDies(gameObject);
        }
    }
}
