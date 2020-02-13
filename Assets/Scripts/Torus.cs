using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

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


            print(delta);
            //transform.DOBlendableMoveBy(delta * movingSensivity, 0.01f).SetRelative();
            //transform.position += delta * movingSensivity;
            transform.DOMove(transform.position + delta * movingSensivity, Time.deltaTime);
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
        //transform.rotation = desiredRotation;
        //transform.DOBlendableRotateBy(DetectTouchMovement.turnAngleDelta * Vector3.forward, 1f);
        #endregion
    }
}
