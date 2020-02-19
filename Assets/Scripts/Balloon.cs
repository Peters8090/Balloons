using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Balloon : MonoBehaviour
{
    ParticleSystem particles;

    bool dying;

    void Start()
    {
        particles = GetComponentInChildren<ParticleSystem>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.transform.name == "Trap")
            StartCoroutine(Die());
        else if (collision.collider.gameObject.transform.name.Contains("Star"))
            StartCoroutine(Die());
    }

    IEnumerator Die()
    {
        if(!dying)
        {
            dying = true;

            transform.DOPunchScale(Vector3.one * 0.2f, particles.main.duration);
            particles.Play();

            yield return new WaitForSeconds(particles.main.duration);

            Handheld.Vibrate();
            Destroy(gameObject);
        }
    }
}
