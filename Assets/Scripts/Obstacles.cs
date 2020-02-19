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
            swipeMouseDelta = (Vector2)Input.mousePosition - swipeStartMousePos;
            transform.localEulerAngles = new Vector3(0, 0, swipeStartMyRotZ + 180 * swipeMouseDelta.x / Screen.width);
            //transform.localEulerAngles = new Vector3(0, 0, swipeStartMyRotZ + (180 * swipeMouseDelta.magnitude / new Vector2(Screen.width, Screen.height).magnitude) * (swipeMouseDelta.x + swipeMouseDelta.y > 0 ? 1 : -1));
            //GameObject go = new GameObject("temp");
            //go.transform.position = Input.mousePosition;
            //transform.LookAt(go.transform);
            //Destroy(go);
            //transform.localEulerAngles = new Vector3(0, 0, transform.localEulerAngles.z);
            //float angle = Mathf.Atan2(swipeMouseDelta.normalized.y, swipeMouseDelta.normalized.x) * Mathf.Rad2Deg;
            //transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
}
