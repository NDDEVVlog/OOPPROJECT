using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

public class SnailBT : BehaviorTree.Tree
{

    public bool onTakeDamage = false;
    public LayerMask layer;
    public AIController ai;

    SnailHealth snailHeatlh;
   // public PlayerStateMachine stateMachine;
    private void Awake()
    {
        snailHeatlh = GetComponent<SnailHealth>();   
    }   
    protected override Node SetupTree()
    {
        Node hideInShell = new HideShell(this, this.snailHeatlh, 5f);
        Node CheckHit = new Sequence(new List<Node>
        {
            new isTakingDamageNode(this),
            hideInShell

        }) ;
        

        Selector SnailSelect = new Selector(
            new List<Node>
            {
               CheckHit,
               new TaskPatrol(layer, 0.6f, 0.1f, this.gameObject, ai),
            }
            );
        //Node root = new TaskPatrol(layer, 1.5f, 1, this.gameObject, ai);
        return SnailSelect;
    }


    public void OnTakeDamage()
    {
        Debug.Log(onTakeDamage);    
        onTakeDamage = true;
    }
}
