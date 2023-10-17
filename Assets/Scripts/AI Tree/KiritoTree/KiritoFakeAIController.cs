using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class KiritoFakeAIController : InputController
{
    public float xValue = 0;
    // Start is called before the first frame update
        public override bool RetrieveJumpInput()
        {   
            
            return false;
        }
    /* public override float RetrieveMoveInput(float x)
     {
         throw new System.NotImplementedException();
     }
     public override bool RetriveCrouchInput()
     {
         return false;
     }*/
    public override float RetrieveMoveInput()
        {
            return xValue;
        }
        public override bool RetrieveJumpHoldInput()
        {
            return false;
            //throw new System.NotImplementedException();
        }

    public override bool RetriecveCustomInput(KeyCode code)
    {
        throw new System.NotImplementedException();
    }

}
