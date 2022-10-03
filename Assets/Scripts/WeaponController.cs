using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{


    public GameObject muzzle;
    public GameObject gun;
    public GameObject bulletPrefab;
    

    public virtual void Shoot()
    {
        Instantiate(bulletPrefab, muzzle.transform.position, muzzle.transform.rotation);
    }

    public void SetEnabled(bool state)
    {
        gun.SetActive(state);
    }
}
