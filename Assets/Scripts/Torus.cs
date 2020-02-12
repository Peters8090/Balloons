using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torus : MonoBehaviour
{
    [SerializeField]
    float movingSensivity = 0.05f;
    [SerializeField]
    float rotatingSensitvity = 30f;

    void Update()
    {
        #region Moving
        foreach (var touch in Input.touches)
        {
            Vector3 delta = new Vector3(touch.deltaPosition.x, touch.deltaPosition.y, 0);
            transform.position = Vector3.Lerp(transform.position, transform.position + delta, movingSensivity * Time.deltaTime);
        } 
        #endregion

        #region Rotating
        Quaternion desiredRotation = transform.rotation;

        DetectTouchMovement.Calculate();
        if (Mathf.Abs(DetectTouchMovement.turnAngleDelta) > 0)
        {
            Vector3 rotationDeg = Vector3.zero;
            rotationDeg.z = DetectTouchMovement.turnAngleDelta;
            desiredRotation *= Quaternion.Euler(rotationDeg);
        }
        transform.rotation = Quaternion.Lerp(transform.rotation, desiredRotation, Time.deltaTime * rotatingSensitvity);
        #endregion
    }
}
