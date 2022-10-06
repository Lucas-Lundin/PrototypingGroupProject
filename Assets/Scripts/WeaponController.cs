using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public GameObject muzzle;
    public GameObject gun;
    public GameObject bulletPrefab;
    public float bulletLifeSpan = 10;


    public virtual void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, muzzle.transform.position, muzzle.transform.rotation);
        BulletManager.Destroy4Delay(bullet, bulletLifeSpan);
    }

    public void SetEnabled(bool state)
    {
        gun.SetActive(state);
    }

    public virtual float GetMaxCharge()
    {
        return 0f;
    }

    public virtual float GetCharge()
    {
        return 0f;
    }
    public virtual bool GetIsCharging()
    {
        return false;
    }


}
