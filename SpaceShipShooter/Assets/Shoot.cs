using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] GameObject Bullet;
    [SerializeField] Transform BulletSpawnPos;
    float TimeToNextShot = 0.2f, timer;

    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0) && TimeToNextShot <= timer)
        {
            Instantiate(Bullet, BulletSpawnPos.position, transform.rotation);
            timer = 0;
        }

        timer += Time.deltaTime;
    }
}
