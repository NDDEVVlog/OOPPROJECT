using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectileScript : MonoBehaviour
{
    private GameObject Character;
    private Rigidbody2D rb;
    public float force;
    public float timer;
    public float upwardForce; // This is the upward force that will give the projectile a parabolic trajectory

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Character = GameObject.FindGameObjectWithTag("Character");

        Vector3 direction = Character.transform.position - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;

        float rotation = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotation + 90);

        // Add an upward force to the projectile
        rb.AddForce(transform.up * upwardForce, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > 10)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Character"))
        {
            Destroy(gameObject);
        }
    }
}

