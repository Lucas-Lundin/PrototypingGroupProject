using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    private float charge;
    [SerializeField] private float maxCharge;
    [SerializeField] private float chargeRate;
    [SerializeField] private float dischargeRate;
    [SerializeField] private float fireCost;

    [SerializeField] private GameObject muzzle;
    [SerializeField] private GameObject gun;
    [SerializeField] private GameObject bulletPrefab;

    private bool isCharging;

    void Start()
    {
        charge = maxCharge;
    }
    
    void Update()
    {
        // handle charging and decharging
        if (isCharging)
        {
            charge += chargeRate * Time.deltaTime;
        }
        else
        {
            charge += dischargeRate * Time.deltaTime;
        }
    }

    public virtual void Shoot()
    {
        if (charge >= fireCost)
        {
            charge -= fireCost;
            Instantiate(bulletPrefab, muzzle.transform.position, muzzle.transform.rotation);
        }
    }

    public void SetEnabled(bool state)
    {
        gun.SetActive(state);
    }
}
