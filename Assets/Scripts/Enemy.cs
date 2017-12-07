using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float startspeed = 10f;
    [HideInInspector]
    public float currentspeed;

    public int value = 50;
    public GameObject deathEffect;
    public float health;

    public void Start()
    {
        currentspeed = startspeed;
    }
    public void TakeDamage (float amount)
    {
        health -= amount;

        if (health <= 0)
        {
            Die();
        }
    }

    public void Slow (float slowing)
    {
        currentspeed = startspeed * (1f - slowing);
    }

    void Die()
    {
        GameObject DeathEffect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(DeathEffect, 5f);
        Destroy(gameObject);
        StatsManager.Money += value;
    }
}
