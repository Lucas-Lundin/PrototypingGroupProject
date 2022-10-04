using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletExplosion : MonoBehaviour
{
    [SerializeField] private GameObject particleEffect;
    [SerializeField] private float speed;
    [SerializeField] private float damage;
    [SerializeField] private LayerMask targetsMask;

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
        if (other.gameObject.tag == "Player" && LayerInMask("OnlyPlayer", targetsMask))
        {
            Debug.Log("Hit player");
            other.GetComponent<PlayerAttributes>().TakeDamage(damage);
        }
        else if (LayerInMask(LayerMask.LayerToName(other.gameObject.layer), targetsMask))
        {
            other.GetComponent<Health>().TakeDamage(damage);
        }

        PlayEffect();
        BulletManager.Destroy4Delay(gameObject);
    }

    bool LayerInMask(string layerName, LayerMask mask)
    {
        Debug.Log("Comparing" + layerName);
        bool returnValue = (mask & (1 << LayerMask.NameToLayer(layerName))) != 0;
        Debug.Log(returnValue);
        return returnValue;
    }
}
