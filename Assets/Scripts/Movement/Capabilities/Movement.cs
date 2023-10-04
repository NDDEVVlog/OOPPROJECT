using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Movement : MonoBehaviour
{

    [SerializeField, Range(0f, 100f)] private float _maxSpeed = 4f;
    [SerializeField, Range(0f, 100f)] private float _maxAcceleration = 35f;
    [SerializeField, Range(0f, 100f)] private float _maxAirAcceleration = 20f;
    [SerializeField, Range(0f, 100f)] private float _maxDeceleration = 35f;
    [SerializeField, Range(0f, 100f)] private float _maxAirDeceleration = 20f;
    [SerializeField, Range(0f, 100f)] private float maxTurnSpeed = 35f;
    [SerializeField, Range(0f, 100f)] private float maxAirTurnSpeed = 20f;



    public Controller _controller;
    public Vector2 _direction, _desiredVelocity, _velocity;
    private Rigidbody2D _body;
    private CollisionDataRecieve collisionData;
    public Animator animator;

    private float _maxSpeedChange, _acceleration;
    private float _deceleration, turnSpeed;
    private bool _onGround;



   // private WallInteractor WallInteractor;

    private void Awake()
    {
        _body = GetComponent<Rigidbody2D>();
        collisionData = GetComponent<CollisionDataRecieve>();
        _controller = GetComponent<Controller>();
        //WallInteractor = GetComponent<WallInteractor>();
        //if(GetComponent<Animator>()!=null)
        //animator = GetComponent<Animator>();
    }
    private void Update()
    {
        _direction.x = _controller.input.RetrieveMoveInput();


        _desiredVelocity = new Vector2(_direction.x, 0f) * Mathf.Max(_maxSpeed - collisionData.Friction, 0f);
        animator.SetFloat("Speed", Mathf.Abs(_direction.x));
    }
    private void FixedUpdate()
    {
        _onGround = collisionData.OnGround;

        //first get the velocity x,y
        _velocity = _body.velocity;

        //Check change data if play not on Air
        _acceleration = _onGround ? _maxAcceleration : _maxAirAcceleration;
        _deceleration = _onGround ? _maxDeceleration : _maxAirDeceleration;
        turnSpeed = _onGround ? maxTurnSpeed : maxAirTurnSpeed;

        //Adjust the velocity in horizontal 
        if (_direction.x != 0)
        {
            if (Mathf.Sign(_direction.x) != Mathf.Sign(_velocity.x))
            {
                _maxSpeedChange = turnSpeed * Time.deltaTime;
            }
            else
            {
                _maxSpeedChange = _acceleration * Time.deltaTime;
            }
        }
        else
        {
            _maxSpeedChange = _deceleration * Time.deltaTime;
        }
        _maxSpeedChange = _acceleration * Time.deltaTime;




        _velocity.x = Mathf.MoveTowards(_velocity.x, _desiredVelocity.x, _maxSpeedChange);

        _body.velocity = _velocity;


    }
}
