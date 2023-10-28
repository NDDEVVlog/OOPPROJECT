using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

public class FlyNode : Node
{
    private GameObject bird;
    private float speed;
    private float amplitude; // Amplitude of the sine wave
    private float frequency; // Frequency of the sine wave
    private float initialY; // Initial y position of the bird
    bool ChangePosition = true;
    float xCor;
    float yCor;

    private float flyTime=3f;
    private float flyTimeCounter = 0;

    float minFlyTime = 4f;
    float maxFlyTime = 10f;
    public bool isFacingRight = true;
    public bool IsFacingRight
    {
        get { return isFacingRight; }
        private set
        {
            if (isFacingRight != value)
            {
                bird.transform.localScale *= new Vector2(-1, 1);
            }
            isFacingRight = value;
        }
    }

    public FlyNode(GameObject bird, float speed, float amplitude, float frequency)
    {
        this.bird = bird;
        this.speed = speed;
        this.amplitude = amplitude;
        this.frequency = frequency;
        this.initialY = bird.transform.position.y; // Record the initial y position
    }

    public override NodeState Evalute()
    {   


        if (ChangePosition)
        {  
            float xCor = Random.Range(-25f, 25f);
            float yCor = initialY + amplitude * Mathf.Sin(frequency * xCor);
            SetData("xCor", xCor);
            SetData("yCor", yCor);

            ChangePosition = false;
        }
        xCor =(float) GetData("xCor");
        yCor = (float)GetData("yCor");


        //RandomPoistion in Range

        // Move the bird across the screen in a sine wave pattern




        //float yPosition = Mathf.Clamp( Mathf.Sin(frequency * Time.deltaTime),0.25f,1);
        //MoveToward TO POSITION

        bird.transform.position = Vector3.MoveTowards(bird.transform.position,new Vector3(xCor,yCor, bird.transform.position.z),10f*Time.deltaTime);
 
        //  Has an if (Bird == position ) 
        if(Vector2.Distance(bird.transform.position,new Vector2(xCor, yCor)) < 10f)
        {
            //Debug.Log("Change");
            ChangePosition = true;
            
        }
        var _direction = new Vector3(xCor, yCor, bird.transform.position.z) - bird.transform.position;
        if (_direction.x > 0 && !IsFacingRight)
        {
            //face the Right
            IsFacingRight = true;
        }
        else if (_direction.x < 0 && IsFacingRight)
        {
            //Face the left
            IsFacingRight = false;
        }

        // If the bird has reached the other side of the screen, return SUCCESS
        if (bird.transform.position.x > 30f)
        {
            bird.transform.position = new Vector3(0, bird.transform.position.y, bird.transform.position.z); // Reset position

            return NodeState.SUCCESS;
        }

        flyTimeCounter += Time.deltaTime;

        if (flyTimeCounter >= flyTime)
        {
            flyTimeCounter = 0; // Reset counter

            flyTime = Random.Range(minFlyTime,maxFlyTime); // Set next wait time

            return NodeState.SUCCESS;
        }

        // Otherwise, keep flying
        return NodeState.RUNNING;
    }
}