using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Torus : MonoBehaviour
{
    float movingSensivity = 0.001f;

    float rotatingSensitvity = 1f;

    void FixedUpdate()
    {
        #region Moving
        foreach (var touch in Input.touches)
        {
            Vector3 delta = new Vector3(touch.deltaPosition.x, touch.deltaPosition.y, 0);

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
