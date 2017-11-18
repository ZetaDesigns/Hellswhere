using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    private Transform target;

    public float speed = 70f;
    public GameObject impactSystem;
    public void GetTarget(Transform _target)
    {
        target = _target;
    }
	// Update is called once per frame
	void Update () {
	    
        if(target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }
        transform.Translate(dir.normalized * distanceThisFrame, Space.World);

	}
    void HitTarget()
    {
        GameObject effectIns = (GameObject)Instantiate(impactSystem, transform.position, transform.rotation);
        Destroy(effectIns, 5f);
        Destroy(gameObject);
        Destroy(target.gameObject);
    }
}
