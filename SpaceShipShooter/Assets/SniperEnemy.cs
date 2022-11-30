using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperEnemy : MonoBehaviour
{
    [SerializeField] Rigidbody2D RB;
    [SerializeField] float speed, SocialDistancing, AttackTimer = 1, damage = 50, rotationSpeed = 1;
    [SerializeField] int TimeToAttack = 5;
    [SerializeField] LayerMask EnemyMask;
    RaycastHit2D hit;
    float OriginSpeed;
    Transform Player;
    Vector2 MoveDir;
    int pewpew;
    float RotationZ;

    [SerializeField] bool StartAttack;
    void Start()
    {
        OriginSpeed = speed;
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        StartCoroutine(StartAttackEnum(Random.Range(0, TimeToAttack)));
    }


    void Update()
    {
        if (StartAttack && Physics2D.OverlapCircle(transform.position, 10, EnemyMask))
        {
            Vector2 Dir = Player.position - transform.position;
            float RotationZ = Mathf.Atan2(Dir.y, Dir.x) * Mathf.Rad2Deg;
            Vector3 ShootDir = new Vector3(0, 0, RotationZ - 90);
            hit = Physics2D.Raycast(transform.position, transform.up, 30, EnemyMask);
            if (hit)
            {
                if (hit.collider.GetComponent<Health>())
                {
                    hit.collider.GetComponent<Health>().health = hit.collider.GetComponent<Health>().health - damage;
                }
            }
            RB.AddForce(transform.up * -5, ForceMode2D.Impulse);
            StartAttack = false;
            StartCoroutine(StartAttackEnum(TimeToAttack));
        }
        Debug.DrawRay(transform.position, new Vector3(0, 0, RotationZ - 90), Color.cyan);


        MoveDir = Player.position - transform.position;

        MoveDir.x = Mathf.Clamp(MoveDir.x, -1, 1);
        MoveDir.y = Mathf.Clamp(MoveDir.y, -1, 1);
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
        Vector2 Dir = Player.position - transform.position;
        float RotationZ = Mathf.Atan2(Dir.y, Dir.x) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.Euler(0, 0, RotationZ - 90);


        /*Vector2 TargetPos = Player.position - transform.position;
        TargetPos.Normalize();
        float rot_z = Mathf.Atan2(TargetPos.y, TargetPos.x) * Mathf.Rad2Deg;*/
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}
