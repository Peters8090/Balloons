using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torus : MonoBehaviour
{
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // Rotating
        DetectTouchMovement.Calculate();
        rb.angularVelocity = DetectTouchMovement.turnAngleDelta * Vector3.forward;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(!collision.collider.gameObject.name.Contains("Balloon"))
        {
            print(collision.gameObject.name);
        }
    }
}
