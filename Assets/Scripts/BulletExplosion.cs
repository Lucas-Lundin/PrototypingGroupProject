using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletExplosion : MonoBehaviour
{
    [SerializeField] private GameObject particleEffect;
    [SerializeField] private float speed;

    private Rigidbody rigid;

    void OnEnable()
    {
        rigid = GetComponent<Rigidbody>();
        rigid.AddForce(transform.forward * speed);
    }

    void PlayEffect(float cleanDelay = 2)
    {
        var splash = Instantiate(particleEffect, transform.position, transform.rotation);
        StartCoroutine(CleanWDelay(cleanDelay, splash));
    }

    IEnumerator CleanWDelay(float seconds, GameObject gObject)
    {
        yield return new WaitForSeconds(seconds);
        Destroy(gObject);
    }

    void OnCollisionEnter(Collision other)
    {
        PlayEffect();
        Destroy(gameObject); // refine later, don't let bullets destroy themselves
    }
}
