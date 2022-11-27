using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] Rigidbody2D RB;
    [SerializeField] float speed = 10;
    float InputV;


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
        InputV = Input.GetAxisRaw("Vertical");
    }
}
