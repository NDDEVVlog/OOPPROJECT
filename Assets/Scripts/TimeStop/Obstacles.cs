using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<timestop>().StopTime(0.05f, 10, 0.01f);
            Debug.Log("You hit obstacles");
        }
    }
}
//use this on obstacles or enemies to trigger timestop