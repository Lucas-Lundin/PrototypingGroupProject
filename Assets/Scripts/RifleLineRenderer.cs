using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RifleLineRenderer : MonoBehaviour
{
    private LineRenderer lineRenderer;
    [SerializeField] private GameObject[] points;

    void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>(); 
        lineRenderer.positionCount = points.Length;
    }


    void Update()
    {
     for(int i = 0; i < points.Length; i++)
        {
            lineRenderer.SetPosition(i, points[i].transform.position);
        }
    }
}
