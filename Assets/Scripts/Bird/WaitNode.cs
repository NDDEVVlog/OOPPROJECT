using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

public class WaitNode : Node
{

    private float waitTime;
    private float _WaitCounter = 0;
    private MonoBehaviour monoBehaviour;
    private bool isWaiting = false;
    float minWaitTime = 4f;
    float maxWaitTime = 10f;

    public WaitNode( float waitTime, MonoBehaviour monoBehaviour)
    {
        
        this.waitTime = waitTime;
        this.monoBehaviour = monoBehaviour;
    }

    public override NodeState Evalute()
    {
        /*if (!isWaiting)
        {
            isWaiting = true;
            monoBehaviour.StartCoroutine(Wait(Random.Range(bird.minWaitTime, bird.maxWaitTime)));
        }
        Debug.Log("Evalute");
        return state;*/

        _WaitCounter += Time.deltaTime;

        if (_WaitCounter >= waitTime)
        {
            _WaitCounter = 0; // Reset counter

            waitTime = Random.Range(minWaitTime,maxWaitTime); // Set next wait time

            return NodeState.SUCCESS;
        }

        return NodeState.RUNNING;
    }

    /*private IEnumerator Wait(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        Debug.Log("Wait");

        state = NodeState.SUCCESS;
        isWaiting = false;
    }*/
}
