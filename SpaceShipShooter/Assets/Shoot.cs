using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Shoot : MonoBehaviour
{
    [SerializeField] GameObject Bullet;
    [SerializeField] Transform BulletSpawnPos;
    [SerializeField] int MaxBullets = 60;
    [SerializeField] float TimeToReload = 5;
    [SerializeField] TMP_Text Ammo_Text;
    int bullets;
    bool IsReloading;
    float TimeToNextShot = 0.2f, timer;

    void Start()
    {
        bullets = MaxBullets;
    }
    void Update()
    {
        Ammo_Text.text = bullets.ToString();
        if ((Input.GetKey(KeyCode.Mouse0) && TimeToNextShot <= timer && !Menu.IsPaused) && bullets > 0)
        {
            bullets--;
            Instantiate(Bullet, BulletSpawnPos.position, transform.rotation);
            timer = 0;
        }
        if (Input.GetKeyDown(KeyCode.R) && !IsReloading)
        {
            StartCoroutine(Reload());
        }

        timer += Time.deltaTime;
    }

    IEnumerator Reload()
    {
        IsReloading = true;
        yield return new WaitForSeconds(TimeToReload);
        bullets = MaxBullets;
        IsReloading = false;
    }
}
