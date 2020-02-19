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
        print(CameraViewFrustum.x);

        transform.GetChild(0).GetComponent<BoxCollider>().center = Vector3.left * CameraViewFrustum.x;
        transform.GetChild(1).GetComponent<BoxCollider>().center = Vector3.right * CameraViewFrustum.x;
        transform.GetChild(2).GetComponent<BoxCollider>().center = Vector3.down * CameraViewFrustum.y;
    }

    void Update()
    {
        
    }
}
