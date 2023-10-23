using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

public class FlyNode : Node
{
    private Bird bird;
    private float speed;
    private float amplitude; // Amplitude of the sine wave
    private float frequency; // Frequency of the sine wave
    private float initialY; // Initial y position of the bird

    public FlyNode(Bird bird, float speed, float amplitude, float frequency)
    {
        this.bird = bird;
        this.speed = speed;
        this.amplitude = amplitude;
        this.frequency = frequency;
        this.initialY = bird.transform.position.y; // Record the initial y position
    }

    public override NodeState Evalute()
    {

        //MoveToward TO POSITION

        //RandomPoistion in Range

        // Move the bird across the screen in a sine wave pattern
        bird.transform.position += Vector3.right * speed * Time.deltaTime;

        // Calculate phase shift based on time
        float yPosition = initialY + amplitude * Mathf.Sin(frequency * Time.time);

        bird.transform.position = new Vector3(bird.transform.position.x, yPosition, bird.transform.position.z);

        //  Has an if (Bird == position ) 


        // If the bird has reached the other side of the screen, return SUCCESS
        if (bird.transform.position.x > 30f)
        {
            bird.transform.position = new Vector3(0, bird.transform.position.y, bird.transform.position.z); // Reset position
            return NodeState.SUCCESS;
        }

        // Otherwise, keep flying
        return NodeState.RUNNING;
    }
}