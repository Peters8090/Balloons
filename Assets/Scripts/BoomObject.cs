using System.Collections;
using UnityEngine;
using DG.Tweening;

public class BoomObject : MonoBehaviour
{
    [SerializeField]
    GameObject particlesPrefab;

    protected virtual float boomForce { get => 1f; }

    float deathDelay = 0.3f;
    bool dying;
    
    protected IEnumerator Die()
    {
        // To prevent twice particle animation executions etc.
        if (dying)
            yield break;

        dying = true;
        transform.DOPunchScale(Vector3.one * boomForce, deathDelay);
        GameObject particles = Instantiate(particlesPrefab, transform.position, Quaternion.identity);
        particles.GetComponent<ParticleSystem>().Play();

        yield return new WaitForSeconds(deathDelay);

        LastWords();

        Destroy(gameObject);
    }

    protected virtual void LastWords() { }
}
