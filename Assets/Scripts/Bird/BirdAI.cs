using System.Collections.Generic;
using BehaviorTree;
using UnityEngine;

public class BirdAI : BehaviorTree.Tree
{

    public float checkRadius; // Radius for checking birds
    public LayerMask birdLayer; // Layer on which the birds are
    public GameObject[] landingSpots;
    bool isLanding = false;
    private void Awake()
    {
        
    }

    protected override Node SetupTree()
    {
        // Create nodes for each behavior
        FlyNode flyNode = new FlyNode(this.gameObject, 5f, 1f, 0.5f);
        LandNode landNode = new LandNode(this.gameObject, landingSpots, 5f, isLanding);
        WaitNode waitNode = new WaitNode(3f, this);

        // Create a selector node to choose between flying and landing

        // Create a CheckBirdNode   
        CheckBirdNode checkBirdNode = new CheckBirdNode(1f, LayerMask.GetMask("Bird"),landingSpots);

        SequenceOrder LandDing = new SequenceOrder(new List<Node> { landNode, waitNode });

        SequenceOrder checkBird = new SequenceOrder(new List<Node> { checkBirdNode,LandDing });

        //land --> MoveToward 




        // Create a sequence node to fly, then land, then wait
        Selector sequence = new Selector(new List<Node> {checkBird ,flyNode});
        SequenceOrder order = new SequenceOrder(new List<Node> { flyNode, sequence });

        // Return the root node
        return order;
    }
}