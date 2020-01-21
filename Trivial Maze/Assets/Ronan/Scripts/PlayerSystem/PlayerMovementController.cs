using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    //Public 
    public CharacterController characterController;

    public float Speed = 10f;
    public float SprintSpeed = 14f;
    //public float climbSpeed = 3f;
    public float JumpHeight = 2f;
    public float Gravity = -9.81f;

    public Transform bottomOfPlayer;
    public Transform frontOfPlayer;
    public PlayerLookController playerLookController;
    public LayerMask groundLayer;
    public LayerMask defaultLayer;

    public string HorizontalInput;
    public string VerticalInput;
    public string SprintInput;

    //Private
    Vector3 velocity;
    bool isTouchingGround;
    bool isTouchingClimbable;
    RaycastHit hit;
    float GroundCheckRadius = 0.3f;
    //float ClimbCheckRadius = 0.3f;

    private void Start()
    {
    }

    private void Update()
    {
        hit = new RaycastHit();

        isTouchingGround = Physics.CheckSphere(bottomOfPlayer.position, GroundCheckRadius, groundLayer);

        //Reset velocity
        if(isTouchingGround && velocity.y < 0)
        {
            velocity.y = -2f; //works but still seems a little floaty, going to try and incorporate mass into formula   
        }

        #region Movement X and z

        //Take input and move by it
        float xMove = Input.GetAxis(HorizontalInput);
        float zMove = Input.GetAxis(VerticalInput);

        Vector3 direction = transform.right * xMove + transform.forward * zMove;

        if (!isTouchingClimbable)
        {
            if (Input.GetButton(SprintInput))//Sprint setup in input axis
            {
                characterController.Move(direction * Time.deltaTime * SprintSpeed);
            }
            else
            {
                characterController.Move(direction * Time.deltaTime * Speed);
            }
        }

        //else if(isTouchingClimbable && isTouchingGround)
        //{
        //    if (Input.GetButton("Sprint"))//Sprint setup in input axis
        //    {
        //        characterController.Move(direction * Time.deltaTime * SprintSpeed);
        //    }
        //    else
        //    {
        //        characterController.Move(direction * Time.deltaTime * Speed);
        //    }
        //}

        #endregion

        #region Jump

        if (Input.GetButtonDown("Jump") && isTouchingGround)
        {
            velocity.y = Mathf.Sqrt(JumpHeight * -2 * Gravity); //v = Square root of (h * -2 * g)
        }

        #endregion

        #region Climb

        
        //if(Physics.Raycast(frontOfPlayer.position, frontOfPlayer.up, out hit, ClimbCheckRadius, defaultLayer))
        //{
        //    Debug.Log("Did Hit");

        //    if(hit.collider.gameObject.tag == "Climbable")
        //    {
        //        Debug.Log("Climbable");
        //        isTouchingClimbable = true;
        //        playerLookController.LockedView = true;
        //    }
            
        //}
        //else
        //{
        //    isTouchingClimbable = false;
        //    playerLookController.LockedView = false;
        //}


        ////Climbing movement
        //if (isTouchingClimbable)
        //{
        //    characterController.Move((transform.up * zMove + transform.right * xMove) * climbSpeed * Time.deltaTime);
        //}


        #endregion

        if (!isTouchingClimbable)
        {
            velocity.y += 2 * Gravity * Time.deltaTime; // y = ((1/2)*g) * t^2

            characterController.Move(velocity * Time.deltaTime); //T = time.deltaTime
        }
    }


    //Velocity constantly increasing, need to reset when hits the ground. Maybe some kind of check with reference to the bottom of the object

    private void OnDrawGizmos()
    {
        Debug.DrawRay(frontOfPlayer.position, frontOfPlayer.up,Color.magenta);
    }
}
