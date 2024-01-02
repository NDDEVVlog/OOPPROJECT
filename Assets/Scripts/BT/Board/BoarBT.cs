using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

public class BoarBT : BehaviorTree.Tree
{

    public bool onTakeDamage = false;
    public LayerMask layer;
    public AIController ai;
    public bool canSeePlayer;

    public FieldOfView fieldOfView;
    public float walkSpeed = 0.5f;
    public float runSpeed = 2.0f;
    public Movement move;
    // public PlayerStateMachine stateMachine;
    private void Awake()
    {
        move = GetComponent<Movement>();
        fieldOfView = GetComponent<FieldOfView>();

    }
    void CheckCanSee()
    {   
        
        Debug.Log("Run");
        canSeePlayer = fieldOfView.canSeePlayer;

       
    }
    protected override Node SetupTree()
    {
      

        Sequence CheckPlayerInFieldOfView = new Sequence(new List<Node>{

            new CheckPlayerInFieldOfView(this),

        });

        Selector BoarSelect = new Selector(
            new List<Node>
            {
                new CheckPlayerInFieldOfView(this),
               new TaskPatrol(layer, 0.6f, 0.1f, this.gameObject, ai),
            }
            );
        InvokeRepeating("CheckCanSee",0f,1f);

        //Node root = new TaskPatrol(layer, 1.5f, 1, this.gameObject, ai);
        return BoarSelect;
    }


    public void OnTakeDamage()
    {
        Debug.Log(onTakeDamage);
        onTakeDamage = true;
    }
}

