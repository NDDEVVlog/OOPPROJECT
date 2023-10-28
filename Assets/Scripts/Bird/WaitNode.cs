using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

public class WaitNode : Node
{

    private float waitTime;
    private float _WaitCounter = 0;

    float minWaitTime = 4f;
    float maxWaitTime = 10f;

    public WaitNode( float waitTime)
    {
        
        this.waitTime = waitTime;

    }

    public override NodeState Evalute()
    {
        

        _WaitCounter += Time.deltaTime;

        if (_WaitCounter >= waitTime)
        {
            _WaitCounter = 0; // Reset counter

            //waitTime = Random.Range(minWaitTime,maxWaitTime); // Set next wait time

            return NodeState.SUCCESS;
        }

        return NodeState.RUNNING;
    }

   
}
