using UnityEngine;
using System.Collections;

public class DuckCollision : MonoBehaviour {

    public float gravityFactor;
    public GameObject duck;

    // Use this for initialization
    void Start()
    {
        duck = GameObject.Find("Player");
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Obstacles")
        {
            gravityFactor = duck.GetComponent<WhirlpoolSuctionDuck>().gravityFactor;
            gravityFactor = gravityFactor + 1f;
            duck.GetComponent<WhirlpoolSuctionDuck>().gravityFactor = gravityFactor;
        }
    }

}
