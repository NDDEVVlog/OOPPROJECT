using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

public class FlyNode : Node
{
    private Bird bird;
    private float speed;

    public FlyNode(Bird bird, float speed)
    {
        this.bird = bird;
        this.speed = speed;
    }

    public override NodeState Evalute()
    {
        // Move the bird across the screen
        bird.transform.position += Vector3.right * speed * Time.deltaTime;

        //MoveToward TO POSITION

        //RandomPoistion in Range
        //y = sin(X)+k

        //  Has an if (Bird == position ) 


        // If the bird has reached the other side of the screen, return SUCCESS
        if (bird.transform.position.x > 30f)
        {
            return NodeState.SUCCESS;
        }

        // Otherwise, keep flying
        return NodeState.RUNNING;
    }
}