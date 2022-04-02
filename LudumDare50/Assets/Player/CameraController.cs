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

    void Start()
    {
        current = this;
    }

    void Update()
    {
        transform.Rotate(Vector3.up * mouseMovement.x * sensitivity * Time.deltaTime, Space.Self); //rotates player
        float realX = (camera.transform.eulerAngles.x + 180) % 360 - 180;
        if ((realX < -33.75f && mouseMovement.x > 0) || (realX > 33.75f && mouseMovement.x < 0) || (realX > -33.75f && realX < 33.75f)) {
            camera.transform.Rotate(Vector3.right * -mouseMovement.y * sensitivity * Time.deltaTime, Space.Self); //turns head w/ clamps
        }
    }

    public void OnMouseMove(InputValue input)
    {
        mouseMovement = input.Get<Vector2>();
    }
}
