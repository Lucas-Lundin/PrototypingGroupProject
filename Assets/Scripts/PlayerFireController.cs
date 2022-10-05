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
    private int selectedWeapon = 0;



    [HideInInspector]
    public bool isInputEnabled;


    void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
        lineRendererRifle.enabled = true;
        lineRendererShotgun.enabled = false;
    }

    private void Update()
    {
        
    }

    void OnFire(InputValue value)
    {
        weapon[selectedWeapon].Shoot();
    }

    void OnSwapWeapon(InputValue value)
    {
        SwapWeapon();
    }


    void SwapWeapon()
    {
        if (selectedWeapon >= (weapon.Length -1)) // If you have the last weapon selected, switch to the first one in the array.
        {
            selectedWeapon = 0;
            lineRendererRifle.enabled = true;
            lineRendererShotgun.enabled = false;
        }
        else
        {
            selectedWeapon += 1;
            lineRendererRifle.enabled = false;
            lineRendererShotgun.enabled = true;
        }     
    }

    public int GetSelectedWeapon()
    {
        return selectedWeapon;
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
