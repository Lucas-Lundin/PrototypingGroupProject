using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTrigger : MonoBehaviour
{
    [SerializeField] private Spawner[] spawners;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            foreach (Spawner spawnPoint in spawners)
            {
                EnemyManager.SpawnByObject(spawnPoint);
            }
        }
    }
}
