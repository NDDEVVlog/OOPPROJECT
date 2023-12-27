using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

public class CheckPlayerInFieldOfView : BehaviorTree.Node
{
    BoarBT boar;
    public CheckPlayerInFieldOfView(BoarBT Boar)
    {
        this.boar = Boar;
    }
    public override NodeState Evalute()
    {

        if (boar.canSeePlayer)
        {

            boar.ai.xValue = boar.transform.localScale.x;
            var speedValue = boar.runSpeed;
            
            boar.move._maxSpeed = (float)speedValue;
            boar.gameObject.GetComponent<Animator>().SetFloat("WalkToRun", speedValue);
            return NodeState.SUCCESS;
        }
        var speed = boar.walkSpeed;

        boar.move._maxSpeed = (float)speed;
        boar.gameObject.GetComponent<Animator>().SetFloat("WalkToRun", speed);

        return NodeState.FAILURE;
    }
}
