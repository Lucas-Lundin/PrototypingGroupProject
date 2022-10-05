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

    private void Start()
    {
        rigid = GetComponent<Rigidbody>();
        origin = rigid.position;
        timeOnElevator = 0;
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
                Debug.Log(state);
            }
            else if (timeOnElevator >= warmupTime && state == "up")
            {
                state = "falling";
                timeOnElevator = 0;
                Debug.Log(state);
            }
            else if (state == "rising")
            {
                var targetY = Mathf.Lerp(origin.y, origin.y + ascentDistance, timeOnElevator / travelTime);
                rigid.MovePosition(new Vector3(rigid.position.x, targetY, rigid.position.z));
                other.gameObject.transform.parent.parent = transform;

                if (timeOnElevator >= travelTime)
                {
                    state = "up";
                    timeOnElevator = 0;
                    other.gameObject.transform.parent.parent = null;
                    Debug.Log(state);
                }
            }
            else if (state == "falling")
            {
                var targetY = Mathf.Lerp(origin.y, origin.y + ascentDistance, (1 - timeOnElevator / travelTime));
                rigid.MovePosition(new Vector3(rigid.position.x, targetY, rigid.position.z));
                other.gameObject.transform.parent.parent = transform;

                if (timeOnElevator >= travelTime)
                {
                    state = "down";
                    timeOnElevator = 0;
                    other.gameObject.transform.parent.parent = null;
                    Debug.Log(state);
                }
            }
        }
            
            
    }

    private void OnTriggerExit(Collider other)
    {
        if (LayerInMask(LayerMask.LayerToName(other.gameObject.layer), targetsMask))
        {
            timeOnElevator = 0;
            other.gameObject.transform.parent.parent = null;
        }
    }


    bool LayerInMask(string layerName, LayerMask mask)
    {
        bool returnValue = (mask & (1 << LayerMask.NameToLayer(layerName))) != 0;
        return returnValue;
    }
}
