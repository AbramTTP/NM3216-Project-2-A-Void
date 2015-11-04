using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class MeteroidManager : MonoBehaviour {
   
    public GameObject[] spawnPoints;
    public GameObject[] warningPoints;

    public GameObject blackHole;
    public GameObject player;
    public GameObject meteroids;
    public GameObject warningSign;

    public List<GameObject> spawnedMeteroids;
    
    public float minTimeFirstSpawn = 5.0f;
    public float minSpawnInterval = 0.5f;
    public float maxSpawnInterval = 10.0f;
    public float maxSpawnIntervalRegenerateTime = 5.0f;
    public float warningSignDuration = 2.0f;

    float exactTime;
    bool isTicked;

    // Use this for initialization
    void Start()
    {

        InvokeRepeating("Spawn", (float)(Random.Range(minTimeFirstSpawn, maxSpawnInterval)), (float)(Random.Range(minSpawnInterval, maxSpawnInterval)));
        
        player = GameObject.FindGameObjectWithTag("Player");
        meteroids = GameObject.Find("meteroid");
        warningSign = GameObject.Find("meteroidWarning");
        spawnPoints = GameObject.FindGameObjectsWithTag("Meteroid Spawner");
        warningPoints = GameObject.FindGameObjectsWithTag("Warning Spawner");
        blackHole = GameObject.FindGameObjectWithTag("Black Hole");

        spawnPoints = spawnPoints.OrderBy(go => go.name).ToArray();
        warningPoints = warningPoints.OrderBy(go => go.name).ToArray();

        exactTime = 0.0f;
        isTicked = false;
    }

    // Spawn meteroids
    void Spawn()
    {

        if (player == null) //If player dies
            return;

        int spawnPointIndex = 0;
        float minDistanceToPlayer = 999999.0f;

        for (int i = 0; i < spawnPoints.Length; i++)
        {
            float distanceToPlayer = Vector3.Distance(spawnPoints[i].transform.position, player.transform.position);
            if (distanceToPlayer < minDistanceToPlayer)
            {
                minDistanceToPlayer = distanceToPlayer;
                spawnPointIndex = i;
            }
        }

        GameObject meteroid = GameObject.Instantiate(meteroids, spawnPoints[spawnPointIndex].transform.position, spawnPoints[spawnPointIndex].transform.rotation) as GameObject;

        GameObject warning = GameObject.Instantiate(warningSign, warningPoints[spawnPointIndex].transform.position, warningPoints[spawnPointIndex].transform.rotation) as GameObject;
        Destroy(warning, warningSignDuration);
        AudioSource sound = meteroid.GetComponent<AudioSource>();
        sound.Play();

        Vector3 direction = blackHole.transform.position - meteroid.transform.position;
        direction = direction.normalized;
        meteroid.GetComponent<Rigidbody2D>().AddForce(direction);

        MeteroidManager MM = (MeteroidManager)GameObject.Find("MeteroidManager").GetComponent("MeteroidManager");
        MM.spawnedMeteroids.Add(meteroid);

    }

    void FixedUpdate()
    {
        if (Time.timeSinceLevelLoad - exactTime >= 1.0f)
        {
            exactTime += 1.0f;
            isTicked = true;
        }

        if(exactTime % maxSpawnIntervalRegenerateTime == 0.0f && isTicked){
            maxSpawnInterval = (float)(Random.Range(minSpawnInterval, maxSpawnInterval));
            CancelInvoke("Spawn");
            InvokeRepeating("Spawn", (float)(Random.Range(minTimeFirstSpawn, maxSpawnInterval)), (float)(Random.Range(minSpawnInterval, maxSpawnInterval)));
            isTicked = !isTicked;
        }
    }
}
