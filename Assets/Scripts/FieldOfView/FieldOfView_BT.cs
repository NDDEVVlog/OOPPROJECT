using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

public class FieldOfView_BT :BehaviorTree.Node
{
    public float radius;
    [Range(0, 360)]
    public float angle;

    public GameObject playerRef;
    public LayerMask targetMask;
    public LayerMask obstructionMask;

    public bool canSeePlayer;

    public Controller controller;
    public float xDirection = 1;
    public FieldOfView_BT(LayerMask target,AIController controller)
    {
        targetMask = target;
    }
    public override NodeState Evalute()
    {
        return base.Evalute();
    }
}
