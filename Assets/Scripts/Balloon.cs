using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Balloon : MonoBehaviour
{
    Rigidbody rb;
    float floatingForce = 1f;

    float dyingTime = 0.2f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        rb.AddForce(Vector3.up * floatingForce);
        //transform.DOMoveY(transform.position.y + floatingForce, floatingForce);
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.gameObject.transform.name == "Trap")
        {
            transform.DOPunchScale(Vector3.one * 0.7f, dyingTime);
            Invoke("Die", dyingTime);
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
