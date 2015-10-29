using UnityEngine;
using System.Collections;

public class BlackHoleSuctionSpaceship : MonoBehaviour {

    public GameObject blackHole; // assign your planet GO in unity editor here

    public float gravityFactor; // then tune this value  in editor too
    public float delay;

    public float gravityIncPerDelay;
    public float gravityMaxInGame;
    public float blackHoleSizeIncPerDelay;
    public float blackHoleMaxScaleInGame;

    float scaleTimer;
    float resetPointTime;
    Vector3 blackHoleSize = new Vector3(1f, 1f, 1f);

    void start()
    {
        scaleTimer = 0.0f;
        resetPointTime = 0.0f;

        blackHole = GameObject.Find("Black Hole");
        gravityFactor = 0.0f;
        delay = 60.0f;
        gravityIncPerDelay = 5.0f;
        gravityMaxInGame = 80.0f;
        blackHoleSizeIncPerDelay = 1.0f;
        blackHoleMaxScaleInGame = 4.0f;
    }

    void FixedUpdate()
    {
        scaleTimer = Time.timeSinceLevelLoad - resetPointTime;

        if ((blackHole.transform.position - transform.position).sqrMagnitude <= 300.0f)
            GetComponent<Rigidbody2D>().AddForce((blackHole.transform.position - transform.position) * GetComponent<Rigidbody2D>().mass * gravityFactor / (blackHole.transform.position - transform.position).sqrMagnitude);

        if (scaleTimer >= delay && Time.timeSinceLevelLoad != 0.0f)
        {
            resetPointTime = Time.timeSinceLevelLoad;
            gravityFactor = gravityFactor + gravityIncPerDelay;
            if (blackHoleSize.x < blackHoleMaxScaleInGame)
            {
                blackHoleSize.x = blackHoleSize.x + blackHoleSizeIncPerDelay;
                blackHoleSize.y = blackHoleSize.y + blackHoleSizeIncPerDelay;
                blackHoleSize.z = blackHoleSize.z + blackHoleSizeIncPerDelay;
                blackHole.transform.localScale = new Vector3(blackHoleSize.x, blackHoleSize.y, blackHoleSize.z);
            }
        }

        if (gravityFactor > gravityMaxInGame)
        {
            gravityFactor = gravityMaxInGame;
        }
    }
}
