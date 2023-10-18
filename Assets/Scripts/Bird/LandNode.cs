using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

public class LandNode : Node
{
    private Bird bird;
    private GameObject[] landingSpots;

    public LandNode(Bird bird, GameObject[] landingSpots)
    {
        this.bird = bird;
        this.landingSpots = landingSpots;
    }

    public override NodeState Evalute()
    {
        // Choose a random landing spot
        GameObject landingSpot = landingSpots[Random.Range(0, landingSpots.Length)];

        // Move the bird to the landing spot
        bird.transform.position = landingSpot.transform.position;

        return NodeState.SUCCESS;
    }
}
