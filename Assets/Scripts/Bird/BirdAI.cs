using System.Collections.Generic;
using BehaviorTree;
using UnityEngine;

public class BirdAI : BehaviorTree.Tree
{
    private Bird bird;

    private void Awake()
    {
        bird = GetComponent<Bird>();
    }

    protected override Node SetupTree()
    {
        // Create nodes for each behavior
        FlyNode flyNode = new FlyNode(bird, 5f);
        LandNode landNode = new LandNode(bird, bird.landingSpots);
        WaitNode waitNode = new WaitNode(bird, 3f, this);

        // Create a selector node to choose between flying and landing
        Selector flyOrLand = new Selector(new List<Node> { flyNode, landNode });
        //  --> Node Check position has bird or not  ( Physic2D.OverLapShpere) ->Check overlap has tag (bird)
        //land --> MoveToward 
        //



        // Create a sequence node to fly, then land, then wait
        Selector sequence = new Selector(new List<Node> { landNode, waitNode, flyNode });

        // Return the root node
        return sequence;
    }
}