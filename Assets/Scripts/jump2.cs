using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jump2 : MonoBehaviour
{
    private Rigidbody2D playerRb;
    private CollisionDataRecieve collisiondataretrieve;
    // Start is called before the first frame update
    public Animator animator;
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }
    private void Awake()
    {
        animator = GetComponent<Animator>();
        collisiondataretrieve = GetComponent<CollisionDataRecieve>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) 
        {   
            animator.SetBool("isJumping", true);
            playerRb.AddForce(Vector2.up * 250);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            animator.SetBool("isJumping", false);
        }
    }
}
