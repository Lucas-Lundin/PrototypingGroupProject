using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RifleController : WeaponController
{
    [SerializeField] private float charge;
    [SerializeField] private float maxCharge;
    
    [SerializeField] private float chargeRate;
    [SerializeField] private float dischargeRate;
    [SerializeField] private float fireCost;
    [SerializeField] private float fireRate;
    [SerializeField] private PlayerMovementController movementController;
    //[SerializeField] private float bulletLifeSpan;
    private float timeSinceFired;
    private const float minCharge = 0;
    private bool isCharging = false;


    void Start()
    {
        charge = minCharge;  
    }

    void Update()
    {
        // Charge while moving
        if (movementController.IsMoving())
        {
            isCharging = true;
            charge += chargeRate * Time.deltaTime;
        }
        // Discharge while standing still
        else
        {
            isCharging = false;
            charge -= dischargeRate * Time.deltaTime;
        }
        charge = Mathf.Clamp(charge, minCharge, maxCharge);

        // Time since last fired a shot
        timeSinceFired += 1 * Time.deltaTime;
    }



    public override void Shoot()
    {
        if (charge >= fireCost && timeSinceFired >= fireRate)
        {
            timeSinceFired = 0;
            charge -= fireCost;
            GameObject bullet = Instantiate(bulletPrefab, muzzle.transform.position, muzzle.transform.rotation);
            BulletManager.Destroy4Delay(bullet, bulletLifeSpan);
        }
    }

    public override float GetMaxCharge()
    {
        return maxCharge;
    }

    public override float GetCharge()
    {
        return charge;
    }

    public override bool GetIsCharging()
    {
        return isCharging;
    }
}
