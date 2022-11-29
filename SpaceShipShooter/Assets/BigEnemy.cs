using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigEnemy : MonoBehaviour
{
    [SerializeField] Rigidbody2D RB;
    [SerializeField] float speed, SocialDistancing, AttackTimer = 1;
    [SerializeField] int TimeToAttack = 5;
    [SerializeField] LayerMask AllyMask;
    [SerializeField] LayerMask EnemyMask;
    [SerializeField] GameObject Bullet;
    float OriginSpeed;
    Transform Player;
    Vector2 MoveDir, SocialDDirection;
    RaycastHit SphereHit;
    Collider2D EnemyC;
    Collider2D AllyC;
    [SerializeField] bool StartAttack;
    void Start()
    {
        OriginSpeed = speed;
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        StartCoroutine(StartAttackEnum(Random.Range(0, TimeToAttack)));
    }


    void Update()
    {
        if (StartAttack)
        {
            Instantiate(Bullet, transform.position, transform.rotation);
            RB.AddForce(transform.up * -5, ForceMode2D.Impulse);
            StartAttack = false;
            StartCoroutine(StartAttackEnum(TimeToAttack));
        }

        AllyC = Physics2D.OverlapCircle(transform.position, SocialDistancing);

        MoveDir = Player.position - transform.position;

        MoveDir.x = Mathf.Clamp(MoveDir.x, -1, 1);
        MoveDir.y = Mathf.Clamp(MoveDir.y, -1, 1);
        
        SocialDDirection = transform.position - AllyC.transform.position;
        SocialDDirection.x = Mathf.Clamp(SocialDDirection.x, -1, 1);
        SocialDDirection.y = Mathf.Clamp(SocialDDirection.y, -1, 1);

    }



    IEnumerator StartAttackEnum(int WaitUntilAttack)
    {
        yield return new WaitForSeconds(WaitUntilAttack);
        StartAttack = true;
    }

    void FixedUpdate()
    {
        //Move
        RB.AddForce(MoveDir.normalized * speed);

        //Rotate
        Vector2 TargetPos = Player.position - transform.position;
        TargetPos.Normalize();
        float rot_z = Mathf.Atan2(TargetPos.y, TargetPos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
    }
}
