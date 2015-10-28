using UnityEngine;
using System.Collections;

public class BlackHoleSuction : MonoBehaviour
{

    public GameObject blackHole; // assign your planet GO in unity editor here

    public float gravityFactor = 1.0f; // then tune this value  in editor too

    void FixedUpdate()
    {
        if ((blackHole.transform.position - transform.position).sqrMagnitude <= 300f)
            GetComponent<Rigidbody2D>().AddForce((blackHole.transform.position - transform.position) * GetComponent<Rigidbody2D>().mass * gravityFactor / (blackHole.transform.position - transform.position).sqrMagnitude);
    }

}