using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

public class TaskPatrol : Node
{
    [Header("Interaction")]
    [SerializeField] private LayerMask _layerMask = -1;
    [Header("Ray")]
    [SerializeField] private float _bottomDistance = 0.1f;
    [SerializeField] private float _topDistance = 0.1f;
    [SerializeField] private float _xOffset = 0.25f;
    float _xDirection = 1;
    private GameObject OwnTaskObject;
    private AIController _controller;
    //private PlayerStateMachine stateMachineAI;
    private float _WaitTime = 2f;
    private float _WaitCounter = 0f;

    private RaycastHit2D _groundInfoBottom;
    private RaycastHit2D _groundInfoTop;
    //must have function
    public TaskPatrol(LayerMask layer , float bottom, float top, GameObject ob,AIController controller)
    {
        _bottomDistance = bottom;
        _layerMask = layer;
        _topDistance = top;
        OwnTaskObject = ob;
        _controller = controller;
       // stateMachineAI = stateMachine;
    }

    public override NodeState Evalute()
    {
        _groundInfoBottom = Physics2D.Raycast(new Vector2(OwnTaskObject.transform.position.x + (_xOffset * _xDirection),
                OwnTaskObject.transform.position.y), Vector2.down, _bottomDistance, _layerMask);
        Debug.DrawRay(new Vector2(OwnTaskObject.transform.position.x + (_xOffset * _xDirection), OwnTaskObject.transform.position.y),
            Vector2.down * _bottomDistance, Color.green,0,false);

        _groundInfoTop = Physics2D.Raycast(new Vector2(OwnTaskObject.transform.position.x + (_xOffset * _xDirection),
            OwnTaskObject.transform.position.y), Vector2.right * _xDirection, _topDistance, _layerMask);
        Debug.DrawRay(new Vector2(OwnTaskObject.transform.position.x + (_xOffset * _xDirection), OwnTaskObject.transform.position.y),
            Vector2.right * _topDistance * _xDirection, Color.green,0,false);

        if ((_groundInfoTop.collider == true || _groundInfoBottom.collider == false))
        {
            _WaitCounter += Time.deltaTime;
            if (_WaitCounter >= _WaitTime)
            {

                _xDirection *= -1;
                //stateMachineAI.HandleFlip();
                _WaitCounter = 0;
                

                state = NodeState.SUCCESS;
                return state;
            }
            else
            {
                
                _controller.xValue = 0;
            }


            
            
        }
        else
            _controller.xValue = _xDirection;
            

        state = NodeState.RUNNING;
        return state;
    }
}
