using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public float speed = 5f; // The speed at which the bird flies.
    public GameObject[] landingSpots; // An array of possible landing spots.
    public float minWaitTime = 1f; // The minimum amount of time the bird will wait at a spot.
    public float maxWaitTime = 5f; // The maximum amount of time the bird will wait at a spot.


    private Vector3 targetPosition; // The current target position (either a landing spot or the other side of the screen).
    private bool isFlying = true; // Whether the bird is currently flying.

    private void Start()
    {
        // Set the initial target position to the other side of the screen.
        targetPosition = new Vector3(Screen.width, transform.position.y, transform.position.z);
    }

    private void Update()
    {
        if (isFlying)
        {
            // Move towards the target position.
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

            // If the bird has reached its target position...
            if (transform.position == targetPosition)
            {
                // If the bird was flying, choose a random landing spot and set isFlying to false.
                if (isFlying)
                {
                    targetPosition = landingSpots[Random.Range(0, landingSpots.Length)].transform.position;
                    isFlying = false;
                }
                // If the bird was not flying, set the target position to the other side of the screen and set isFlying to true.
                else
                {
                    targetPosition = new Vector3(Screen.width, transform.position.y, transform.position.z);
                    isFlying = true;
                }
            }
        }
        else
        {
            // If the bird is not flying, wait for a random amount of time before setting isFlying to true.
            StartCoroutine(Wait(Random.Range(minWaitTime, maxWaitTime)));
        }
    }

    private IEnumerator Wait(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        isFlying = true;
    }
}
