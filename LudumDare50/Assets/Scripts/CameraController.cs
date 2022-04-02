using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
    public static CameraController current;

    public Camera camera;
    public Transform indicator; //dependencies
    public Transform radial; //dependencies
    public float sensitivity = 45;
    public float lookRange = 6.25f;

    Vector2 mouseMovement;
    float xRotation;
    bool interactPressed;
    bool lookingAtTask;
    bool newTaskSettedUp;
    RaycastHit hit;
    float timeForTask = 1;
    float timeSoFar = 0;

    void Start()
    {
        current = this;
    }

    void Update()
    {
        //resolving and solving of tasks
        if (lookingAtTask && interactPressed) {
            if (!newTaskSettedUp) {
                timeForTask = 2f;
                newTaskSettedUp = true; Debug.Log("ayo?");
            }
            timeSoFar += Time.deltaTime;
            if (timeSoFar >= timeForTask) {
                hit.transform.GetComponent<TaskOneScript>().TaskCleared();
                timeSoFar = 0;
            }
        } else {
            if (timeSoFar > 0) {
                timeSoFar -= Time.deltaTime;
            } else { newTaskSettedUp = false; }
        }
        float lerpedValue = Vector3.Lerp(Vector3.zero, Vector3.right, timeSoFar / timeForTask).x;
        radial.GetComponent<Image>().fillAmount = lerpedValue;

        CameraControls(); //see below

        //cheks if we're looking at a task
        Debug.DrawRay(camera.transform.position, camera.transform.forward.normalized * lookRange, Color.yellow);
        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, lookRange, LayerMask.GetMask("task"))) {
            indicator.GetComponent<Image>().enabled = true; //squeeb
            radial.GetComponent<Image>().enabled = true;
            lookingAtTask = true;
        } else {
            if (timeSoFar <= 0) {
                indicator.GetComponent<Image>().enabled = false;
                radial.GetComponent<Image>().enabled = false;
            } lookingAtTask = false;
        }

        Debug.Log(lookingAtTask);
    }

    void CameraControls()
    {
        //player & camera rotates with clamp
        transform.Rotate(Vector3.up * mouseMovement.x);
        xRotation -= mouseMovement.y;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        camera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }

    public void OnMouseMove(InputValue input)
    {
        mouseMovement = input.Get<Vector2>();
    }

    public void OnInteractPressed()
    {
        interactPressed = true;
    }

    public void OnInteractReleased()
    {
        interactPressed = false;
    }
}
