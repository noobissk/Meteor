using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    [SerializeField] Rigidbody2D RB;
    [SerializeField] float speed = 10;
    [SerializeField] int dashTimer = 3;
    [SerializeField] Image Dash_RD;
    float InputV, InputH;
    [SerializeField] bool CanDash;


    void Update()
    {
        Inputs();
        UI();
    }
    void UI()
    {
        if (CanDash)
        {
            Dash_RD.color = Color.green;
        }
        else
        {
            Dash_RD.color = Color.red;
        }
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
            RB.AddForce(new Vector2(InputH, InputV) * 10, ForceMode2D.Impulse);
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
        CanDash = true;
    }
}
