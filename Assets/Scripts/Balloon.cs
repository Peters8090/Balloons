using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Balloon : BoomObject
{
    protected override float boomForce { get => 0.3f; }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject == UsefulReferences.instance.trap)
            StartCoroutine(Die());
    }
}
