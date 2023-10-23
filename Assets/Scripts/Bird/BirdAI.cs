using System.Collections.Generic;
using BehaviorTree;
using UnityEngine;

public class BirdAI : BehaviorTree.Tree
{
    private Bird bird;
    public float checkRadius; // Radius for checking birds
    public LayerMask birdLayer; // Layer on which the birds are

    private void Awake()
    {
        bird = GetComponent<Bird>();
    }

    protected override Node SetupTree()
    {
        // Create nodes for each behavior
        FlyNode flyNode = new FlyNode(bird, 5f, 5f, 0.5f);
        LandNode landNode = new LandNode(bird, bird.landingSpots, 5f);
        WaitNode waitNode = new WaitNode(bird, 3f, this);

        // Create a selector node to choose between flying and landing

        // Create a CheckBirdNode
        CheckBirdNode checkBirdNode = new CheckBirdNode(1f, LayerMask.GetMask("Bird"));



        //land --> MoveToward 




        // Create a sequence node to fly, then land, then wait
        SequenceOrder sequence = new SequenceOrder(new List<Node> { flyNode, landNode, waitNode, flyNode });

        // Return the root node
        return sequence;
    }
}