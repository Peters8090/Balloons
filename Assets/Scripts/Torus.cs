using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Torus : MonoBehaviour
{
    Rigidbody rb;

    public static bool? allowedRotDir = null;
    public bool currentRotDir;

    bool invertRotDirOnCollision = false;
    float maxRotSpeed = 5f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Quaternion desiredRotation = transform.rotation;
        DetectTouchMovement.Calculate();

        Vector3 rotationDeg = Vector3.zero;
        rotationDeg.z = DetectTouchMovement.turnAngleDeltaClamped(maxRotSpeed);

        if (rotationDeg.z != 0 && !invertRotDirOnCollision)
        {
            bool predictedRotDir = rotationDeg.z > 0;

            if (allowedRotDir == predictedRotDir || allowedRotDir == null)
            {
                desiredRotation *= Quaternion.Euler(rotationDeg);
                currentRotDir = predictedRotDir;
                allowedRotDir = null;
            }
        }

        if (DetectTouchMovement.turnAngleDelta != 0 && invertRotDirOnCollision)
        {
            bool predictedRotatingDirection = rotationDeg.z > 0;
            if (allowedRotDir != predictedRotatingDirection)
                rotationDeg.z *= -1;

            desiredRotation *= Quaternion.Euler(rotationDeg);

            currentRotDir = rotationDeg.z > 0;
        }

        transform.DOLocalRotateQuaternion(desiredRotation, Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Obstacle"))
        {
            allowedRotDir = !currentRotDir;
        }
    }
}
