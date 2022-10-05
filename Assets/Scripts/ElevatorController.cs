using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorController : MonoBehaviour
{
    [SerializeField] private float warmupTime;
    [SerializeField] private float travelTime;
    [SerializeField] private float ascentDistance;
    [SerializeField] private string state;
    private float timeOnElevator;
    private Rigidbody rigid;
    private Vector3 origin;

    private void Start()
    {
        rigid = GetComponent<Rigidbody>();
        origin = rigid.position;
    }


    private void OnTriggerStay(Collider other)
    {
        timeOnElevator += Time.deltaTime;
        if (timeOnElevator >= warmupTime)
        {
            timeOnElevator = 0;
            var targetY = Mathf.Lerp(origin.y, origin.y + ascentDistance, timeOnElevator/travelTime);
            rigid.MovePosition(origin + new Vector3(0, targetY, 0));
        }
    }
}
