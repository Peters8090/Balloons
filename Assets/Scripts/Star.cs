using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : BoomObject
{
    protected override float boomForce { get => 0.1f; }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.tag == "Balloon")
            StartCoroutine(Die());
    }
}
