using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
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
    [SerializeField] private float vollySpreadAngle; 
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
        // Discharge while moving
        if (movementController.IsMoving())  
        {
            isCharging = false;
            charge -= dischargeRate * Time.deltaTime;
        }
        // Charge while standing still
        else
        {
            isCharging = true;
            charge += chargeRate * Time.deltaTime;
           
        }
        charge = Mathf.Clamp(charge, minCharge, maxCharge);

        // Time since last fired a shot.
        timeSinceFired += 1 * Time.deltaTime;
        
    }

    public override void Shoot()
    {
        if (charge >= fireCost && timeSinceFired >= fireRate)
        {
            timeSinceFired = 0;
            charge -= fireCost;



            // Spawns the volly of bulllets:
            float rotationBetweenBullets = vollySpreadAngle / (vollyBullletAmount -1); // Amount of rotation offset between each bullet.
            for (int i = 0; i < vollyBullletAmount; i++)
            {
                //Quaternion rotationOffset = Quaternion.Euler(0f, Random.Range(-vollySpreadAngle / 2, vollySpreadAngle / 2), 0f); //Random distrubition within the spread angle
                
                Quaternion rotationOffset = Quaternion.Euler(0f, (-vollySpreadAngle / 2) + (rotationBetweenBullets * i), 0f);

                GameObject bullet = Instantiate(bulletPrefab, muzzle.transform.position, muzzle.transform.rotation * rotationOffset);
                BulletManager.Destroy4Delay(bullet, bulletLifeSpan);

            }
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

    public float GetVollySpreadAngle()
    {
        return vollySpreadAngle;
    }

    public override bool GetIsCharging() 
    {
        return isCharging;
    }
}
