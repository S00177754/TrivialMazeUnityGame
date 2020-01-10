using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    //Public 
    public CharacterController characterController;
    public float Speed = 10f;
    public float SprintSpeed = 14f;
    public float Gravity = -9.81f;
    //Private
    Vector3 velocity;

    private void Start()
    {
    }

    private void Update()
    {
        float xMove = Input.GetAxis("Horizontal");
        float zMove = Input.GetAxis("Vertical");

        Vector3 direction = transform.right * xMove + transform.forward * zMove;

        if (Input.GetButton("Sprint"))//Sprint setup in input axis
        {
            characterController.Move(direction * Time.deltaTime * SprintSpeed);
        }
        else
        {
            characterController.Move(direction * Time.deltaTime * Speed);
        }

        velocity.y += Gravity * Time.deltaTime;

        characterController.Move(velocity * Time.deltaTime); //T = time.deltaTime
    }

    // y = ((1/2)*g) * t^2
    //Velocity constantly increasing, need to reset when hits the ground. Maybe some kind of check with reference to the bottom of the object
}
