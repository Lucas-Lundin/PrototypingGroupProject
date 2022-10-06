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

    private float timeOnElevator;
    private Rigidbody rigid;
    private Vector3 origin;
    private GameObject passenger;

    private void Start()
    {
        rigid = GetComponent<Rigidbody>();
        origin = rigid.position;
        timeOnElevator = 0;
    }

    private void Update()
    {
        if (state == "rising")
        {
            timeOnElevator += Time.deltaTime;
            Debug.Log(state);
            var targetY = Mathf.Lerp(origin.y, origin.y + ascentDistance, timeOnElevator / travelTime);
            rigid.MovePosition(new Vector3(rigid.position.x, targetY, rigid.position.z));

            if (timeOnElevator >= travelTime)
            {
                state = "up";
                timeOnElevator = 0;
                Debug.Log(state);
            }
        }
        else if (state == "falling")
        {
            timeOnElevator += Time.deltaTime;
            Debug.Log(state);
            var targetY = Mathf.Lerp(origin.y, origin.y + ascentDistance, (1 - timeOnElevator / travelTime));
            rigid.MovePosition(new Vector3(rigid.position.x, targetY, rigid.position.z));

            if (timeOnElevator >= travelTime)
            {
                state = "down";
                timeOnElevator = 0;
                Debug.Log(state);
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {

        if (LayerInMask(LayerMask.LayerToName(other.gameObject.layer), targetsMask))
        {
            timeOnElevator += Time.deltaTime;
            Debug.Log(other);

            if (timeOnElevator >= warmupTime && state == "down")
            {
                state = "rising";
                timeOnElevator = 0;
            }
            else if (timeOnElevator >= warmupTime && state == "up")
            {
                state = "falling";
                timeOnElevator = 0;
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
        return state;
    }
}
