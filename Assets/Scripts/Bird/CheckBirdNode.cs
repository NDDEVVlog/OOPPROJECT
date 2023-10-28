using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

public class CheckBirdNode : BehaviorTree.Node
{
    public float radius; // Radius of the overlap sphere
    public LayerMask birdLayer; // Layer on which the birds are
    public GameObject[] landSpots;
    public GameObject bird;
    public BirdAI aiBird;




    GameObject CurrentLandingSpot;


    public CheckBirdNode(BirdAI aiBird, GameObject bird,float radius, LayerMask birdLayer,GameObject[] landSpot)
    {
        this.radius = radius;
        this.birdLayer = birdLayer;
        this.landSpots = landSpot;
        this.bird = bird;
        this.aiBird = aiBird;
    }

    public override NodeState Evalute()
    {

        
        int spotIndex = Random.Range(0, landSpots.Length);
        CurrentLandingSpot = landSpots[spotIndex];
        if (aiBird.LandSpot == null)
        {

            
            Collider2D[] hits = Physics2D.OverlapCircleAll(CurrentLandingSpot.transform.position, radius, birdLayer);
            aiBird.LandSpot = CurrentLandingSpot;
            foreach (var hit in hits)
            {
                if (hit.CompareTag("Bird"))
                {
                    Debug.Log(bird.name + " fount that Bird detected at position: " + CurrentLandingSpot.transform.position);
                    aiBird.LandSpot = null;

                    Debug.Log("Check");
                    return NodeState.FAILURE;
                }
            }

            aiBird.LandSpot = CurrentLandingSpot;
            return NodeState.SUCCESS;
        }
        return NodeState.SUCCESS;
    }
}

