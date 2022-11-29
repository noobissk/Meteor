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

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.transform.gameObject.name);

        Health Healthscript = collision.gameObject.GetComponent<Health>();
        Healthscript.health -= damage;
        Destroy(gameObject, 0);
    }
}
