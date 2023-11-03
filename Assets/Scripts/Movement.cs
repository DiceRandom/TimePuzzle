using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public enum PlayerState{
    Still = 0,
    Walk = 1,
    Pivot = 2,
    Air = 3,
}

public enum JumpState{
    Press = 0,
    Hold = 1,
    None = 2
}


public class Movement : MonoBehaviour
{


    [Header("Movement Settings")]
    float targetVelocity; // modifyed by input
    float actualVelocity; // appiled to rb
    public float accelSpeed;
    public float desiredSpeed;

    public float deadzone = 0.5f;

    public bool direction = true; // default is right


    
    [Header("Jump Settings")]
    public JumpState currentJump = JumpState.None; // NONE

    public float jumpForce;
    public float downVelocity;
    public float gravity;


    private Rigidbody2D rb;

    
    [Header("General Settings")]

    public PlayerState currentState = 0; // IDLE
    public bool isGrounded;
    public float height;
    public LayerMask ground;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // on press accelrate towards value based on button input

        targetVelocity = Input.GetAxisRaw("Horizontal") * desiredSpeed;

        HandleJump();
        CheckState();
    }
    void FixedUpdate()
    {

        if ((rb.velocity.x - targetVelocity) < 0) actualVelocity += accelSpeed;
        if ((rb.velocity.x - targetVelocity) > 0) actualVelocity -= accelSpeed;
        Mathf.Clamp(actualVelocity,-desiredSpeed,desiredSpeed);

        rb.velocity = new Vector2(actualVelocity,rb.velocity.y);

        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector3.down), height/2,ground);
        isGrounded = hit.collider != null;
        
        UnityEngine.Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down)*height/2, Color.white);

    }

    bool CHECK_POSITIVE_FLOAT(float x){
        if(x > 0) return true; // POS
        return false; // NEG
    }

    void CheckState(){

        if(!isGrounded){
            currentState = PlayerState.Air;
            return;
        }

        if(rb.velocity.x > -deadzone && rb.velocity.x < deadzone){ // STILL
            currentState = PlayerState.Still; 
            return;
        }

        if(CHECK_POSITIVE_FLOAT(rb.velocity.x) ^ CHECK_POSITIVE_FLOAT(targetVelocity) && (rb.velocity.x > deadzone || rb.velocity.x < -deadzone)){  // PIVOT
            currentState = PlayerState.Pivot;
            direction = CHECK_POSITIVE_FLOAT(rb.velocity.x);
            return;
        }

        if(rb.velocity.x > deadzone || rb.velocity.x < -deadzone){ // WALK
            currentState = PlayerState.Walk; 
            direction = CHECK_POSITIVE_FLOAT(rb.velocity.x);
            return;
        }

        
    }

    void HandleJump(){
        if(Input.GetButtonDown("Jump") && isGrounded){
            currentJump = JumpState.Hold;
        }else{
            currentJump = JumpState.None;
        }

        switch (currentJump)
        {
            case JumpState.Hold:
                rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
                return;
            case JumpState.None:
                // =downVelocity = gravity;
                return;
        }
        



    }

}
