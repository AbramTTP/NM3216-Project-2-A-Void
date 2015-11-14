using UnityEngine;
using System.Collections;

public class ObstacleDestroyMenu : MonoBehaviour {

    public GameObject Explosion;
    public GameObject InstantiateExplosion;

    void start()
    {
        Explosion = GameObject.Find("Explosion");
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Obstacle")
        {
            InstantiateExplosion = (GameObject) Instantiate(Explosion, col.gameObject.transform.position, col.gameObject.transform.rotation);
            AudioSource sound = Explosion.GetComponent<AudioSource>();
            sound.Play();
            Destroy(col.gameObject);
            Destroy(InstantiateExplosion, 1);

            RotationalForceManager PC = (RotationalForceManager)GameObject.Find("RotationalForceManager").GetComponent("RotationalForceManager");
            PC.Obstacles.Remove(col.gameObject);
        }
        else if (col.gameObject.tag == "meteorite")
        {
            InstantiateExplosion = (GameObject) Instantiate(Explosion, col.gameObject.transform.position, col.gameObject.transform.rotation);
            AudioSource sound = Explosion.GetComponent<AudioSource>();
            sound.Play();
            RotationalForceManager PC = (RotationalForceManager)GameObject.Find("RotationalForceManager").GetComponent("RotationalForceManager");
            PC.Obstacles.Remove(this.gameObject);

            Destroy(this.gameObject);
            Destroy(InstantiateExplosion, 1);
        }
        else if (col.gameObject.tag == "Player")
        {
            InstantiateExplosion = (GameObject) Instantiate(Explosion, col.gameObject.transform.position, col.gameObject.transform.rotation);
            AudioSource sound = Explosion.GetComponent<AudioSource>();
            sound.Play();
            Destroy(col.gameObject);

            RotationalForceManager PC = (RotationalForceManager)GameObject.Find("RotationalForceManager").GetComponent("RotationalForceManager");
            PC.Obstacles.Remove(this.gameObject);

            Destroy(this.gameObject);
            Destroy(InstantiateExplosion, 1);

            UIManager UIM = (UIManager)GameObject.Find("MenuControllerObject").GetComponent<UIManager>();
            UIM.isGameOver = true;
        }
    }

}
