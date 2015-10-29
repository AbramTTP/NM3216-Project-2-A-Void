using UnityEngine;
using System.Collections;

public class MeteroidManager : MonoBehaviour {
   
    public GameObject[] spawnPoints;
    public GameObject blackHole;
    public GameObject player;
    public GameObject[] obstacles;

    public float minTimeBetweenSpawn = 0.5f;
    public float minTimeFirstSpawn = 15.0f;
    public float maxSpawnTime = 60.0f;

    // Use this for initialization
    void Start()
    {
        InvokeRepeating("Spawn", (float)(Random.Range(minTimeFirstSpawn, maxSpawnTime)), (float)(Random.Range(minTimeBetweenSpawn, maxSpawnTime)));
        player = GameObject.FindGameObjectWithTag("Player");
        obstacles = GameObject.FindGameObjectsWithTag("Meteroid");
        spawnPoints = GameObject.FindGameObjectsWithTag("Meteroid Spawner");
        blackHole = GameObject.FindGameObjectWithTag("Black Hole");
    }

    // Spawn obstacles
    void Spawn()
    {

        if (player == null) //If player dies
            return;

        int spawnPointIndex = Random.Range(0, spawnPoints.Length);
        int spawnObjectIndex = Random.Range(0, obstacles.Length);

        GameObject obstacle = GameObject.Instantiate(obstacles[spawnObjectIndex], spawnPoints[spawnPointIndex].transform.position, spawnPoints[spawnPointIndex].transform.rotation) as GameObject;

        Vector3 direction = blackHole.transform.position - obstacle.transform.position;
        direction = direction.normalized;
        obstacle.GetComponent<Rigidbody2D>().AddForce(direction);

        //PlayerController PC = (PlayerController)GameObject.Find("InputManager").GetComponent("PlayerController");
        //PC.Obstacles.Add(obstacle);

    }

}
