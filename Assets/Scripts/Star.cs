using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : BoomObject
{
    protected override float boomForce { get { return 0.03f; } }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.tag == "Balloon")
            StartCoroutine(Die());
    }
}
