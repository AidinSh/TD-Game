using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    [Header("Attribues : ")]
    public float bulletSpeed = 70f;
    public float explosionRadius = 0f;

    [Header("Setup Items : ")]
    public GameObject bulletImpact;
    private Transform target;
    

	public void Seek (Transform _target)
    {
        target = _target;
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float dynamicDistance = bulletSpeed * Time.deltaTime;
        if ( dir.magnitude <= dynamicDistance)
        {
            hitTarget();
            return;
        }
        transform.Translate(dir.normalized * dynamicDistance , Space.World);
        transform.LookAt(target);
	}

    void hitTarget()
    {
        GameObject temporaryBulletImpact = (GameObject)Instantiate(bulletImpact, transform.position, transform.rotation);
        Destroy(temporaryBulletImpact, 2f);
        
        if ( explosionRadius > 0)
        {
            explode();
        }
        else
        {
            damage(target);
        }
        Destroy(gameObject);
    }

    void explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider collider in colliders)
        {
            if ( collider.tag == "Enemy")
            {
                damage(collider.transform);
            }
        }
    }

    void damage(Transform enemy)
    {
        Destroy(enemy.gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
