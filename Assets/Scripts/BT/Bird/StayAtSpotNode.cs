using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

public class StayAtSpotNode : Node
{
    private Bird bird;
    private GameObject landingSpot;
    private float speed;

    public StayAtSpotNode(Bird bird, GameObject landingSpot, float speed)
    {
        this.bird = bird;
        this.landingSpot = landingSpot;
        this.speed = speed;
    }

    public override NodeState Evalute()
    {
        // Keep the bird at the landing spot until it reaches the spot
        float step = speed * Time.deltaTime;
        bird.transform.position = Vector3.MoveTowards(bird.transform.position, landingSpot.transform.position, step);

        if (Vector3.Distance(bird.transform.position, landingSpot.transform.position) < 0.001f)
        {
            return NodeState.SUCCESS; // Return SUCCESS when the bird has reached the spot
        }

        return NodeState.RUNNING; // Keep running this node until the bird has reached the spot
    }
}
