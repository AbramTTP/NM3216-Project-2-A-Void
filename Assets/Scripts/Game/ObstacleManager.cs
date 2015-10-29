using UnityEngine;
using System.Collections;

public class ObstacleManager : MonoBehaviour {

    public GameObject[] spawnPoints;
    public GameObject blackHole;
    public GameObject player;
    public GameObject[] obstacles;

    public float spawnTime = 2.0f;
    public float decrementDelay = 15.0f;
    public float spawnTimeDec = 0.25f;
    public float minSpawnTime = 0.25f;

	// Use this for initialization
	void Start () 
    {

        InvokeRepeating("Spawn", 0.0f, spawnTime);
        player = GameObject.FindGameObjectWithTag("Player");
        obstacles = GameObject.FindGameObjectsWithTag("Obstacle");
        spawnPoints = GameObject.FindGameObjectsWithTag("Spawner");
        blackHole = GameObject.FindGameObjectWithTag("Black Hole");
        
    }
	
	// Spawn obstacles
	void Spawn () 
    {

        if (player == null) //If player dies
            return;

        int spawnPointIndex = Random.Range(0, spawnPoints.Length);
        int spawnObjectIndex = Random.Range(0, obstacles.Length);

        GameObject obstacle = GameObject.Instantiate(obstacles[spawnObjectIndex], spawnPoints[spawnPointIndex].transform.position, spawnPoints[spawnPointIndex].transform.rotation) as GameObject;

        Vector3 direction = blackHole.transform.position - obstacle.transform.position;
        direction = direction.normalized;
        obstacle.GetComponent<Rigidbody2D>().AddForce(direction);

        PlayerController PC = (PlayerController)GameObject.Find("InputManager").GetComponent("PlayerController");
        PC.Obstacles.Add(obstacle);

    }

    void FixedUpdate()
    {
        if(Time.timeSinceLevelLoad  % decrementDelay == 0.0f && Time.timeSinceLevelLoad  != 0.0f && spawnTime > minSpawnTime){
            spawnTime -= spawnTimeDec;
        }
    }

}
