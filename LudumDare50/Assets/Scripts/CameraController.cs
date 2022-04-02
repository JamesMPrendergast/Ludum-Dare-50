using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    public static CameraController current;

    public Camera camera;
    public float sensitivity = 45;

    Vector2 mouseMovement;
    float xRotation;

    void Start()
    {
        current = this;
    }

    void Update()
    {
        CameraControls();
    }

    void CameraControls()
    {
        transform.Rotate(Vector3.up * mouseMovement.x);
        xRotation -= mouseMovement.y;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        camera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }

    public void OnMouseMove(InputValue input)
    {
        mouseMovement = input.Get<Vector2>();
    }
}
