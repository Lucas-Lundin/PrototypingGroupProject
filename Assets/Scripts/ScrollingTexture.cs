using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingTexture : MonoBehaviour
{
    [SerializeField] private float scrollSpeedX;
    [SerializeField] private float scrollSpeedY;
    void Update()
    {
        float offsetX = scrollSpeedX * Time.deltaTime;
        float offsetY = scrollSpeedX * Time.deltaTime;
        GetComponent<Renderer>().material.mainTextureOffset = new Vector2(offsetX, offsetY);
    }
}
