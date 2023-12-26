using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

public class Chasing : BehaviorTree.Node
{
    BoarBT boar;
    public Chasing(BoarBT boar)
    {
        this.boar = boar;
    }
    public override NodeState Evalute()
    {
        Vector2 ChaseDirection = new Vector2(boar.gameObject.transform.position.x - boar.fieldOfView.playerRef.transform.position.x, 0);
        boar.ai.xValue = Mathf.Clamp(ChaseDirection.x, -1, 1);
        boar.move._maxSpeed = Mathf.Lerp(boar.walkSpeed, boar.runSpeed, Time.deltaTime);


        return NodeState.RUNNING;
    }
}
