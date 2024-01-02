using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    public float radius;
    [Range(0,360)]
    public float angle;

    public GameObject playerRef;
    public LayerMask targetMask;
    public LayerMask obstructionMask;

    public bool canSeePlayer;

    public Controller controller;
    public float xDirection = 1;

    private void Start()
    {
        playerRef = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(FOVRoutine());
       // controller = GetComponent<Control.Controller>();
    }
    private IEnumerator FOVRoutine()
    {
        WaitForSeconds wait = new WaitForSeconds(0.2f);
        while (true)
        {
            yield return wait;
            FieldOfViewCheck();
        }
    }
    private void Update()
    {   
        if(controller.input.RetrieveMoveInput() != 0)
        xDirection = controller.input.RetrieveMoveInput();

    }
    private void FieldOfViewCheck()
    {
        Collider2D[] rangeCheck = Physics2D.OverlapCircleAll(transform.position, radius, targetMask);
        if(rangeCheck.Length != 0)
        {
            Transform target = rangeCheck[0].transform;
            
            Vector3 directionToTarget = (target.position - transform.position).normalized;

            if (Vector2.Angle(transform.right*xDirection, directionToTarget) < (angle / 2))
            {

                Vector3 direct = target.position - transform.position;
                float DistancesToTarget = Vector2.Distance(transform.position, target.position);
                Debug.DrawLine(transform.position, target.position, Color.blue, 0.2f);

                RaycastHit2D hit2D = Physics2D.Raycast(transform.position, direct, DistancesToTarget, obstructionMask);

                if (!hit2D)
                {
                    Debug.Log(target);

                    Debug.DrawLine(transform.position, target.position, Color.red, 0.2f);
                    canSeePlayer = true;
                }
                else
                    canSeePlayer = false;
            }
            else
                canSeePlayer = false;
        }
        else if(canSeePlayer)
        {
            canSeePlayer = false;
        }
    }
}
