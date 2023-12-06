using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public Transform player;
    public Transform elevatorswitch;
    public Transform downpos;
    public Transform upperpos;
    //public SpriteRenderer elevator;

    public float speed;
    bool iselevatordown;

    private void Start()
    {

    }

    void Update()
    {
        StartElevator();
    }
    void StartElevator()
    {
        if (Vector2.Distance(player.position, elevatorswitch.position) < 0.5f || Input.GetKeyDown(KeyCode.E))
           
        {
            Debug.Log("NguyenDuy");
            if (transform.position.y <= downpos.position.y)
            {
                Debug.Log("Ditconmemaychaydi");
                iselevatordown = true;
            }
            else if (transform.position.y >= upperpos.position.y)
            {
                Debug.Log("Taometlamroi");
                iselevatordown = false;
            }
        }
        if (iselevatordown)
        {
            transform.position = Vector2.MoveTowards(transform.position, upperpos.position, speed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, downpos.position, speed * Time.deltaTime);
        }
    }
}