using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform Target;
    [SerializeField] Transform CameraPos;
    [SerializeField] float DontMoveX, DontMoveY, CamYOffset;
    [SerializeField] float smoothSpeed = 0.08f;
    Vector3 TargetWorldTransform;

    void Awake()
    {
        TargetWorldTransform = CameraPos.position;
    }
    void LateUpdate()
    {
        
        if (Target.position.x > transform.position.x + DontMoveX) TargetWorldTransform.x = Mathf.Lerp(transform.position.x, Target.position.x, smoothSpeed * Time.deltaTime);
        if (Target.position.x < transform.position.x - DontMoveX) TargetWorldTransform.x = Mathf.Lerp(transform.position.x, Target.position.x, smoothSpeed * Time.deltaTime);

        if (Target.position.y > transform.position.y + DontMoveY) TargetWorldTransform.y = Mathf.Lerp(transform.position.y, Target.position.y , smoothSpeed * Time.deltaTime);
        if (Target.position.y < transform.position.y - DontMoveY) TargetWorldTransform.y = Mathf.Lerp(transform.position.y, Target.position.y , smoothSpeed * Time.deltaTime);

        transform.position = TargetWorldTransform;
    }
}
