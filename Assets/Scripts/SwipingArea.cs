using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipingArea : MonoBehaviour
{
    public static float swipeStartRotZ = 0;
    public static Vector2 swipeStartMousePos = Vector2.zero;

    public static Vector2 swipeMouseDelta = Vector2.zero;

    void Update()
    {
        if(Time.timeScale != 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                swipeStartMousePos = Input.mousePosition;
                swipeStartRotZ = transform.localEulerAngles.z;
            }
            if (Input.GetMouseButton(0))
            {
                // Calculate the finger move
                swipeMouseDelta = (Vector2)Input.mousePosition - swipeStartMousePos;

                float targetRotZ = 0;
                // Check if player is swiping on the X or Y axis
                if (Mathf.Abs(swipeMouseDelta.x) > Mathf.Abs(swipeMouseDelta.y))
                {
                    // Depending on which part of screen the player touches => swipe up and swipe down will be interpreted as turn the Swiping Area right or left
                    float multiplier = Input.mousePosition.y > Screen.height / 2 ? -1 : 1;
                    targetRotZ = swipeStartRotZ + 180 * swipeMouseDelta.x / Screen.width * multiplier;
                }
                else
                {
                    // Same as in the positive statement
                    float multiplier = Input.mousePosition.x > Screen.width / 2 ? 1 : -1;
                    targetRotZ = swipeStartRotZ + 180 * swipeMouseDelta.y / Screen.width * multiplier;
                }

                transform.localEulerAngles = Vector3.forward * targetRotZ;

                // TODO: Change transform.localEulerAngles = ... to rb.angularVelocity = ...

                swipeStartMousePos = Input.mousePosition;
                swipeStartRotZ = transform.localEulerAngles.z;
            }
        }
    }
}
