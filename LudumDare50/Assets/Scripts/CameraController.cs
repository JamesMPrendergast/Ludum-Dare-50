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
    public float FOVTransitionTime = 0.1f;

    Vector2 mouseMovement;
    float xRotation;
    public bool interactPressed;
    bool lookingAtTask;
    bool newTaskSettedUp;
    RaycastHit hit;
    float timeForTask = 1;
    float timeSoFar = 0;
    public Transform taskBeingSolved;
    bool changingFOV;
    float FOVTimer;
    float setFOV = 60;
    float startingFOV;
    float FOVTarget;

    void Start()
    {
        current = this;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        //checks if we're looking at a task -----------------------------------------------------------------
        Debug.DrawRay(camera.transform.position, camera.transform.forward.normalized * lookRange, Color.yellow);
        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, lookRange)) {
            //Debug.Log(hit.transform.gameObject.layer + " vs " + "8");
            if (hit.transform.gameObject.layer == 8) {
                indicator.GetComponent<Image>().enabled = true; //squeeb
                radial.GetComponent<Image>().enabled = true;
                lookingAtTask = true;
            } else { lookingAtTask = false; taskBeingSolved = null; indicator.GetComponent<Image>().enabled = false; }
        } else {
            if (timeSoFar <= 0) {
                indicator.GetComponent<Image>().enabled = false;
                radial.GetComponent<Image>().enabled = false;
            } lookingAtTask = false;
        }

        //resolving and solving of tasks
        if (lookingAtTask && interactPressed) {
            //if (hit.transform != taskBeingSolved) { newTaskSettedUp = false; timeSoFar = 0; }
            if (!newTaskSettedUp) {
                timeForTask = hit.transform.GetComponent<TaskOneScript>().completionTime;
                taskBeingSolved = hit.transform;
                newTaskSettedUp = true;
            }
            timeSoFar += Time.deltaTime;
            if (timeSoFar >= timeForTask) {
                hit.transform.GetComponent<TaskOneScript>().TaskCleared();
                timeSoFar = 0;
            }
        } else {
            taskBeingSolved = null;
            if (timeSoFar > 0) {
                timeSoFar -= Time.deltaTime;
            } else { newTaskSettedUp = false; }
        }
        float lerpedValue = Vector3.Lerp(Vector3.zero, Vector3.right, timeSoFar / timeForTask).x;
        radial.GetComponent<Image>().fillAmount = lerpedValue;

        CameraControls(); //see below

        //FOV speed boost indicator
        if (!changingFOV) {
            FOVTarget = 60 + PlayerController.current.totalBoost * 4;
            if (camera.fieldOfView != FOVTarget) {
                changingFOV = true;
                FOVTimer = 0;
                startingFOV = camera.fieldOfView;
            }
        } else {
            if (FOVTimer >= FOVTransitionTime) {
                setFOV = FOVTarget;
                changingFOV = false;
            } else {
                setFOV = Mathf.Lerp(startingFOV, FOVTarget, FOVTimer / FOVTransitionTime);
                FOVTimer += Time.deltaTime;
            }
        }
        camera.fieldOfView = setFOV;
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
