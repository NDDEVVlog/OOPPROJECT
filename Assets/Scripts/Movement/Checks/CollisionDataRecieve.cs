using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDataRecieve : MonoBehaviour
{

    #region Note

    /*
     get; set; is basically rationalize the assign way follow OOP rule
    you can not assign like Duy.IQ value = 1400;(OOP rule cannot work without get; set;)
    but in unity it is find :V
     
     
     
     
     
     */

    #endregion


    public bool OnGround;

    public bool OnWall { get; private set; }

    public bool CheckCeiling { get; private set; }

    public float Friction { get; private set; }

    public Vector2 ContactNormal { get; private set; }
    private PhysicsMaterial2D _material;

    private void OnCollisionExit2D(Collision2D collision)
    {
        OnGround = false;
        Friction = 0;
        OnWall = false;
        CheckCeiling = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        EvaluateCollision(collision);
        RetrieveFriction(collision);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        EvaluateCollision(collision);
        RetrieveFriction(collision);
    }

    private void EvaluateCollision(Collision2D collision)
    {
        //check the collision beneath player 
        for (int i = 0; i < collision.contactCount; i++)
        {
            
            ContactNormal = collision.GetContact(i).normal;
            OnGround |= ContactNormal.y >= 0.9f;
            if (OnGround) Debug.Log("Hello");
            OnWall = Mathf.Abs(ContactNormal.x) >= 0.9f;
            CheckCeiling |= ContactNormal.y >= 2f;
        }
    }

    private void RetrieveFriction(Collision2D collision)
    {
        //Take the friction value of collision in Rigidbody

        _material = collision.rigidbody.sharedMaterial;



        Friction = 0;

        if (_material != null)
        {
            Friction = _material.friction;
        }
    }
}
