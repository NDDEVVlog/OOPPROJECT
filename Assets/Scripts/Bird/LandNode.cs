using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

public class LandNode : Node
{
    private Bird bird;
    private GameObject[] landingSpots;
    private float speed;
    private GameObject lastLandingSpot;
    private static List<GameObject> occupiedSpots = new List<GameObject>();

    public LandNode(Bird bird, GameObject[] landingSpots, float speed)
    {
        this.bird = bird;
        this.landingSpots = landingSpots;
        this.speed = speed;
    }

    public override NodeState Evalute()
    {
        // If the bird is not already landing, choose a new spot
        if (!bird.IsLanding)
        {
            GameObject landingSpot;
            do
            {
                landingSpot = landingSpots[Random.Range(0, landingSpots.Length)];
            } while (landingSpot == lastLandingSpot || occupiedSpots.Contains(landingSpot)); // Keep choosing until an unoccupied spot is found

            lastLandingSpot = landingSpot; // Remember the chosen spot
            bird.IsLanding = true; // Set the bird's state to landing
            occupiedSpots.Add(landingSpot); // Add the spot to the list of occupied spots
            bird.CurrentLandingSpot = landingSpot; // Set the current landing spot for the bird
        }

        // Check if bird.CurrentLandingSpot is not null before accessing its position
        if (bird.CurrentLandingSpot != null)
        {
            // Move the bird to the current landing spot over time instead of teleporting instantly
            float step = speed * Time.deltaTime;
            bird.transform.position = Vector3.MoveTowards(bird.transform.position, bird.CurrentLandingSpot.transform.position, step);

            if (Vector3.Distance(bird.transform.position, bird.CurrentLandingSpot.transform.position) < 0.001f)
            {
                bird.IsLanding = false; // Reset the bird's state to not landing
                occupiedSpots.Remove(bird.CurrentLandingSpot); // Remove the spot from the list of occupied spots
                return NodeState.SUCCESS; // Return SUCCESS when the bird has landed
            }
        }

        return NodeState.RUNNING; // Keep running this node until the bird has landed
    }
}

