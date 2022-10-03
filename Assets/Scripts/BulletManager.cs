using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    public static BulletManager Instance;

    private void Awake()
    {
        Instance = this;
    }



    public static void Destroy4Delay(GameObject obj, float lifeSpan = 0)
    {
            Destroy(obj, lifeSpan); 
    }





}
