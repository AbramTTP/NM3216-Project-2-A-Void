using UnityEngine;
using System.Collections;

public class BlackHoleDestroyMenu : MonoBehaviour {

    public GameObject Explosion;
    public GameObject InstantiateExplosion;

    public float obstacleGravityFactorIncrement;
    public float obstacleSpawnTimeDecrement;
    public bool isSpeedUpPlanet;

    void start()
    {
        Explosion = GameObject.Find("Explosion");

        obstacleGravityFactorIncrement = 0.25f;
        obstacleSpawnTimeDecrement = 0.01f;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Obstacle")
        {
            InstantiateExplosion = (GameObject)Instantiate(Explosion, col.gameObject.transform.position, col.gameObject.transform.rotation);
            AudioSource sound = Explosion.GetComponent<AudioSource>();
            sound.Play();
            Destroy(col.gameObject);
            Destroy(InstantiateExplosion, 1);

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
        else if (col.gameObject.tag == "Meteorite")
        {
            InstantiateExplosion = (GameObject) Instantiate(Explosion, col.gameObject.transform.position, col.gameObject.transform.rotation);
            AudioSource sound = Explosion.GetComponent<AudioSource>();
            sound.Play();
            Destroy(col.gameObject);
            Destroy(InstantiateExplosion, 1);

            MeteoritesManager MM = (MeteoritesManager)GameObject.Find("meteoritesManager").GetComponent("MeteoritesManager");
            MM.spawnedmeteorites.Remove(col.gameObject);

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
            InstantiateExplosion = (GameObject) Instantiate(Explosion, col.gameObject.transform.position, col.gameObject.transform.rotation);
            AudioSource sound = Explosion.GetComponent<AudioSource>();
            sound.Play();
            Destroy(col.gameObject);
            Destroy(InstantiateExplosion, 1);
            UIManager UIM = (UIManager)GameObject.Find("MenuControllerObject").GetComponent<UIManager>();
            UIM.isGameOver = true;
        }
    }

}
