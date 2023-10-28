using System.Collections.Generic;
using BehaviorTree;
using UnityEngine;

public class BirdAI : BehaviorTree.Tree
{
    public float speed = 1f;
    public float checkRadius; // Radius for checking birds
    public LayerMask birdLayer; // Layer on which the birds are
    public GameObject[] landingSpots;
    public bool isLanding = false;
    public GameObject LandSpot;
    private void Awake()
    {
        
    }

    protected override Node SetupTree()
    {
        // Create nodes for each behavior
        FlyNode flyNode = new FlyNode(this.gameObject, speed, 1f, 0.5f);
        LandNode landNode = new LandNode(this,this.gameObject, landingSpots, speed);
        WaitNode waitNode = new WaitNode(3f);

        // Create a selector node to choose between flying and landing

        // Create a CheckBirdNode   
        CheckBirdNode checkBirdNode = new CheckBirdNode(this,this.gameObject,0.1f, LayerMask.GetMask("Bird"),landingSpots);

        SequenceOrder LandDing = new SequenceOrder(new List<Node> { landNode, waitNode });

        Sequence checkBird = new Sequence(new List<Node> { checkBirdNode,LandDing });

        //land --> MoveToward 




        // Create a sequence node to fly, then land, then wait
        Selector sequence = new Selector(new List<Node> {checkBird ,flyNode});
        SequenceOrder order = new SequenceOrder(new List<Node> { flyNode, sequence });

        // Return the root node
        return order;
    }
}