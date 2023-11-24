using System;
using System.Threading;
using UnityEngine;

namespace ElevatorStatus
{
    public class Program : MonoBehaviour
    {
        private const string QUIT = "q";

        public static void Main(string[] args)
        {
        Start:

            int floor;
            string floorInput;
            Elevator elevator;

            floorInput = Console.ReadLine();

            if (Int32.TryParse(floorInput, out floor))
                elevator = new Elevator(floor);
            else
            {
                Console.Beep();
                Thread.Sleep(2000);
                Console.Clear();
                goto Start;
            }

            string input = string.Empty;

            while (input != QUIT)
            {
                input = Console.ReadLine();
                if (Int32.TryParse(input, out floor))
                    elevator.FloorPress(floor);
            }
        }
    }

    public class Elevator
    {
        private bool[] floorReady;
        public int CurrentFloor = 1;
        private int topfloor;
        private ElevatorStatus status = ElevatorStatus.STOPPED;

        public ElevatorStatus Status { get => status; set => status = value; }

        public Elevator(int NumberOfFloors = 10)
        {
            floorReady = new bool[NumberOfFloors + 1];
            topfloor = NumberOfFloors;
        }

        private void Stop(int floor)
        {
            Status = ElevatorStatus.STOPPED;
            CurrentFloor = floor;
            floorReady[floor] = false;
            Console.WriteLine("This is {0}", floor);
        }

        private void Descend(int floor)
        {
            for (int i = CurrentFloor; i >= 1; i--)
            {
                if (floorReady[i])
                    Stop(floor);
                else
                    continue;
            }

            Status = ElevatorStatus.STOPPED;
            Console.WriteLine("Processing");
        }

        private void Ascend(int floor)
        {
            for (int i = CurrentFloor; i <= topfloor; i++)
            {
                if (floorReady[i])
                    Stop(floor);
                else
                    continue;
            }

            Status = ElevatorStatus.STOPPED;
            Console.WriteLine("Processing");
        }

        public void FloorPress(int floor)
        {
            if (floor > topfloor)
            {
                Console.WriteLine("Invalid floor request. The requested floor is greater than the top floor.");
                return;
            }

            // Rest of the code for handling valid floor requests
        }
    }

    public enum ElevatorStatus
    {
        STOPPED,
        MOVING_UP,
        MOVING_DOWN
    }
}
