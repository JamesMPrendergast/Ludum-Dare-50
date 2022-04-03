using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public static PlayerController current; //makes player easily accessible

    public CharacterController cc;
    public Transform groundCheck;

    //Setting variables (things we can tweak)
    public float baseSpeed = 5f;
    public float groundDistance = .25f;
    public float gravity = -9.81f;
    public LayerMask groundMask;

    Vector2 movement;
    float speed;
    bool isGrounded;
    Vector3 velocity;
    public float totalBoost;
    float boostTimer;

    void Start()
    {
        current = this; //makes player easily accessible by other scripts, type: PlayerController.current.gameObject

        cc = GetComponent<CharacterController>();
    }

    void Update()
    {
        //boost make-shift coroutine
        if (boostTimer > 0) { if (CameraController.current.taskBeingSolved == null) { boostTimer -= Time.deltaTime; } }
        else { totalBoost = 0; }

        Move();

        isGrounded = Physics.CheckSphere(groundCheck.transform.position, groundDistance, groundMask); //checks if on ground
        if (isGrounded && velocity.y < 0) {
            velocity.y = -2f; //makes it actually go all the way down to the ground
        } else if (!isGrounded) { velocity.y += gravity * Time.deltaTime; } //gain speed when in mid air
        cc.Move(velocity * Time.deltaTime); //move according to your velocity
    }

    private void Move() //moves the player according to local space & inputs
    {
        if (CameraController.current.interactPressed) { speed = baseSpeed / 2; } //incentive so that the player doesn't hold down 'E'
        else { speed = baseSpeed + totalBoost; }

        Vector3 moveDir = transform.right * movement.x + transform.forward * movement.y;
        cc.Move(moveDir * speed * Time.deltaTime);
    }

    public void OnWalk(InputValue input)
    {
        movement = input.Get<Vector2>(); //gets input information
    }

    public void tempBoost(float boost, float duration)
    {
        totalBoost += boost;
        if (boostTimer < duration) { boostTimer = duration; }
    }
}
