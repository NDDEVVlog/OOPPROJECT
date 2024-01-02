using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

public class isTakingDamageNode : Node
{
    SnailBT snail;
    public isTakingDamageNode(SnailBT snail)
    {
        this.snail = snail;
    }
    public override NodeState Evalute() {
       
        if(snail.onTakeDamage)
        return NodeState.SUCCESS;

        return NodeState.FAILURE;
    }
}
