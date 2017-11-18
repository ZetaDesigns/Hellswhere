using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {

    private Transform target;
    public float range = 15f;
    public float turningSpeed = 5;
    public string enemyTag = "Enemy";

    public Transform ParttoRotate;
    // Use this for initialization
	void Start ()
    {
        InvokeRepeating("FindNewTarget", 0f, 0.5f);
	}
	void FindNewTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy; 
                nearestEnemy = enemy;
            }
        }
        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        } else
        {
            target = null;
        }
    }
	// Update is called once per frame
	void Update ()
    {
        if (target == null)
            return;

        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(ParttoRotate.rotation, lookRotation, Time.deltaTime * turningSpeed).eulerAngles;

        ParttoRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
	}
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
