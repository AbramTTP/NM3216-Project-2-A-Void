using UnityEngine;
using System.Collections;

public class WhirlpoolSuctionDuck : MonoBehaviour {

    public GameObject whirlpool; // assign your planet GO in unity editor here

    public float gravityFactor = 0f; // then tune this value  in editor too

    public float delay = 60.0f;

    void start(){
    }

    void FixedUpdate()
    {

        if ((whirlpool.transform.position - transform.position).sqrMagnitude <= 300f)
            GetComponent<Rigidbody2D>().AddForce((whirlpool.transform.position - transform.position) * GetComponent<Rigidbody2D>().mass * gravityFactor / (whirlpool.transform.position - transform.position).sqrMagnitude);

        if (Time.time % delay == 0.0f && Time.time != 0.0f)
        {
            gravityFactor = gravityFactor + 1f;

        }
    }
}
