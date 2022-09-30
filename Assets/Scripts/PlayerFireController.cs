using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerFireController : MonoBehaviour
{

    private CharacterController controller;
    [SerializeField] private WeaponController weapon;


    [HideInInspector]
    public bool isInputEnabled;


    void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
    }

    void OnFire(InputValue value)
    {
        weapon.Shoot();
    }
}
