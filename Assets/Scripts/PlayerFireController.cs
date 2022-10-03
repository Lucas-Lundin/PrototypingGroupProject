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
    private int selectedWeapon = 0;

    [HideInInspector]
    public bool isInputEnabled;


    void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
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
        SwitchWeapon();
    }


    void SwitchWeapon()
    {
        if (selectedWeapon >= (weapon.Length -1)) // If you have the last weapon selected, switch to the first one in the array.
        {
            selectedWeapon = 0;
        }
        else
        {
            selectedWeapon += 1;

        }     
    }
}
