using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    [Header("Attribues : ")]
    public float bulletSpeed = 70f;

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
	}

    void hitTarget()
    {
        GameObject temporaryBulletImpact = (GameObject)Instantiate(bulletImpact, transform.position, transform.rotation);
        Destroy(temporaryBulletImpact, 2f);

        Destroy(gameObject); 
    }
}
