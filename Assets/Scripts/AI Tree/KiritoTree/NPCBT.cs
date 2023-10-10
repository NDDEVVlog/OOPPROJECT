using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;
using Pathfinding;
public class NPCBT : MonoBehaviour
{
    [Header("PathFinder")]
    public Transform target;
    public float activateDistance=50f;
    public float pathUpdateSeconds = 0.5f;
    [Header("Physics")]
    public float nextWayPointDistance = 3f;
    public float jumpNodeHeightRequirement = 0.8f;
    public float jumpModifier = 0.3f;
    public float jumpCheckOffset=0.1f;

    [Header("CustomBehaivor")]
    public bool followEnabled = true;
    public bool jumpEnabled = true;
    public bool directionLookEnabled = true;

    private Path path;
    private int currentWaypoint = 0;
    CollisionDataRecieve collisionDataRecieve;
    Seeker seeker;
    public KiritoFakeAIController controller;
    

    public void Awake()
    {
        seeker = GetComponent<Seeker>();
        
        collisionDataRecieve = GetComponent<CollisionDataRecieve>();
        InvokeRepeating("UpdatePath", 0f, pathUpdateSeconds);

    }
    private void FixedUpdate()
    {
        if(TargetInDistance() && followEnabled)
        {
            PathFollow();
        }
    }
    private void UpdatePath()
    {
        if(followEnabled && TargetInDistance()&& seeker.IsDone())
        {
                seeker.StartPath(transform.position, target.position, OnPathComplete);
        } 
       
    }
    private void PathFollow()
    {
        if (path == null)
        {
            return;
        }

        // Reached end of path
        if (currentWaypoint >= path.vectorPath.Count)
        {
            return;
        }
        // Direction Calculation
        int directionX = ((Vector2)path.vectorPath[currentWaypoint] - (Vector2)transform.position).normalized.x < 0 ? -1 : 1;
        controller.xValue = directionX;
        /*
        // See if colliding with anything
        startOffset = transform.position - new Vector3(0f, GetComponent<Collider2D>().bounds.extents.y + jumpCheckOffset, transform.position.z);
        isGrounded = Physics2D.Raycast(startOffset, -Vector3.up, 0.05f);

        ;*/

        // Jump
        /*if (jumpEnabled && isGrounded && !isInAir && !isOnCoolDown)
        {
            if (direction.y > jumpNodeHeightRequirement)
            {
                if (isInAir) return;
                isJumping = true;
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                StartCoroutine(JumpCoolDown());

            }
        }
        if (isGrounded)
        {
            isJumping = false;
            isInAir = false;
        }
        else
        {
            isInAir = true;
        }*/

        // Movement

       

        // Next Waypoint
        float distance = Vector2.Distance(transform.position, path.vectorPath[currentWaypoint]);
        if (distance < nextWayPointDistance)
        {
            currentWaypoint++;
        }
        
        // Direction Graphics Handling
        
    }

    private bool TargetInDistance()
    {
        return Vector2.Distance(transform.position, target.transform.position) < activateDistance;
    }

    private void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }
    /*protected  override Node SetupTree()
    {
        Node root;
        return null;
    }*/
}
