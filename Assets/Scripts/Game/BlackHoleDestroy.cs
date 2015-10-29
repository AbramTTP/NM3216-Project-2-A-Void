using UnityEngine;
using System.Collections;

public class BlackHoleDestroy : MonoBehaviour {

    public GameObject Explosion;
    public GameObject GameOverObject;

    void start()
    {
        Explosion = GameObject.Find("Explosion");
        GameOverObject = GameObject.Find("GameOverMenuObject");
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Obstacle")
        {
            Instantiate(Explosion, col.gameObject.transform.position, col.gameObject.transform.rotation);
            Destroy(col.gameObject);

            PlayerController PC = (PlayerController)GameObject.Find("InputManager").GetComponent("PlayerController");           
            PC.Obstacles.Remove(col.gameObject);
        }
        else if (col.gameObject.tag == "Meteroid")
        {
            Instantiate(Explosion, col.gameObject.transform.position, col.gameObject.transform.rotation);
            Destroy(col.gameObject);

            MeteroidManager MM = (MeteroidManager)GameObject.Find("MeteroidManager").GetComponent("MeteroidManager");
            MM.spawnedMeteroids.Remove(col.gameObject);
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
