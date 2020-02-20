using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BoomObject : MonoBehaviour
{
    ParticleSystem particles;

    protected virtual float boomForce { get { return 1f; } }

    bool dying;

    void Start()
    {
        particles = GetComponentInChildren<ParticleSystem>();
    }

    protected IEnumerator Die()
    {
        if (!dying)
        {
            dying = true;

            transform.DOPunchScale(Vector3.one * boomForce, particles.main.duration);
            particles.Play();

            yield return new WaitForSeconds(particles.main.duration);

            Handheld.Vibrate();
            Destroy(gameObject);
        }
    }
}
