using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour
{
    Rigidbody rb;
    float floatingForce = 0.5f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        rb.AddForce(Vector3.up * floatingForce);
    }

    //void LateUpdate()
    //{
    //    transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y, transform.localEulerAngles.z);
    //}

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Trap")
        {
            rb.AddExplosionForce(1f, transform.position, 1f);
        }
    }
}
