using UnityEngine;
using System.Collections;

public class ObstacleDestroy : MonoBehaviour {

    public GameObject Explosion;
    public GameObject GameOverObject;

    public float rotationSpeedIncrement;

    void start()
    {
        Explosion = GameObject.Find("Explosion");
        GameOverObject = GameObject.Find("GameOverMenuObject");

        rotationSpeedIncrement = 0.001f;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Obstacle")
        {
            Instantiate(Explosion, col.gameObject.transform.position, col.gameObject.transform.rotation);
            Destroy(col.gameObject);

            PlayerController PC = (PlayerController)GameObject.Find("InputManager").GetComponent("PlayerController");
            PC.Obstacles.Remove(col.gameObject);
            PC.fluidRotationSpeed += rotationSpeedIncrement;
        }
        else if (col.gameObject.tag == "Meteroid")
        {
            Instantiate(Explosion, col.gameObject.transform.position, col.gameObject.transform.rotation);
            PlayerController PC = (PlayerController)GameObject.Find("InputManager").GetComponent("PlayerController");
            PC.Obstacles.Remove(this.gameObject);

            Destroy(this.gameObject);
        }
        else if (col.gameObject.tag == "Player")
        {
            Instantiate(Explosion, col.gameObject.transform.position, col.gameObject.transform.rotation);
            Destroy(col.gameObject);

            PlayerController PC = (PlayerController)GameObject.Find("InputManager").GetComponent("PlayerController");
            PC.Obstacles.Remove(this.gameObject);

            Destroy(this.gameObject);

            GameOverObject.SetActive(true);

            UIManager UIM = (UIManager)GameObject.Find("MenuControllerObject").GetComponent<UIManager>();
            UIM.isGameOver = true;
        }
    }

}
