using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunController : WeaponController
{
    [SerializeField] private float charge;
    [SerializeField] private float maxCharge;
    
    [SerializeField] private float chargeRate;
    [SerializeField] private float dischargeRate;
    [SerializeField] private float fireCost;
    [SerializeField] private float fireRate;
    [SerializeField] private int vollyBullletAmount;
    [SerializeField] private float vollySpreadDeg; 
    [SerializeField] private PlayerMovementController movementController;
    [SerializeField] private float bulletLifeSpan;
    private float timeSinceFired;
    private const float minCharge = 0;


    void Start()
    {
        charge = maxCharge;
    }

    void Update()
    {
        // Discharge while moving
        if (movementController.IsMoving())  
        {
            charge -= dischargeRate * Time.deltaTime;
        }
        // Charge while moving
        else
        {
            charge += chargeRate * Time.deltaTime;
           
        }
        Mathf.Clamp(charge, minCharge, maxCharge);

        // Time since last fired a shot.
        timeSinceFired += 1 * Time.deltaTime;
        
    }

    public override void Shoot()
    {
        if (charge >= fireCost && timeSinceFired >= fireRate)
        {
            timeSinceFired = 0;
            charge -= fireCost;

            // Spawn volly of bulllets:
            for (int i = 0; i < vollyBullletAmount; i++)
            {
                Quaternion rotationOffset = Quaternion.Euler(0f, Random.Range(-vollySpreadDeg / 2, vollySpreadDeg / 2), 0f);
                GameObject bullet = Instantiate(bulletPrefab, muzzle.transform.position, muzzle.transform.rotation * rotationOffset);
                BulletManager.Destroy4Delay(bullet, bulletLifeSpan);

            }
        }
    }


}
