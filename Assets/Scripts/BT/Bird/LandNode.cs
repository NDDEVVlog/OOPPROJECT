using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

public class LandNode : Node
{
    private GameObject bird;
    private GameObject[] landingSpots;
    private float speed;
    private GameObject lastLandingSpot;
    GameObject CurrentLandingSpot;
    private List<GameObject> occupiedSpots = new List<GameObject>();
    BirdAI aiBird;
    public bool isFacingRight = true;
    
    public LandNode(BirdAI aiBird,GameObject bird, GameObject[] landingSpots, float speed)
    {
        this.bird = bird;
        this.landingSpots = landingSpots;
        this.speed = speed;
        this.aiBird = aiBird;

    }

    public override NodeState Evalute()
    {

        // If the bird is not already landing, choose a new spot

        

        CurrentLandingSpot = aiBird.LandSpot;

        // Check if bird.CurrentLandingSpot is not null before accessing its position
        if (CurrentLandingSpot != null)
        {
            // Move the bird to the current landing spot over time instead of teleporting instantly
            float step = speed * Time.deltaTime;
            bird.transform.position = Vector3.MoveTowards(bird.transform.position, CurrentLandingSpot.transform.position, step);
            var _direction = CurrentLandingSpot.transform.position - bird.transform.position;
            if (_direction.x > 0 && !aiBird.IsFacingRight)
            {
                //face the Right
                aiBird.IsFacingRight = true;
            }
            else if (_direction.x < 0 && aiBird.IsFacingRight)
            {
                //Face the left
                aiBird.IsFacingRight = false;
            }
            if (Vector3.Distance(bird.transform.position, CurrentLandingSpot.transform.position) < 0.001f)
            {
                bird.GetComponent<Animator>().SetBool("Fly", false);
                aiBird.LandSpot = null;
                aiBird.isLanding = false; // Reset the bird's state to not landing
               // occupiedSpots.Remove(CurrentLandingSpot); // Remove the spot from the list of occupied spots
                return NodeState.SUCCESS; // Return SUCCESS when the bird has landed
            }
        }



        return NodeState.RUNNING; // Keep running this node until the bird has landed
    }
}

