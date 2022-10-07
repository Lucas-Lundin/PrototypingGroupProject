using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerFireController : MonoBehaviour
{

    private CharacterController controller;
    //[SerializeField] private WeaponController weapon;
    [SerializeField] private WeaponController[] weapon;
    [SerializeField] private LineRenderer lineRendererRifle;
    [SerializeField] private LineRenderer lineRendererShotgun;


    [HideInInspector]
    public bool isInputEnabled;


    void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
        lineRendererRifle.enabled = true;
        lineRendererShotgun.enabled = true;
    }

    private void Update()
    {
        
    }

    void OnFire(InputValue value)
    {
        GetRifle().Shoot();
    }

    void OnSwapWeapon(InputValue value)
    {
        GetShotgun().Shoot();
    }


    public int GetChargingWeapon()
    {
        if(GetRifle().GetIsCharging())
        {
            return 0;
        }else
        {
            return 1;
        }
    }

    public WeaponController GetRifle()
    {
        return weapon[0];
    }

    public WeaponController GetShotgun()
    {
        return weapon[1];
    }

}
