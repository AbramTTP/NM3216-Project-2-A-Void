using UnityEngine;
using System.Collections;

public class ObstacleManager : MonoBehaviour {

    public PlayerHealth playerHealth;
    public GameObject obstacles;
    public float spawnTime = 3f;
    public Transform[] spawnPoints;

	// Use this for initialization
	void Start () {
        InvokeRepeating("Spawn", spawnTime, spawnTime);
	}
	
	// Spawn obstacles
	void Spawn () {

        if (!playerHealth.isAlive)
            return;

        int spawnPointIndex = Random.Range(0, spawnPoints.Length);

        Instantiate(obstacles, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);

	}
}
