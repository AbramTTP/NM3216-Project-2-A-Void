using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RotationalForceManager : MonoBehaviour {

    public GameObject BlackHole;
    public GameObject OuterRim;
    public List<GameObject> Obstacles;

    public float fluidRotationSpeed = 0.1f;

    void start()
    {
        BlackHole = GameObject.Find("Black Hole");
        OuterRim = GameObject.Find("Outer Rim");
        Obstacles = new List<GameObject>();
    }

    // Update is called once per frame
    void FixedUpdate () {

        Vector3 center = new Vector3(0, 0, 0);

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
