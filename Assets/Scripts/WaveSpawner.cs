using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour {

    private int waveIndex = 1;
    private float timeToRespawn = 5f;

    public float countDown = 2f;
    public Transform Enemy;
    public Transform spawnPoint;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		if ( countDown <= 0f)
        {
            StartCoroutine(waveRespawn());
            countDown = timeToRespawn;
        }
        countDown -= Time.deltaTime;
	}

    IEnumerator waveRespawn()
    {
        for (int i = 0; i < waveIndex; i++)
        {
            Instantiate(Enemy, spawnPoint.position, spawnPoint.rotation);
            yield return new WaitForSeconds(0.5f);
        }
        waveIndex++;
    }
}
