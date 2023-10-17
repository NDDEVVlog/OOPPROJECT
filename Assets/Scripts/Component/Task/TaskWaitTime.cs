using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

public class TaskWaitTime : Node
{
    private float _WaitTime = 5f;
    private float _WaitCounter = 0f;

    public override NodeState Evalute()
    {
        _WaitCounter += Time.deltaTime;
        if (_WaitCounter >= _WaitTime)
        {
           _WaitCounter = 0;


            return NodeState.SUCCESS;
        }
        return NodeState.RUNNING;
    }



}
