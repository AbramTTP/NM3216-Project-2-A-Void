using UnityEngine;
using System.Collections;

public class BlackHoleSuction : MonoBehaviour
{

    public GameObject blackHole; // assign your planet GO in unity editor here
    public GameObject suctionTarget;

    public float gravityFactor = 1.0f; // then tune this value  in editor too

    void start()
    {
        blackHole = GameObject.Find("Black Hole");
        suctionTarget = gameObject;
    }

    void FixedUpdate()
    {
        if ((blackHole.transform.position - suctionTarget.transform.position).sqrMagnitude <= 300f)
            GetComponent<Rigidbody2D>().AddForce((blackHole.transform.position - suctionTarget.transform.position) * GetComponent<Rigidbody2D>().mass * gravityFactor / (blackHole.transform.position - suctionTarget.transform.position).sqrMagnitude);
    }

}