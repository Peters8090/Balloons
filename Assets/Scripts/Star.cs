using UnityEngine;

public class Star : BoomObject
{
    protected override float boomForce { get => 0.1f; }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.tag == "Balloon")
            StartCoroutine(Die());
    }

    protected override void LastWords()
    {
        base.LastWords();
#if !UNITY_EDITOR && UNITY_IOS
        IOSNative.StartHapticFeedback(HapticFeedbackTypes.MEDIUM);
#endif
        // Check if this was the last star on scene
        if (FindObjectsOfType<Star>().Length == 1)
            GameControlScript.instance.Level++;  
    }
}
