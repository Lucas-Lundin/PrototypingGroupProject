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
        if (Input.GetKeyDown(KeyCode.T))
        {
            SwitchWeapon();
        }
    }

    void OnFire(InputValue value)
    {
        weapon[selectedWeapon].Shoot();
    }
    
    void SwitchWeapon()
    {
        if (selectedWeapon == 0)
        {
            selectedWeapon = 1;
        }
        else
        {
            selectedWeapon = 0;
        }
    }
}
