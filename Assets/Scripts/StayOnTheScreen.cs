using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayOnTheScreen : MonoBehaviour
{
    [SerializeField]
    Renderer renderer;

    float smoothFactor = 0.5f;

    float topBorder = 0.8f;

    void FixedUpdate()
    {
        //https://answers.unity.com/questions/509283/limit-a-sprite-to-not-go-off-screen.html
        float distance = (transform.position - Camera.main.transform.position).z;

        float leftBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance)).x + (renderer.bounds.size.x / 2);
        float rightBorder = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance)).x - (renderer.bounds.size.x / 2);

        float bottomBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance)).y + (renderer.bounds.size.y / 2);
        //var topBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, distance)).y - (renderer.bounds.size.y / 2);


        Vector3 targetPos = new Vector3(
            Mathf.Clamp(transform.position.x, leftBorder, rightBorder),
            Mathf.Clamp(transform.position.y, bottomBorder, topBorder),
            transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetPos, smoothFactor);
    }
}
