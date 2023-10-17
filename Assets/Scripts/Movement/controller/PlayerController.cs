using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : InputController
{
    public override bool RetrieveJumpInput()
    {
        return Input.GetButtonDown("Jump");
    }

    public override float RetrieveMoveInput()
    {
        return Input.GetAxisRaw("Horizontal");
    }
    public override bool RetrieveJumpHoldInput()
    {
        return Input.GetButton("Jump");
    }
    public override bool RetriecveCustomInput(KeyCode code)
    {
        return Input.GetKeyDown(code);
    }

}
