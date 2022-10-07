using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorController : MonoBehaviour
{
    [SerializeField] private float warmupTime;
    [SerializeField] private float travelTime;
    [SerializeField] private float ascentDistance;
    [SerializeField] private string state;
    [SerializeField] private LayerMask targetsMask;
    [SerializeField] private float panicResetTime;

    private float timeOfLastSwap;
    private float timeOnElevator;
    private Rigidbody rigid;
    private Vector3 origin;
    private string currentState;

    private void Start()
    {
        rigid = GetComponent<Rigidbody>();
        origin = rigid.position;
        timeOnElevator = 0;
        timeOfLastSwap = -1;
        currentState = state;
    }

    private void Update()
    {
        if (currentState == "rising")
        {
            timeOnElevator += Time.deltaTime;
            var targetY = Mathf.Lerp(origin.y, origin.y + ascentDistance, timeOnElevator / travelTime);
            rigid.MovePosition(new Vector3(rigid.position.x, targetY, rigid.position.z));

            if (timeOnElevator >= travelTime)
            {
                currentState = "up";
                timeOnElevator = 0;
                timeOfLastSwap = Time.time;
            }
        }
        else if (currentState == "falling")
        {
            timeOnElevator += Time.deltaTime;
            var targetY = Mathf.Lerp(origin.y, origin.y + ascentDistance, (1 - timeOnElevator / travelTime));
            rigid.MovePosition(new Vector3(rigid.position.x, targetY, rigid.position.z));

            if (timeOnElevator >= travelTime)
            {
                currentState = "down";
                timeOnElevator = 0;
                timeOfLastSwap = Time.time;
            }
        }

        //To prevent levels being locked by elevators
        if (timeOfLastSwap > 0 && Time.time - timeOfLastSwap >= panicResetTime)
        {
            if (currentState == "up")
            {
                currentState = "falling";
                timeOnElevator = 0;
                timeOfLastSwap = Time.time;
            }

            if (currentState == "down")
            {
                currentState = "rising";
                timeOnElevator = 0;
                timeOfLastSwap = Time.time;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {

        if (LayerInMask(LayerMask.LayerToName(other.gameObject.layer), targetsMask))
        {
            timeOnElevator += Time.deltaTime;

            if (timeOnElevator >= warmupTime && currentState == "down")
            {
                currentState = "rising";
                timeOnElevator = 0;
                timeOfLastSwap = Time.time;
            }
            else if (timeOnElevator >= warmupTime && currentState == "up")
            {
                currentState = "falling";
                timeOnElevator = 0;
                timeOfLastSwap = Time.time;
            }
        }
            
    }

    private void OnTriggerEnter(Collider other)
    {
        if (LayerInMask(LayerMask.LayerToName(other.gameObject.layer), targetsMask))
        {
            timeOnElevator = 0;
            other.gameObject.transform.parent = gameObject.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (LayerInMask(LayerMask.LayerToName(other.gameObject.layer), targetsMask))
        {
            timeOnElevator = 0;
            other.gameObject.transform.parent = null;
        }
    }


    bool LayerInMask(string layerName, LayerMask mask)
    {
        bool returnValue = (mask & (1 << LayerMask.NameToLayer(layerName))) != 0;
        return returnValue;
    }

    public string GetState()
    {
        return currentState;
    }
}
