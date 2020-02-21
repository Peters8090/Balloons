using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenColliders : MonoBehaviour
{
    public class CameraViewFrustum
    {
        public static float x = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0)).x;
        public static float y = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0)).y;
    }

    void Start()
    {
        transform.Find("Top").GetComponent<BoxCollider2D>().offset = Vector2.up * CameraViewFrustum.y;
        transform.Find("Right").GetComponent<BoxCollider2D>().offset = Vector2.right * CameraViewFrustum.x;
        transform.Find("Bottom").GetComponent<BoxCollider2D>().offset = Vector2.down * CameraViewFrustum.y;
        transform.Find("Left").GetComponent<BoxCollider2D>().offset = Vector2.left * CameraViewFrustum.x;
    }
}
