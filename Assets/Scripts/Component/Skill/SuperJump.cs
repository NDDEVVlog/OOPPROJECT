using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SuperJump : BaseSingleAbilitySkill
{
    Vector2 MoveInput;
    Vector2 DashDir;
    Rigidbody2D Rb;
    public float DashSpeed = 12f;
    public float DashingTime = 0.5f;
    Controller controll;

    public float holdingTime = 1.5f;
    float currentHoldingTime = 0f;

    public bool IsMoving { get; private set; }
    public bool isDashing = false;
    public bool canDash = true;
    public Jump jumpScript;
    float tempJumpHeight;
    float tempUpwardMovement;

    public override void Activate(GameObject parent, float Time)
    {



        jumpScript._jumpHeight = 3f;
        jumpScript._upwardMovementMultiplier = 2f;
        jumpScript._desiredJump = true;


    }
    public override void AssignVariable(GameObject parent)
    {
        controll = parent.GetComponent<Controller>();
        Rb = parent.GetComponent<Rigidbody2D>();
        jumpScript = parent.GetComponent<Jump>();
        tempJumpHeight = jumpScript._jumpHeight;
        tempUpwardMovement = jumpScript._upwardMovementMultiplier;

        


    }
    public override void Deactivate()
    {
        jumpScript._jumpHeight = tempJumpHeight;
        jumpScript._upwardMovementMultiplier = tempUpwardMovement;
        jumpScript._desiredJump = false;

        

        currentHoldingTime = 0;
        Debug.Log("LOL");
    }
    public override bool ReturnInputValue(float Time)
    {
        if (Input.GetKey(keyCode))
        {
            
            currentHoldingTime += Time;
            if (currentHoldingTime >= holdingTime)
            {
                

                return true;
            }
        }

        return false;
    }
}