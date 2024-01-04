using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VaseScript : MonoBehaviour
{
    public GameObject explosionParticle;


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Character")
        {
            Instantiate(explosionParticle, transform.position, Quaternion.identity);
        }
    }
}
