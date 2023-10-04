using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
[RequireComponent(typeof(Rigidbody2D))]

public class Dash : MonoBehaviour
{
    Vector2 MoveInput;
    Rigidbody2D Rb;
    public float DashSpeed = 12f;

    public bool IsMoving { get; private set; }

    // Start is called before the first frame update

    private void Awake()
    {
        Rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Rb.velocity = new Vector2(MoveInput.x * DashSpeed * Time.fixedDeltaTime, Rb.velocity.y);
    }

    public void OnDash(InputAction.CallbackContext context)
    {
        MoveInput = context.ReadValue<Vector2>();

        IsMoving = MoveInput != Vector2.zero;


    }
}
