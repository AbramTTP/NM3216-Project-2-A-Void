using UnityEngine;
using System.Collections;

public class BlackHoleSuctionSpaceship : MonoBehaviour {

    public GameObject blackHole; // assign your planet GO in unity editor here
    public float gravityFactor = 0.0f; // then tune this value  in editor too
    public float delay = 60.0f;

    public float gravityIncPerDelay = 2.0f;
    public float gravityMaxInGame = 60.0f;

    void start(){
    }

    void FixedUpdate()
    {

        if ((blackHole.transform.position - transform.position).sqrMagnitude <= 300.0f)
            GetComponent<Rigidbody2D>().AddForce((blackHole.transform.position - transform.position) * GetComponent<Rigidbody2D>().mass * gravityFactor / (blackHole.transform.position - transform.position).sqrMagnitude);

        if (Time.timeSinceLevelLoad  % delay == 0.0f && Time.timeSinceLevelLoad  != 0.0f)
        {
            gravityFactor = gravityFactor + gravityIncPerDelay;
        }

        if (gravityFactor > gravityMaxInGame)
        {
            gravityFactor = gravityMaxInGame;
        }
    }
}
