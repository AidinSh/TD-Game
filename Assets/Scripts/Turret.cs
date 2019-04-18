using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {

    [Header("Attribute")]

    public float range = 15f;
    public float turnSpeed = 5f;
    public float fireRate = 1f;

    private float fireCounDown = 0f;

    [Header("Setup Fields")]

    public Transform rotatingNeck;
    public Transform target;
    public GameObject bulletPrefab;
    public Transform firePoint;


    void Start ()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.3f);
	}
	
	void Update ()
    {
        if (target == null)
        {
            return;
        }

            Vector3 dir = target.position - transform.position;
            Quaternion neckRotation = Quaternion.LookRotation(dir);
            Vector3 rotation = Quaternion.Lerp(rotatingNeck.rotation, neckRotation, Time.deltaTime * turnSpeed).eulerAngles;
            rotatingNeck.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        if ( fireCounDown <= 0f)
        {
            shoot();
            fireCounDown = 1 / fireRate;
        }
        fireCounDown -= Time.deltaTime;
        
	}

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null ;
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemey = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemey < shortestDistance )
            {
                shortestDistance = distanceToEnemey;
                nearestEnemy = enemy;
            }
        }
        if ( nearestEnemy != null && shortestDistance < range )
        {
            target = nearestEnemy.transform;

        }
        else
        {
            target = null;
        }
    }

    void shoot()
    {
        GameObject bulletGO = (GameObject) Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();
        if ( bullet != null)
        {
            bullet.Seek(target);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
