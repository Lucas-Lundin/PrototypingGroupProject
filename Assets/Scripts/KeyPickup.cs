using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickup : MonoBehaviour
{
    [SerializeField] private GameObject particleEffect;
    [SerializeField] private float spinSpeed;

    void Update()
    {
        transform.rotation *= Quaternion.Euler(0, spinSpeed, 0);
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other);
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerAttributes>().AddKeys(1);

            if (particleEffect != null)
            {
                PlayEffect();
            }

            gameObject.SetActive(false);
        }
    }

    void PlayEffect(float cleanDelay = 2)
    {
        var splash = Instantiate(particleEffect, transform.position, transform.rotation);
        Destroy(splash, cleanDelay);
    }
}
