using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour
{
    [SerializeField] Rigidbody2D RB;
    [SerializeField] float speed, TurnSpeed, SocialDistancing, AttackTimer = 1, DashAttack, damage = 15;
    [SerializeField] int MaxTimeToAttack = 5;
    [SerializeField] Collider2D AttackCollider;
    [SerializeField] LayerMask AllyMask;
    [SerializeField] LayerMask EnemyMask;
    float OriginSpeed;
    Transform Player;
    Vector2 MoveDir, SocialDDirection;
    Collider2D AllyC;
    Collider2D PlayerC;
    [SerializeField] bool StartAttack, CanMove = true;
    Death_S Ded;
    void Start()
    {
        Ded = GetComponent<Death_S>();
        OriginSpeed = speed;
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        StartCoroutine(StartAttackEnum(Random.Range(0, MaxTimeToAttack)));
    }

    
    void Update()
    {
        if (StartAttack && !Ded.CanMove)
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
        AllyC = Physics2D.OverlapCircle(transform.position, SocialDistancing, AllyMask);

        MoveDir = Player.position - transform.position;

        MoveDir.x = Mathf.Clamp(MoveDir.x, -1, 1);
        MoveDir.y = Mathf.Clamp(MoveDir.y, -1, 1);

        
        if (AllyC != null)
        {
            SocialDDirection = transform.position - AllyC.transform.position;
            SocialDDirection.x = Mathf.Clamp(SocialDDirection.x, -1, 1);
            SocialDDirection.y = Mathf.Clamp(SocialDDirection.y, -1, 1);
        }
        else if (AllyC != null && CanMove) // learn to use 2D raycasts
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
        Vector2 TargetPos = Player.position - transform.position;
        TargetPos.Normalize();
        float rot_z = Mathf.Atan2(TargetPos.y, TargetPos.x) * Mathf.Rad2Deg;
        
        if (!Ded.CanMove)
        {
            RB.AddForce(MoveDir.normalized * speed);
            transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Health>().health -= damage;
            Ded.Died();
        }
    }
}
