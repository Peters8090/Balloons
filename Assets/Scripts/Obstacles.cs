using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    public static Vector2 swipeStartMousePos = Vector2.zero;
    public static float swipeStartMyRotZ = 0;
    public static Vector2 swipeMouseDelta = Vector2.zero;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            swipeStartMousePos = Input.mousePosition;
            swipeStartMyRotZ = transform.localEulerAngles.z;
        }
        if (Input.GetMouseButton(0))
        {
            swipeMouseDelta = ((Vector2)Input.mousePosition - swipeStartMousePos);
            if (Mathf.Abs(swipeMouseDelta.x) > Mathf.Abs(swipeMouseDelta.y))
            {
                float multiplier = Input.mousePosition.y > Screen.height / 2 ? -1 : 1;
                transform.localEulerAngles = new Vector3(0, 0, swipeStartMyRotZ + 180 * swipeMouseDelta.x / Screen.width * multiplier);
            } else
            {
                float multiplier = Input.mousePosition.x > Screen.width / 2 ? 1 : -1;
                transform.localEulerAngles = new Vector3(0, 0, swipeStartMyRotZ + 180 * swipeMouseDelta.y / Screen.width * multiplier);
            }

            swipeStartMousePos = Input.mousePosition;
            swipeStartMyRotZ = transform.localEulerAngles.z;
        }
    }
}
