using UnityEngine;
using System.Collections;

public class ObstacleManager : MonoBehaviour {

    public float spawnTime = 10.0f;
    public float delay = 60.0f;
    public GameObject[] spawnPoints;
    public GameObject outerRim;
    public GameObject player;
    public GameObject[] obstacles;

	// Use this for initialization
	void Start () {

        InvokeRepeating("Spawn", 0.0f, spawnTime);
        player = GameObject.FindGameObjectWithTag("Player");
        obstacles = GameObject.FindGameObjectsWithTag("Obstacle");
        spawnPoints = GameObject.FindGameObjectsWithTag("Spawner");
        outerRim = GameObject.FindGameObjectWithTag("Outer Rim");
        
    }
	
	// Spawn obstacles
	void Spawn () {

        if (player == null) //If player dies
            return;

        int spawnPointIndex = Random.Range(0, spawnPoints.Length);
        int spawnObjectIndex = Random.Range(0, obstacles.Length);

        GameObject obstacle = GameObject.Instantiate(obstacles[spawnObjectIndex], spawnPoints[spawnPointIndex].transform.position, spawnPoints[spawnPointIndex].transform.rotation) as GameObject;

        Vector3 direction = outerRim.transform.position - obstacle.transform.position;
        direction = direction.normalized;
        obstacle.GetComponent<Rigidbody2D>().AddForce(direction);

        PlayerController PC = (PlayerController)GameObject.Find("InputManager").GetComponent("PlayerController");
        PC.obstacles.Add(obstacle);

    }

    void FixedUpdate()
    {
        if(Time.timeSinceLevelLoad  % delay == 0.0f && Time.timeSinceLevelLoad  != 0.0f && spawnTime > 0.75f){
            spawnTime -= 0.25f;
        }
    }

}
