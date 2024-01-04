using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

public class BasicEnemyBT : BehaviorTree.Tree
{
    public static float fovRange = 3f;
    public static float attackRange = 2f;
    public LayerMask layer;
    public Movement   movement;
    public AIController ai;
   // public PlayerStateMachine stateMachine;
    private void Awake()
    {
        //stateMachine = GetComponent<PlayerStateMachine>();
    }
    protected override Node SetupTree()
    {
        //GetComponent<Control.Controller>().input;
        Node root = new SequenceOrder(new List<Node>
        {
            new TaskPatrol(layer, 0.6f, 0.1f, this.gameObject, ai),
            new TaskWaitTime(),

        }) ;
        //Node root = new TaskPatrol(layer, 1.5f, 1, this.gameObject, ai);
        return root;
    }
}
