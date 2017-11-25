using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float speed = 10f;

    public int value = 50;
    public GameObject deathEffect;
    public float health;

    public void TakeDamage (float amount)
    {
        health -= amount;

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        GameObject DeathEffect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(DeathEffect, 5f);
        Destroy(gameObject);
        StatsManager.Money += value;
    }
}
