using UnityEngine;
using System.Collections;

public class BlackHoleDestroy : MonoBehaviour {

    public GameObject Explosion;
    public GameObject GameOverObject;

    public float gravityFactorIncrement;

    void start()
    {
        Explosion = GameObject.Find("Explosion");
        GameOverObject = GameObject.Find("GameOverMenuObject");

        gravityFactorIncrement = 0.25f;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Obstacle")
        {
            Instantiate(Explosion, col.gameObject.transform.position, col.gameObject.transform.rotation);
            Destroy(col.gameObject);

            PlayerController PC = (PlayerController)GameObject.Find("InputManager").GetComponent("PlayerController");           
            PC.Obstacles.Remove(col.gameObject);

            for (int i = 0; i < PC.Obstacles.Capacity; i++)
            {
                PC.Obstacles[i].GetComponent<BlackHoleSuction>().gravityFactor += gravityFactorIncrement;
            }

            ObstacleManager OM = (ObstacleManager)GameObject.Find("ObstacleManager").GetComponent("ObstacleManager");
            for (int i = 0; i < OM.obstacles.Length; i++)
            {
                OM.obstacles[i].GetComponent<BlackHoleSuction>().gravityFactor += gravityFactorIncrement;
            }
        }
        else if (col.gameObject.tag == "Meteroid")
        {
            Instantiate(Explosion, col.gameObject.transform.position, col.gameObject.transform.rotation);
            Destroy(col.gameObject);

            MeteroidManager MM = (MeteroidManager)GameObject.Find("MeteroidManager").GetComponent("MeteroidManager");
            MM.spawnedMeteroids.Remove(col.gameObject);

            PlayerController PC = (PlayerController)GameObject.Find("InputManager").GetComponent("PlayerController"); 

            for (int i = 0; i < PC.Obstacles.Capacity; i++)
            {
                PC.Obstacles[i].GetComponent<BlackHoleSuction>().gravityFactor += gravityFactorIncrement;
            }

            ObstacleManager OM = (ObstacleManager)GameObject.Find("ObstacleManager").GetComponent("ObstacleManager");
            for (int i = 0; i < OM.obstacles.Length; i++)
            {
                OM.obstacles[i].GetComponent<BlackHoleSuction>().gravityFactor += gravityFactorIncrement;
            }
        }
        else if (col.gameObject.tag == "Player")
        {
            Instantiate(Explosion, col.gameObject.transform.position, col.gameObject.transform.rotation);
            Destroy(col.gameObject);
            GameOverObject.SetActive(true);
            UIManager UIM = (UIManager)GameObject.Find("MenuControllerObject").GetComponent<UIManager>();
            UIM.isGameOver = true;
        }
    }

}
