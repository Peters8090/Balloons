using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torus : MonoBehaviour
{
    float movingSensivity = 0.001f;

    float rotatingSensitvity = 0.5f;

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        #region Moving
        foreach (var touch in Input.touches)
        {
            Vector3 delta = new Vector3(touch.deltaPosition.x, touch.deltaPosition.y, 0);

            transform.position += delta * movingSensivity;
        }
        #endregion

        #region Rotating
        Quaternion desiredRotation = transform.rotation;

        DetectTouchMovement.Calculate();
        if (Mathf.Abs(DetectTouchMovement.turnAngleDelta) > 0)
        {
            Vector3 rotationDeg = Vector3.zero;
            rotationDeg.z = DetectTouchMovement.turnAngleDelta;
            desiredRotation *= Quaternion.Euler(rotationDeg * rotatingSensitvity);
        }
        transform.rotation = desiredRotation;
        #endregion
    }
}
