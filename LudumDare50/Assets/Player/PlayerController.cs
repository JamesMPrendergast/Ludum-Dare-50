using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public static PlayerController current; //makes player easily accessible

    //Setting variables (things we can tweak)
    public float speed = 5f;

    Vector2 movement;

    void Start()
    {
        current = this; //makes player easily accessible by other scripts, type: PlayerController.current.gameObject
    }

    void Update()
    {
        transform.Translate(new Vector3(movement.x, 0, movement.y), Space.Self);
    }

    public void OnWalk(InputValue input)
    {
        movement = input.Get<Vector2>();
    }
}
