using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTrigger : MonoBehaviour
{
    [SerializeField] private Spawner[] spawners;
    [SerializeField] private bool repeatable;
    private bool active;

    private void Start()
    {
        active = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && active)
        {
            foreach (Spawner spawnPoint in spawners)
            {
                EnemyManager.SpawnByObject(spawnPoint);
            }
            if (!repeatable)
            {
                active = false;
            }
        }
    }
}
