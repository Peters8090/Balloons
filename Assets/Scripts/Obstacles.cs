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
            float multiplier = 1;
            if (Input.mousePosition.x < Screen.width / 2)
                multiplier = -1;
            print(multiplier);

            swipeMouseDelta = ((Vector2)Input.mousePosition - swipeStartMousePos) * multiplier;
            if (Mathf.Abs(swipeMouseDelta.x) > Mathf.Abs(swipeMouseDelta.y))
            {
                transform.localEulerAngles = new Vector3(0, 0, swipeStartMyRotZ + 180 * swipeMouseDelta.x / Screen.width);
            } else
            {
                transform.localEulerAngles = new Vector3(0, 0, swipeStartMyRotZ + 180 * swipeMouseDelta.y / Screen.width);
            }

            swipeStartMousePos = Input.mousePosition;
            swipeStartMyRotZ = transform.localEulerAngles.z;
        }
    }
}
