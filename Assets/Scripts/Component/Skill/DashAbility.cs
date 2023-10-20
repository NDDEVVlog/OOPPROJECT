using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class DashAbility : BaseSingleAbilitySkill
{
    Vector2 MoveInput;
    Vector2 DashDir;
    Rigidbody2D Rb;
    public float DashSpeed = 12f;
    public float DashingTime = 0.5f;
    Controller controll;

    
    

    public bool IsMoving { get; private set; }
    public bool isDashing = false;
    public bool canDash = true;
    float time;
    public override void Activate(GameObject parent,float Time)
    {
        MoveInput.x = controll.input.RetrieveMoveInput();
        DashDir = new Vector2(MoveInput.x, 0.08f);


        if (DashDir.x == Vector2.zero.x)
        {
            DashDir = new Vector2(parent.transform.localScale.x, 0.0f);
        }
        
        Rb.velocity = new Vector2(DashDir.x * 250* Time, DashDir.y * 150*Time);
        
    }
    
    public override void AssignVariable(GameObject parent)
    {

        base.AssignVariable(parent);
        controll = parent.GetComponent<Controller>();
        Rb = parent.GetComponent<Rigidbody2D>();
        
    }

    public override bool ReturnInputValue(float Time)
    {
        return controll.input.RetriecveCustomInput(keyCode);
    }

   
}
