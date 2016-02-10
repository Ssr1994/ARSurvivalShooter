﻿using UnityEngine;
using Vuforia;

public class EnemyManager : MonoBehaviour
{
	public GameObject imageTarget;
    public PlayerHealth playerHealth;
    public GameObject enemy;
    public float spawnTime = 3f;
    public Transform[] spawnPoints;
	public int levelPoint = 12;
	public float spawnTimeReduce = 0.4f;

	int numSpawned;

    void Start ()
    {
		numSpawned = 0;
        InvokeRepeating ("Spawn", spawnTime, spawnTime);
    }

    void Spawn ()
    {
        if(playerHealth.currentHealth <= 0f)
            return;

		if (++numSpawned >= levelPoint && spawnTime > spawnTimeReduce) {
			numSpawned = 0;
			spawnTime -= spawnTimeReduce;
			CancelInvoke ();
			InvokeRepeating ("Spawn", spawnTime, spawnTime);
		}

        int spawnPointIndex = Random.Range (0, spawnPoints.Length);

        GameObject spawned = Instantiate (enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation) as GameObject;
		spawned.transform.parent = imageTarget.transform;
		imageTarget.GetComponent<VirtualButtonManager> ().AssignVirtualButton (spawned);
    }
}
