using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoForward : MonoBehaviour
{
    [SerializeField] float speed = 20, BulletLifeTime = 4, damage;
    [SerializeField] Collider2D Collider;
    Rigidbody2D RB;

    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        RB.AddForce(transform.up * speed, ForceMode2D.Impulse);
        Destroy(gameObject, BulletLifeTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Collider.enabled = false;
        if (collision.gameObject.GetComponent<Health>())
        {
            Health Healthscript = collision.gameObject.GetComponent<Health>();
            Healthscript.health -= damage;
        }
        Destroy(gameObject, 0);
    }
}
