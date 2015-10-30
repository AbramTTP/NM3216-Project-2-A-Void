using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour {

    public GameObject BlackHole;
    public GameObject OuterRim;
    public GameObject Spaceship;
    public List<GameObject> Obstacles;

    public float fluidRotationSpeed = 0.1f;
    public float spaceshipTranslationSpeed = 0.15f;
    public float spaceshipTotalDamagedThrustSpeed = 0.1f;

    void start()
    {
        BlackHole = GameObject.Find("Black Hole");
        OuterRim = GameObject.Find("Outer Rim");
        Spaceship = GameObject.Find("Player");
        Obstacles = new List<GameObject>();
    }

    void Update()
    {

        //if (Input.GetKeyDown("space"))
        //{
        //    fluidRotationSpeed = -fluidRotationSpeed;
        //}

        if (Spaceship != null || !Spaceship.Equals(null))
        {
            Spaceship.transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, 0, 0);
        }

    }
    
    // Update is called once per frame
    void FixedUpdate () {

        if (Spaceship != null || !Spaceship.Equals(null))
        {

            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");
            Vector3 center = new Vector3(0, 0, 0);

            if (spaceshipTranslationSpeed < spaceshipTotalDamagedThrustSpeed){
                spaceshipTranslationSpeed = spaceshipTotalDamagedThrustSpeed;
            }

            Vector3 translationVector = new Vector3(spaceshipTranslationSpeed * moveHorizontal, spaceshipTranslationSpeed * moveVertical, 0f);
            Spaceship.transform.Translate(translationVector);

            Vector3 rotation = new Vector3(0f, 0f, -(fluidRotationSpeed));
            OuterRim.transform.Rotate(rotation);

            for (int i = 0; i < Obstacles.Capacity; i++)
            {
                Vector3 vortexVector = Obstacles[i].transform.position - center;

                vortexVector = Quaternion.AngleAxis(-fluidRotationSpeed, Vector3.forward) * vortexVector;

                if ((BlackHole.transform.position - Obstacles[i].transform.position).sqrMagnitude <= 300.0f)
                    Obstacles[i].transform.position = center + vortexVector;
            }

        }

    }
}
