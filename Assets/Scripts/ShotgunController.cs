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
    [SerializeField] private PlayerMovementController movementController;
    private float timeSinceFired;
    private const float minCharge = 0;


    void Start()
    {
        charge = maxCharge;
    }

    void Update()
    {
        // handle charging and decharging
        if (movementController.IsMoving())
        {
            charge += chargeRate * Time.deltaTime;
        }
        else
        {
            charge -= dischargeRate * Time.deltaTime;
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
            //Instantiate(bulletPrefab, muzzle.transform.position, muzzle.transform.rotation);
            Instantiate(bulletPrefab, muzzle.transform.position + new Vector3(Random.Range(-1,1), Random.Range(-1, 1), Random.Range(-1, 1)), muzzle.transform.rotation);
            Instantiate(bulletPrefab, muzzle.transform.position + new Vector3(Random.Range(-1, 1), Random.Range(-1, 1), Random.Range(-1, 1)), muzzle.transform.rotation);
            Instantiate(bulletPrefab, muzzle.transform.position + new Vector3(Random.Range(-1, 1), Random.Range(-1, 1), Random.Range(-1, 1)), muzzle.transform.rotation);
        }
    }


}