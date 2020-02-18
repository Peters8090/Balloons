using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayOnTheScreen : MonoBehaviour
{
    Collider topCollider;
    Collider myCollider;

    Vector4 screenBounds;

    void Start()
    {
        topCollider = GameObject.Find("Trap").GetComponentInChildren<Collider>();
        myCollider = GetComponentInChildren<Collider>();

        float distance = (transform.position - Camera.main.transform.position).z;
        screenBounds = new Vector4(
            Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance)).x,
            Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance)).x,
            Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance)).y,
            topCollider.bounds.min.y);
    }

    void LateUpdate()
    {
        // Objects rotate over the time, so we will need to recalculate these values
        float leftBorder = screenBounds.x + (myCollider.bounds.size.x / 2);
        float rightBorder = screenBounds.y - (myCollider.bounds.size.x / 2);
        float bottomBorder = screenBounds.z + (myCollider.bounds.size.y / 2);
        float topBorder = screenBounds.w - (myCollider.bounds.size.y / 2);

        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, leftBorder, rightBorder),
            Mathf.Clamp(transform.position.y, bottomBorder, topBorder),
            transform.position.z);
    }
}
