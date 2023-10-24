using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

public class CheckBirdNode : BehaviorTree.Node
{
    public float radius; // Radius of the overlap sphere
    public LayerMask birdLayer; // Layer on which the birds are
    public GameObject[] landSpots;
    public CheckBirdNode(float radius, LayerMask birdLayer,GameObject[] landSpot)
    {
        this.radius = radius;
        this.birdLayer = birdLayer;
        this.landSpots = landSpot;
    }

    public override NodeState Evalute()
    {
        /*Vector2 position = (Vector2)GetData("position");
        if (position == null)
        {
            Debug.LogError("Position data not found");
            return NodeState.FAILURE;
        }*/

        int spotIndex = Random.Range(0, landSpots.Length);
        Collider2D[] hits = Physics2D.OverlapCircleAll(landSpots[spotIndex].transform.position, radius, birdLayer);
        foreach (var hit in hits)
        {
            if (hit.CompareTag("Bird"))
            {
                Debug.Log("Bird detected at position: " + landSpots[spotIndex].transform.position);
                SetData("LandingSpot", landSpots[spotIndex].transform.position);
                Debug.Log("Check");
                return NodeState.FAILURE;
            }
        }
        

        return NodeState.SUCCESS;
    }
}

