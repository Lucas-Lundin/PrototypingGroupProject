using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField] private int maxKeys;
    [SerializeField] private Slider keySlider;

    private void Start()
    {
        //Unholy crimes against encapsulation and separation of layers
        keySlider.maxValue = maxKeys;
    }

    private void OnTriggerEnter(Collider other)
    {
        var gO = other.gameObject;
        if (gO.layer == LayerMask.NameToLayer("OnlyPlayer") && gO.GetComponent<PlayerAttributes>().GetKeys() == maxKeys)
        {
            LevelManager.LoadNext();
        }
    }

}
