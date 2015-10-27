using UnityEngine;
using System.Collections;

public class WhirlpoolSuction : MonoBehaviour
{

    public GameObject whirlpool; // assign your planet GO in unity editor here

    public float gravityFactor = 1f; // then tune this value  in editor too

    void FixedUpdate()
    {
        if ((whirlpool.transform.position - transform.position).sqrMagnitude <= 300f)
            GetComponent<Rigidbody2D>().AddForce((whirlpool.transform.position - transform.position) * GetComponent<Rigidbody2D>().mass * gravityFactor / (whirlpool.transform.position - transform.position).sqrMagnitude);
    }

}