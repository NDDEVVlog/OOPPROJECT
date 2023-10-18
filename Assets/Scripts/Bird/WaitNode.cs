using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

public class WaitNode : Node
{
    private Bird bird;
    private float waitTime;
    private MonoBehaviour monoBehaviour;
    private bool isWaiting = false;

    public WaitNode(Bird bird, float waitTime, MonoBehaviour monoBehaviour)
    {
        this.bird = bird;
        this.waitTime = waitTime;
        this.monoBehaviour = monoBehaviour;
    }

    public override NodeState Evalute()
    {
        if (!isWaiting)
        {
            isWaiting = true;
            monoBehaviour.StartCoroutine(Wait(Random.Range(bird.minWaitTime, bird.maxWaitTime)));
        }

        return state;
    }

    private IEnumerator Wait(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        state = NodeState.SUCCESS;
        isWaiting = false;
    }
}
