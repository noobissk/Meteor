using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] Rigidbody2D RB;
    [SerializeField] float speed = 10;
    [SerializeField] int dashTimer = 3;
    float InputV;
    bool CanDash;


    void Update()
    {
        Inputs();
    }

    void FixedUpdate()
    {
        RB.AddForce(InputV * transform.up * speed, ForceMode2D.Force);
    }


    void Inputs()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && CanDash)
        {
            RB.AddForce(transform.up * 5, ForceMode2D.Impulse);
            CanDash = false;
            StartCoroutine(DashTimer());
        }
        InputV = Input.GetAxisRaw("Vertical");
    }

    IEnumerator DashTimer()
    {
        yield return new WaitForSeconds(dashTimer);
    }
}
