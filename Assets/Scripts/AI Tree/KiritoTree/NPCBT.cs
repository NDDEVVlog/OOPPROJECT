using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;
using Pathfinding;
using Sirenix.OdinInspector;
public class NPCBT : MonoBehaviour
{
    [Header("PathFinder")]
    public Transform target;
    public float activateDistance=50f;
    public float pathUpdateSeconds = 0.5f;

    [Space(5)]

    #region DijKstra
    [FoldoutGroup("DijKstra")]
    public DijKstraGraph dijKstraGraph;
    [FoldoutGroup("DijKstra")]
    public List<Vertex> vertexList;
    [FoldoutGroup("DijKstra")]

    public Vertex npcVertex;
    [FoldoutGroup("DijKstra")]

    public Vertex endpoint;
    public List<Transform> vertexTarget ;
    public Transform verTar;
    int numVerList = 0;


    #endregion
    [Space(5)]
    #region GroupPhysic
    [FoldoutGroup("Physic")]
    [Header("Physics")]
    public float nextWayPointDistance = 3f;
    [FoldoutGroup("Physic")]

    public float jumpNodeHeightRequirement = 0.8f;
    [FoldoutGroup("Physic")]

    public float jumpModifier = 0.3f;
    [FoldoutGroup("Physic")]

    public float jumpCheckOffset=0.1f;
    #endregion
    [Space(5)]

    #region CustomBehavior
    [FoldoutGroup("CustomBehavior")]
    [Header("CustomBehaivor")]
    [FoldoutGroup("CustomBehavior")]
    public bool followEnabled = true;
    [FoldoutGroup("CustomBehavior")]
    public bool jumpEnabled = true;
    [FoldoutGroup("CustomBehavior")]
    public bool directionLookEnabled = true;
    #endregion


    private Path path;
    private int currentWaypoint = 0;
    CollisionDataRecieve collisionDataRecieve;
    Seeker seeker;
    public AIController controller;

    private void Start()
    {
        ChangeTarget();
        UpdateVertexTarget();
    }

    public void Awake()
    {   
        
        seeker = GetComponent<Seeker>();
        dijKstraGraph = FindObjectOfType<DijKstraGraph>().GetComponent<DijKstraGraph>();
        collisionDataRecieve = GetComponent<CollisionDataRecieve>();
        InvokeRepeating("UpdatePath", 0f, pathUpdateSeconds);

    }
    private void UpdateVertexTarget()
    {
        verTar = vertexTarget[numVerList];

        if (numVerList < vertexTarget.Count)
        {
            numVerList++;
        }
        else
        {
            numVerList = 0;
        }
    }
    private void FixedUpdate()
    {
        if (Vector2.Distance(transform.position, verTar.position) > 0.1f)
        {
            if (TargetInDistance() && followEnabled)
            {
                PathFollow();
            }
        }
        else
        {
            controller.xValue = 0;
            ChangeTarget();
            UpdateVertexTarget();
        }
    }
    
    private void UpdatePath()
    {
        

        
        if(followEnabled && TargetInDistance()&& seeker.IsDone())
        {
            seeker.StartPath(transform.position, verTar.position, OnPathComplete);
            
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
        #region Comment
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

        #endregion

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
        return Vector2.Distance(transform.position, verTar.transform.position) < activateDistance;
    }

    bool IsGetToTarget()
    {
        return Vector2.Distance(transform.position, target.position) < 0.1f;
    }

    private void OnPathComplete(Path p)
    {   
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }
    void ChangeTarget()
    {   
        FindNearestPath();
        FindNearestVertex(target);  
        foreach(Vertex i in vertexList)
        {
            vertexTarget.Add(i.transform);
        }
        vertexTarget.Add(target);
    }
    [Button("FindNearestVertex")]

    void FindNearestVertex(Transform target)
    {
        Vertex[] allVertexInMap = FindObjectsOfType<Vertex>();

        Vertex nearestVertex = allVertexInMap[0];

        foreach (Vertex a in allVertexInMap)
        {
            if(Vector2.Distance(target.position,a.transform.position) <= Vector2.Distance(target.position, nearestVertex.transform.position))
            {
                nearestVertex = a;
            }
        }
        endpoint = nearestVertex;
        FindShorstestDijkstraPath();
    }
    [Button("FindNearestDijkstraPath")]
    void FindNearestPath()
    {   
        Vertex[] allVertexInMap = FindObjectsOfType<Vertex>();

        List<Vertex> listVer = new List<Vertex>();
 
        foreach (Vertex a in allVertexInMap)
        {
            if (Vector2.Distance(transform.position, a.transform.position) < 2.5f)
            {
                listVer.Add(a);
            }
        }
        npcVertex.connections = listVer;  
    }
    [Button("FindShortestDijkstraPath")]      
    void FindShorstestDijkstraPath()
    {
        vertexList = dijKstraGraph.GetShortestPath(npcVertex,endpoint).nodes;
        vertexList.Remove(npcVertex);
        Debug.Log(vertexList);
    }
}
