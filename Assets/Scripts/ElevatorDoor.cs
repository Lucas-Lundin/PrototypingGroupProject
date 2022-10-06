using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorDoor : MonoBehaviour
{
    [SerializeField] private ElevatorController elevator;
    [SerializeField] private List<string> blockedStates;
    private Collider collie;

    private void Start()
    {
        collie = GetComponent<Collider>();
    }

    private void Update()
    {
        if (blockedStates.Contains(elevator.GetState()))
        {
            Debug.Log("Blocked");
            collie.enabled = false;
        }
        else
        {
            collie.enabled = true;
        }
    }
}
