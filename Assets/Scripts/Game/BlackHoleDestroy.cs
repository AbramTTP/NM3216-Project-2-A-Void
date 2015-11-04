using UnityEngine;
using System.Collections;

public class BlackHoleDestroy : MonoBehaviour {

    public GameObject Explosion;
    public GameObject GameOverObject;

    public float obstacleGravityFactorIncrement;
    public float obstacleSpawnTimeDecrement;
    public bool isSpeedUpPlanet;

    void start()
    {
        Explosion = GameObject.Find("Explosion");
        GameOverObject = GameObject.Find("GameOverMenuObject");

        obstacleGravityFactorIncrement = 0.25f;
        obstacleSpawnTimeDecrement = 0.01f;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Obstacle")
        {
            Instantiate(Explosion, col.gameObject.transform.position, col.gameObject.transform.rotation);
            AudioSource sound = Explosion.GetComponent<AudioSource>();
            sound.Play();
            Destroy(col.gameObject);

            PlayerController PC = (PlayerController)GameObject.Find("InputManager").GetComponent("PlayerController");           
            PC.Obstacles.Remove(col.gameObject);

            for (int i = 0; i < PC.Obstacles.Capacity; i++)
            {
                PC.Obstacles[i].GetComponent<BlackHoleSuction>().gravityFactor += obstacleGravityFactorIncrement;
            }

            ObstacleManager OM = (ObstacleManager)GameObject.Find("ObstacleManager").GetComponent("ObstacleManager");
            for (int i = 0; i < OM.obstacles.Length; i++)
            {
                OM.obstacles[i].GetComponent<BlackHoleSuction>().gravityFactor += obstacleGravityFactorIncrement;
            }
        }
        else if (col.gameObject.tag == "Meteroid")
        {
            Instantiate(Explosion, col.gameObject.transform.position, col.gameObject.transform.rotation);
            AudioSource sound = Explosion.GetComponent<AudioSource>();
            sound.Play();
            Destroy(col.gameObject);

            MeteroidManager MM = (MeteroidManager)GameObject.Find("MeteroidManager").GetComponent("MeteroidManager");
            MM.spawnedMeteroids.Remove(col.gameObject);

            if (isSpeedUpPlanet)
            {
                PlayerController PC = (PlayerController)GameObject.Find("InputManager").GetComponent("PlayerController"); 

                for (int i = 0; i < PC.Obstacles.Capacity; i++)
                {
                    PC.Obstacles[i].GetComponent<BlackHoleSuction>().gravityFactor += obstacleGravityFactorIncrement;

                }

                ObstacleManager OM = (ObstacleManager)GameObject.Find("ObstacleManager").GetComponent("ObstacleManager");
                for (int i = 0; i < OM.obstacles.Length; i++)
                {
                    OM.obstacles[i].GetComponent<BlackHoleSuction>().gravityFactor += obstacleGravityFactorIncrement;
                }

            } else {

                ObstacleManager OM = (ObstacleManager)GameObject.Find("ObstacleManager").GetComponent("ObstacleManager");
                OM.spawnTime -= obstacleSpawnTimeDecrement;

            }
        }
        else if (col.gameObject.tag == "Player")
        {
            Instantiate(Explosion, col.gameObject.transform.position, col.gameObject.transform.rotation);
            AudioSource sound = Explosion.GetComponent<AudioSource>();
            sound.Play();
            Destroy(col.gameObject);
            GameOverObject.SetActive(true);
            UIManager UIM = (UIManager)GameObject.Find("MenuControllerObject").GetComponent<UIManager>();
            UIM.isGameOver = true;
        }
    }

}
