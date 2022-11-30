using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Health : MonoBehaviour
{
    [SerializeField] int MaxHealth, EnemyId;
    TMP_Text Health_Text;
    public float health;
    float time, timeTillRegen = 4, healthCheck;
    int TextHealth;
    bool Regen;
    Death_S Ded;
    void Start()
    {
        healthCheck = health;
        Health_Text = GameObject.FindGameObjectWithTag("Health_Text").GetComponent<TMP_Text>();
        Ded = GetComponent<Death_S>();
        health = MaxHealth;
    }

    void Update()
    {
        time += 1 * Time.deltaTime;
        if (!gameObject.CompareTag("Player"))
        {
            Damage();
        }
        else
        {
            PlayerDamage();
            TextHealth = (int) health;
            Health_Text.text = TextHealth.ToString();
            if (time >= timeTillRegen && health <= 100)
            {
                health += 0.5f * Time.deltaTime;
                healthCheck += 0.5f * Time.deltaTime;
            }
            if (health != healthCheck)
            {
                healthCheck = health;
                time = 0;
            }
            health = Mathf.Clamp(health, 0, 100);
            healthCheck = Mathf.Clamp(healthCheck, 0, 100);
        }
    }
    void Damage()
    {
        if (health <= 0)
        {
            if (EnemyId == 2)
            {
                Menu.score += 15;
                SpawnEnemies.currentEnemies[2] -= 1;
            }
            else if (EnemyId == 1)
            {
                Menu.score += 5;
                SpawnEnemies.currentEnemies[1] -= 1;
            }
            else
            {
                Menu.score++;
                SpawnEnemies.currentEnemies[0] -= 1;
            }
            
            Ded.Died();
        }
    }
    void PlayerDamage()
    {
        if (health <= 0)
        {
            Menu.IsPaused = true;
        }
    }
}
