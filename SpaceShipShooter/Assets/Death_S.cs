using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death_S : MonoBehaviour
{
    public float TimeTillDeath;
    public bool CanMove = true;
    Rigidbody2D RB;
    Health health_s;
    [SerializeField] GameObject Explosion;
    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        health_s = GetComponent<Health>();
    }

    public void Died ()
    {
        Destroy(gameObject, TimeTillDeath);
        CanMove = false;
        health_s.enabled = false;
        foreach (Collider2D c in GetComponents<Collider2D>())
        {
            c.enabled = false;
        }
        //Destroy(Explosion, TimeTillDeath);
        RB.angularDrag = 129;
        RB.drag = 9;
        Explosion.SetActive(true);
    }
}
