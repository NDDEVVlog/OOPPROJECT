using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorControlSystem : MonoBehaviour
{
    private int currentFloor;
    private bool isMovingUp;

    public ElevatorControlSystem()
    {
        currentFloor = 1;
        isMovingUp = true;
    }

    public void PressUpButton()
    {
        isMovingUp = true;
        MoveElevator();
    }

    public void PressDownButton()
    {
        isMovingUp = false;
        MoveElevator();
    }

    private void MoveElevator()
    {
        // Code to move the elevator up or down based on the current floor and direction
    }
}