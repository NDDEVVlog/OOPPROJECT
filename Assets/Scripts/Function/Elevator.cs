using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    
    public Transform downPos;
    public Transform upperPos;

    public float speed;

    private bool isElevatorDown;

    private void Update()
    {
        StartElevator();
    }

    void StartElevator()
    {

        if (isElevatorDown)
        {
            transform.position = Vector2.MoveTowards(transform.position, upperPos.position, speed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, downPos.position, speed * Time.deltaTime);
        }
    }

    // Observer Pattern
    /*public void ObserveInteractable(InteractableHealthComponent interactable)
    {
        interactable.OnTakeDamage = ReactToDamage;
    }*/
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.parent = this.gameObject.transform;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.parent = null;
        }
    }
    public void ReactToDamage()
    {
        // You can adjust the threshold as needed
       
            ToggleElevatorDirection();
        
    }

    private void ToggleElevatorDirection()
    {
        isElevatorDown = !isElevatorDown;
    }
}