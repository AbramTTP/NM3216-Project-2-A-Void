using UnityEngine;
using System.Collections;

public class ObstacleManagerMenu : MonoBehaviour {

    public GameObject[] spawnPoints;
    public GameObject blackHole;
    public GameObject[] obstacles;

    public float spawnTime = 0.5f;
    public float minSpawnTime = 0.5f;

    float exactTime;

	// Use this for initialization
	void Start () 
    {

        InvokeRepeating("Spawn", 0.0f, spawnTime);
        obstacles = GameObject.FindGameObjectsWithTag("Obstacle");
        spawnPoints = GameObject.FindGameObjectsWithTag("Spawner");
        blackHole = GameObject.FindGameObjectWithTag("Black Hole");

        exactTime = 0.0f;
    }
	
	// Spawn obstacles
	void Spawn () 
    {

        int spawnPointIndex = Random.Range(0, spawnPoints.Length);
        int spawnObjectIndex = Random.Range(0, obstacles.Length);

        GameObject obstacle = GameObject.Instantiate(obstacles[spawnObjectIndex], spawnPoints[spawnPointIndex].transform.position, spawnPoints[spawnPointIndex].transform.rotation) as GameObject;

        Vector3 direction = blackHole.transform.position - obstacle.transform.position;
        direction = direction.normalized;
        obstacle.GetComponent<Rigidbody2D>().AddForce(direction);

        RotationalForceManager PC = (RotationalForceManager)GameObject.Find("RotationalForceManager").GetComponent("RotationalForceManager");
        PC.Obstacles.Add(obstacle);

    }

    void FixedUpdate()
    {
        if (Time.timeSinceLevelLoad - exactTime >= 1.0f)
        {
            exactTime += 1.0f;
            CancelInvoke("Spawn");
            InvokeRepeating("Spawn", 0.0f, spawnTime);         
        }

        if (spawnTime < minSpawnTime)
        {
            spawnTime = minSpawnTime;
        }
    }

}
