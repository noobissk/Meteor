using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour
{
    [SerializeField] Rigidbody2D RB;
    [SerializeField] float speed, TurnSpeed, SocialDistancing, AttackTimer = 1, DashAttack;
    [SerializeField] int MaxTimeToAttack = 5;
    [SerializeField] LayerMask AllyMask;
    [SerializeField] LayerMask EnemyMask;
    float OriginSpeed;
    Transform Player;
    Vector2 MoveDir, SocialDDirection;
    Collider2D AllyC;
    [SerializeField] bool StartAttack;
    void Start()
    {
        OriginSpeed = speed;
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        StartCoroutine(StartAttackEnum(Random.Range(0, MaxTimeToAttack)));
    }

    
    void Update()
    {
        if (StartAttack)
        {
            speed -= AttackTimer * Time.deltaTime;
            if (speed <= 3)
            {
                RB.AddForce(MoveDir.normalized * DashAttack * 2, ForceMode2D.Impulse);
                speed = OriginSpeed;
                StartAttack = false;
            }
        }

        if (!StartAttack)
        {
            StartCoroutine(StartAttackEnum(Random.Range(4, MaxTimeToAttack)));
        }
        AllyC = Physics2D.OverlapCircle(transform.position, SocialDistancing);

        MoveDir = Player.position - transform.position;

        MoveDir.x = Mathf.Clamp(MoveDir.x, -1, 1);
        MoveDir.y = Mathf.Clamp(MoveDir.y, -1, 1);

        SocialDDirection = transform.position - AllyC.transform.position;
        SocialDDirection.x = Mathf.Clamp(SocialDDirection.x, -1, 1);
        SocialDDirection.y = Mathf.Clamp(SocialDDirection.y, -1, 1);

        if (AllyC != null) // learn to use 2D raycasts
        {
            RB.AddForce(SocialDDirection, ForceMode2D.Force);
        }
    }

    IEnumerator StartAttackEnum(int WaitUntilAttack)
    {
        yield return new WaitForSeconds(WaitUntilAttack);
        StartAttack = true;
    }

    void FixedUpdate()
    {
        RB.AddForce(MoveDir.normalized * speed);

        Vector2 TargetPos = Player.position - transform.position;
        TargetPos.Normalize();
        float rot_z = Mathf.Atan2(TargetPos.y, TargetPos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
    }
}
