using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndicatorScript : MonoBehaviour
{
    [SerializeField] GameObject Indicator;
    [SerializeField] LayerMask CamMask;
    [SerializeField] float ScaleMultiplier = 0.2f;
    Vector2 InitialScale;
    GameObject Target;
    Renderer RD;

    void Start()
    {
        InitialScale = transform.localScale;
        Target = GameObject.FindWithTag("Player");
        RD = GetComponent<Renderer>();
    }

    void Update()
    {
        if (!RD.isVisible)
        {
            if (!Indicator.activeSelf)
            {
                Indicator.SetActive(true);
            }

            Vector2 Dir = Target.transform.position - transform.position;
            float Distance = Vector3.Distance(transform.position, Target.transform.position);

            RaycastHit2D ray = Physics2D.Raycast(transform.position, Dir, Distance, CamMask);
            if (ray.collider != null)
            {
                Indicator.transform.position = ray.point;
                Indicator.transform.localScale = -(Vector2.one * Distance * ScaleMultiplier / 10);
            }
        }
        else
        {
            if (Indicator.activeSelf)
            {
                Indicator.SetActive(false);
            }
        }
    }
}
