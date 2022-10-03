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
    private float timeSinceFired;

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
        // Counts the time since last fired a shot.
        timeSinceFired += 1 * Time.deltaTime;

    }

    public virtual void Shoot()
    {
        if (charge >= fireCost && timeSinceFired >= 0.1)
        {
            timeSinceFired = 0;
            charge -= fireCost;
            Instantiate(bulletPrefab, muzzle.transform.position, muzzle.transform.rotation);
        }
    }

    public void SetEnabled(bool state)
    {
        gun.SetActive(state);
    }
}
