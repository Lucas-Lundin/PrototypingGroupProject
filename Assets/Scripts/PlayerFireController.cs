using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerFireController : MonoBehaviour
{
    [SerializeField] private GameObject muzzle;
    [SerializeField] private GameObject bulletPrefab;

    private CharacterController controller;

    [HideInInspector]
    public bool isInputEnabled;


    void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
    }

    void Fire(InputAction.CallbackContext context)
    {
        Debug.Log("Fire!");
        Instantiate(bulletPrefab, muzzle.transform.position, muzzle.transform.rotation);
    }
}
