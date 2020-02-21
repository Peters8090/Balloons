using UnityEngine;

public class Balloon : BoomObject
{
    protected override float boomForce { get => 0.3f; }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject == UsefulReferences.instance.trap)
            StartCoroutine(Die());
    }

    protected override void LastWords()
    {
        base.LastWords();
#if !UNITY_EDITOR && UNITY_IOS
        IOSNative.StartHapticFeedback(HapticFeedbackTypes.HEAVY);
#endif
        
    }
}
