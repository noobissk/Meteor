using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] Rigidbody2D RB;
    [SerializeField] float speed = 10;
    [SerializeField] int dashTimer = 3;
    float InputV, InputH;
    bool CanDash;


    void Update()
    {
        Inputs();
    }

    void FixedUpdate()
    {
        RB.AddForce(InputV * Vector2.up * speed, ForceMode2D.Force);
        RB.AddForce(InputH * Vector2.right * speed, ForceMode2D.Force);
    }


    void Inputs()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && CanDash)
        {
            RB.AddForce(transform.up * 5, ForceMode2D.Impulse);
            Debug.Log("It works??");
            CanDash = false;
            StartCoroutine(DashTimer());
        }


        InputV = Input.GetAxisRaw("Vertical");
        InputH = Input.GetAxisRaw("Horizontal");
    }

    IEnumerator DashTimer()
    {
        yield return new WaitForSeconds(dashTimer);
    }
}
