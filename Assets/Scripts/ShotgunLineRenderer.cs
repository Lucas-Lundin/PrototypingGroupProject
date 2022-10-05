using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunLineRenderer : MonoBehaviour
{
    [SerializeField] private GameObject shotgun;
    [SerializeField] private GameObject[] points;
    private LineRenderer lineRenderer;
    private float spreadAngle;

    void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = points.Length;
        
        /*
        // Get shotgun spread angle:
        spreadAngle = shotgun.GetComponent<ShotgunController>().GetVollySpreadAngle();
        
        // Update the empty gameobjects(points) position:
        points[0].transform.Rotate(0, (-spreadAngle / 2), 0, Space.Self);
        points[2].transform.Rotate(0, (spreadAngle / 2), 0, Space.Self);

        points[0].transform.position = points[0].transform.forward * 2;
        points[2].transform.position = points[2].transform.forward * 2;
        */

    }


    void Update()
    {
        

        

        // Update the point position for the line renderer.
        for (int i = 0; i < points.Length; i++)
        {
            lineRenderer.SetPosition(i, points[i].transform.position);
        }
    }
}
