using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

public class CheckBirdNode : Node
{
    public float radius; // Radius of the overlap sphere
    public LayerMask birdLayer; // Layer on which the birds are

    public CheckBirdNode(float radius, LayerMask birdLayer)
    {
        this.radius = radius;
        this.birdLayer = birdLayer;
    }

    public override NodeState Evalute()
    {
        Vector2 position = (Vector2)GetData("position");
        if (position == null)
        {
            Debug.LogError("Position data not found");
            return NodeState.FAILURE;
        }

        Collider2D[] hits = Physics2D.OverlapCircleAll(position, radius, birdLayer);
        foreach (var hit in hits)
        {
            if (hit.CompareTag("Bird"))
            {
                Debug.Log("Bird detected at position: " + position);
                return NodeState.SUCCESS;
            }
        }

        return NodeState.FAILURE;
    }
}

