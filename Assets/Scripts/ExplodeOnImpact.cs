using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeOnImpact : MonoBehaviour
{
    [SerializeField] private GameObject particleEffect;
    [SerializeField] private float damage;
    [SerializeField] private LayerMask targetsMask;

    void PlayEffect(float cleanDelay = 2)
    {
        if (particleEffect != null)
        {
            var splash = Instantiate(particleEffect, transform.position, transform.rotation);
            Destroy(splash, cleanDelay);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player" && LayerInMask("OnlyPlayer", targetsMask))
        {
            PlayEffect();
            EnemyManager.EnemyDies(gameObject);
            other.gameObject.GetComponent<PlayerAttributes>().TakeDamage(damage);
        }
        else if (LayerInMask(LayerMask.LayerToName(other.gameObject.layer), targetsMask))
        {
            other.gameObject.GetComponent<Health>().TakeDamage(damage);
            PlayEffect();
            EnemyManager.EnemyDies(gameObject);
        }
    }

    bool LayerInMask(string layerName, LayerMask mask)
    {
        bool returnValue = (mask & (1 << LayerMask.NameToLayer(layerName))) != 0;
        return returnValue;
    }
}
