using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float speed = 10f;

    private Transform target;
    private int wavePointIndex = 0;

	void Start ()
    {
        target = wayPoints.points[0];	    
	}
	
	
	void Update ()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
        
        if ( Vector3.Distance(transform.position , target.position) < 0.4f)
        {
            GetNextWayPoint();
        }

	}

    void GetNextWayPoint()
    {
        if ( wavePointIndex >= wayPoints.points.Length - 1)
        {
            Destroy(gameObject);
            return;
        }
        wavePointIndex++;
        target = wayPoints.points[wavePointIndex];
    }
}
