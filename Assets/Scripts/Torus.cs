using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Torus : MonoBehaviour
{
    float movingSensivity = 2f;

    float rotatingSensitvity = 1f;

    void FixedUpdate()
    {
        #region Moving
        foreach (var touch in Input.touches)
        {
            Vector3 delta = Camera.main.ScreenToViewportPoint(touch.deltaPosition);

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

        transform.DOLocalRotateQuaternion(desiredRotation, Time.deltaTime);
        #endregion
    }
}
