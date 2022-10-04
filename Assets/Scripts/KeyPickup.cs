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
        if (other.gameObject.tag == "Player")
        {
            other.GetComponent<PlayerAttributes>().AddStars(1);

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
