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
            other.transform.parent.GetComponent<PlayerAttributes>().TakeDamage(damage);
        }
        else if (LayerInMask(LayerMask.LayerToName(other.gameObject.layer), targetsMask))
        {
            Debug.Log(other.gameObject.layer);
            other.GetComponent<Health>().TakeDamage(damage);
        }

        PlayEffect();
        BulletManager.Destroy4Delay(gameObject);
    }

    bool LayerInMask(string layerName, LayerMask mask)
    {
        bool returnValue = (mask & (1 << LayerMask.NameToLayer(layerName))) != 0;
        return returnValue;
    }
}
