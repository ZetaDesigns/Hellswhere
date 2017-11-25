using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float speed = 10f;

    private Transform target;
    private int waypointIndex = 0;

    public int value = 50;
    public GameObject deathEffect;
    public int health;
    void Start ()
    {
        target = Waypoints.waypoints[0];
    }

    public void TakeDamage (int amount)
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

    void Update ()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNextWaypoint();
        }
    }

    void GetNextWaypoint()
    {
        if (waypointIndex >= Waypoints.waypoints.Length - 1)
        {
            EndPath();
            return;
        }
        waypointIndex++;
        target = Waypoints.waypoints[waypointIndex];
    }
    void EndPath()
    {
        StatsManager.Lives--;
        Destroy(gameObject);
    }
}
