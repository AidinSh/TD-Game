using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {

    public Transform target;
    public float range = 15f;
    public Transform rotatingNeck;

	void Start ()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
	}
	
	void Update ()
    {
        if (target == null)
        {
            return;
        }

        Vector3 dir = target.position - transform.position;
        Quaternion neckRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = neckRotation.eulerAngles;
        rotatingNeck.rotation = Quaternion.Euler(0f, rotation.y, 0f);
	}

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemey = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemey < shortestDistance)
            {
                shortestDistance = distanceToEnemey;
                nearestEnemy = enemy;
            }
        }
        if ( nearestEnemy != null && shortestDistance < range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
