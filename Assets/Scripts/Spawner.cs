using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private float floorY;
    private Bounds box;

    void Start()
    {
        box = GetComponent<BoxCollider>().bounds;
        transform.GetChild(0).gameObject.SetActive(false);
    }

    public void Spawn()
    {
        var position = transform.position;
        position.y = floorY;
        Instantiate(prefab, transform.position, transform.rotation);
    }

    public void SpawnRandom()
    {
        var position = new Vector3(Random.Range(box.min.x, box.max.x), floorY, Random.Range(box.min.z, box.max.z));
        Instantiate(prefab, position, Quaternion.identity);
    }
}
