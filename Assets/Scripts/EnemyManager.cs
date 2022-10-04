using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    private static EnemyManager instance; 
    [SerializeField] private Spawner[] enemySpawns;


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        EnemyManager.SpawnAll();
    }

    public static EnemyManager GetInstance()
    {
        return instance;
    }

    public static void EnemyDies(GameObject enemy)
    {
        Destroy(enemy);
    }

    public static void SpawnAll()
    {
        foreach (Spawner spawner in GetInstance().enemySpawns)
        {
            spawner.Spawn();
        }
    }
}

