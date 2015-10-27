using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour {

    public float fluidRotationSpeed = 1f;
    public float duckTranslationSpeed = 1f;

    public GameObject whirlpool;
    public GameObject pond;
    public GameObject duck;
    public List<GameObject> obstacles;

    void start()
    {
        whirlpool = GameObject.Find("Whirlpool");
        pond = GameObject.Find("Pond");
        duck = GameObject.Find("Player");
        obstacles = new List<GameObject>();
    }

    void Update()
    {

        if (Input.GetKeyDown("space"))
        {
            fluidRotationSpeed = -fluidRotationSpeed;
        }

        duck.transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, 0, 0);

    }
    
    // Update is called once per frame
    void FixedUpdate () {

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 center = new Vector3(0, 0, 0);

        Vector3 translationVector = new Vector3(duckTranslationSpeed * moveHorizontal, duckTranslationSpeed * moveVertical, 0f);
        duck.transform.Translate(translationVector);

        Vector3 rotation = new Vector3(0f, 0f, -(fluidRotationSpeed));
        pond.transform.Rotate(rotation);

        for (int i = 0; i < obstacles.Capacity; i++)
        {
            Vector3 vortexVector = obstacles[i].transform.position - center;

            vortexVector = Quaternion.AngleAxis(-fluidRotationSpeed, Vector3.forward) * vortexVector;

            if ((whirlpool.transform.position - obstacles[i].transform.position).sqrMagnitude <= 300.0f)
                obstacles[i].transform.position = center + vortexVector;
        }

    }
}
