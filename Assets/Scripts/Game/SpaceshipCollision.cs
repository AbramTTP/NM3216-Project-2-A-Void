using UnityEngine;
using System.Collections;

public class SpaceshipCollision : MonoBehaviour {

    public float gravityIncreasePerCollision = 2.0f;
    public float thrustDecreasePerCollision = 0.02f;
    public GameObject spaceship;
    public GameObject inputManager;

    // Use this for initialization
    void Start()
    {
        spaceship = GameObject.Find("Player");
        inputManager = GameObject.Find("InputManager");
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Obstacle")
        {

            float gravityFactor = 0.0f;
            float spaceshipVelocity = 0.0f;
            float spaceshipTotalDamageVelocity = 0.0f;

            gravityFactor = spaceship.GetComponent<BlackHoleSuctionSpaceship>().gravityFactor;
            spaceshipVelocity = inputManager.GetComponent<PlayerController>().spaceshipTranslationSpeed;
            spaceshipTotalDamageVelocity = inputManager.GetComponent<PlayerController>().spaceshipTotalDamagedThrustSpeed;

            if (gravityFactor == 0.0f)
                gravityFactor += gravityIncreasePerCollision;
            else
                gravityFactor *= gravityIncreasePerCollision;

            spaceshipVelocity -= thrustDecreasePerCollision;

            if (spaceshipVelocity < spaceshipTotalDamageVelocity)
                spaceshipVelocity = spaceshipTotalDamageVelocity;

            spaceship.GetComponent<BlackHoleSuctionSpaceship>().gravityFactor = gravityFactor;
            inputManager.GetComponent<PlayerController>().spaceshipTranslationSpeed = spaceshipVelocity;
        }
    }

}
