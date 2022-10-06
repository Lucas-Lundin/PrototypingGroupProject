using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagedChangeColor : MonoBehaviour
{
    [SerializeField] private Material damagedMaterial;



    public void ChangeColor()
    {
        transform.GetChild(0).GetComponent<Renderer>().material = damagedMaterial;
    }
}
