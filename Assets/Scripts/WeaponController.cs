using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public GameObject muzzle;
    public GameObject gun;
    public GameObject bulletPrefab;
    private float bulletLifeSpan = 1;


    public virtual void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, muzzle.transform.position, muzzle.transform.rotation);
        BulletManager.Destroy4Delay(bullet, bulletLifeSpan);
    }

    public void SetEnabled(bool state)
    {
        gun.SetActive(state);
    }
}
