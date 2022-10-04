using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletExplosion : MonoBehaviour
{
    [SerializeField] private GameObject particleEffect;
    [SerializeField] private float speed;
    [SerializeField] private float damage;

    private Rigidbody rigid;

    void OnEnable()
    {
        rigid = GetComponent<Rigidbody>();
        rigid.AddForce(transform.forward * speed);
    }

    void PlayEffect(float cleanDelay = 2)
    {
        var splash = Instantiate(particleEffect, transform.position, transform.rotation);
        Destroy(splash, cleanDelay);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "Destructible")
        {
            other.GetComponent<Health>().TakeDamage(damage);
        }

        if (other.gameObject.layer != gameObject.layer)
        {
            PlayEffect();
            BulletManager.Destroy4Delay(gameObject);
        }
    }

}
