using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    [SerializeField, Range(0f, 10f)] private float _jumpHeight = 3f;
    [SerializeField, Range(0, 5)] private int _maxAirJumps = 0;
    [SerializeField, Range(0f, 5f)] private float _downwardMovementMultiplier = 3f;
    [SerializeField, Range(0f, 5f)] private float _upwardMovementMultiplier = 1.7f;
    [SerializeField, Range(0f, 0.3f)] private float _coyoteTime = 0.2f;
    [SerializeField, Range(0f, 0.3f)] private float _jumpBufferTime = 0.2f;


    public Controller _controller;
    private Rigidbody2D _body;
    private CollisionDataRecieve _ground;
    public Vector2 _velocity;

    private int _jumpPhase;
    public float _defaultGravityScale, _jumpSpeed, _coyoteCounter, _jumpBufferCounter;

    public bool _desiredJump, _onGround, isJumping;
    public bool doubleJump = true;

    public Animator animator;
    // Start is called before the first frame update
    void Awake()
    {
        _body = GetComponent<Rigidbody2D>();
        _ground = GetComponent<CollisionDataRecieve>();
        _controller = GetComponent<Controller>();

        _defaultGravityScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        _desiredJump |= _controller.input.RetrieveJumpInput();
    }

    private void FixedUpdate()
    {
        _onGround = _ground.OnGround;
        _velocity = _body.velocity;

        if (_onGround)// && _body.velocity.y ==0)
        {
            doubleJump = true;
            _jumpPhase = 0;
            _coyoteCounter = _coyoteTime;
            isJumping = false;
        }
        else
        {
            _coyoteCounter -= Time.deltaTime;
        }

        if (_desiredJump)
        {
            _desiredJump = false;
            _jumpBufferCounter = _jumpBufferTime;

        }
        else if (_desiredJump && _jumpBufferCounter > 0)
        {
            _jumpBufferCounter -= Time.deltaTime;
        }

        if (_jumpBufferCounter > 0)
            JumpAction();

        if (_controller.input.RetrieveJumpHoldInput() && _body.velocity.y > 0)
        {
            _body.gravityScale = _upwardMovementMultiplier;
            animator.SetBool("isJumping", true);
        }
        else if (!_controller.input.RetrieveJumpHoldInput() || _body.velocity.y < 0)
        {
            _body.gravityScale = _downwardMovementMultiplier;
            animator.SetBool("isJumping", false);
        }
        else if (_body.velocity.y == 0)
        {
            _body.gravityScale = _defaultGravityScale;
        }

        _body.velocity = _velocity;

    }
    private void JumpAction()
    {

        if (_coyoteCounter >= 0 || (_jumpPhase < _maxAirJumps && isJumping) || doubleJump)
        {
            if (doubleJump) doubleJump = !doubleJump;
            if (isJumping)
            {
                _jumpPhase += 1;
            }

            _jumpBufferCounter = 0;
            _coyoteCounter = 0;
            _jumpSpeed = Mathf.Sqrt(-2f * Physics2D.gravity.y * _jumpHeight * _upwardMovementMultiplier);
            isJumping = true;

            if (_velocity.y > 0f)
            {
                _jumpSpeed = Mathf.Max(_jumpSpeed - _velocity.y, 0f);
            }
            else if (_velocity.y < 0f)
            {
                _jumpSpeed += Mathf.Abs(_body.velocity.y);
            }
            _velocity.y += _jumpSpeed;

        }
    }
}
