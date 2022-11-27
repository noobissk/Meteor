using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtMouse : MonoBehaviour
{
    Vector2 MousePos;
    [SerializeField] float speed;
    Quaternion targetRotation;
    float currentRot;


    void Start()
    {
        
    }

    
    void FixedUpdate()
    {
        MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float RotationZ = Mathf.Atan2(MousePos.y, MousePos.x) * Mathf.Rad2Deg;
        targetRotation = Quaternion.Euler(0, 0, RotationZ - 90);

        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, speed * Time.deltaTime);
    }
}
