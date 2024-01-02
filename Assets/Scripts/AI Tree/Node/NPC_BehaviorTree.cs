using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;
using Pathfinding;
using Sirenix.OdinInspector;
public class NPC_BehaviorTree : BehaviorTree.Tree
{
    [Header("PathFinder")]
    public Transform target;
    public float activateDistance = 50f;
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
    public List<Transform> vertexTarget;
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

    public float jumpCheckOffset = 0.1f;
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

    public void Awake()
    {

        seeker = GetComponent<Seeker>();
        dijKstraGraph = FindObjectOfType<DijKstraGraph>().GetComponent<DijKstraGraph>();
        collisionDataRecieve = GetComponent<CollisionDataRecieve>();
        InvokeRepeating("UpdatePath", 0f, pathUpdateSeconds);

    }

    protected override Node SetupTree()
    {
        throw new System.NotImplementedException();
    }

    private void UpdatePath()
    {



        if (followEnabled && TargetInDistance() && seeker.IsDone())
        {
            seeker.StartPath(transform.position, verTar.position, OnPathComplete);

        }

    }
    private bool TargetInDistance()
    {
        return Vector2.Distance(transform.position, verTar.transform.position) < activateDistance;
    }
    private void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }
}
