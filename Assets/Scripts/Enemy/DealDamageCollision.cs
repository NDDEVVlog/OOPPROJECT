using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDamageCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject);
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<HealthComponent>().TakeDamage(25f, this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<HealthComponent>().TakeDamage(25f, this.gameObject);
        }
    }
}
