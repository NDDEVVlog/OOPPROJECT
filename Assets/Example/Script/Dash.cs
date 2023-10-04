using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
[RequireComponent(typeof(Rigidbody2D))]

public class Dash : MonoBehaviour
{
    Vector2 MoveInput;
    Vector2 DashDir;
    Rigidbody2D Rb;
    public float DashSpeed = 12f;
    public float DashingTime = 0.5f;
    Controller controll;

    public bool IsMoving { get; private set; }
    public bool isDashing = false;
    public bool canDash = true;


    // Start is called before the first frame update

    private void Awake()
    {
        Rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        controll = GetComponent<Controller>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveInput.x = controll.input.RetrieveMoveInput();
        if (Input.GetKeyDown(KeyCode.C) && canDash)
        {
            Debug.Log("Dash");

            isDashing = true;
            canDash = false;
            DashDir = new Vector2(MoveInput.x, 0);
            if (DashDir == Vector2.zero)
            {
                DashDir = new Vector2(transform.localScale.x,0 );
            }
            StartCoroutine(StopDashing());
        }
    }

    private void FixedUpdate()
    {
        
        if (isDashing)
        {
            Rb.velocity = DashDir.normalized * DashSpeed;

        }

    }
    IEnumerator StopDashing()
    {
        yield return new WaitForSeconds(DashingTime);
        isDashing = false;
        canDash = true;
    }

    /*public void OnDash(InputAction.CallbackContext context)
    {
        MoveInput = context.ReadValue<Vector2>();

        IsMoving = MoveInput != Vector2.zero;


    }*/
}
