﻿using UnityEngine;
using System.Collections;

public class ObstacleDestroy : MonoBehaviour {

    public GameObject Explosion;
    public GameObject InstantiateExplosion;
    public GameObject GameOverObject;

    void start()
    {
        Explosion = GameObject.Find("Explosion");
        GameOverObject = GameObject.Find("GameOverCollisionMenuObject");
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

            PlayerController PC = (PlayerController)GameObject.Find("InputManager").GetComponent("PlayerController");
            PC.Obstacles.Remove(col.gameObject);
        }
        else if (col.gameObject.tag == "Meteorite")
        {
            InstantiateExplosion = (GameObject) Instantiate(Explosion, col.gameObject.transform.position, col.gameObject.transform.rotation);
            AudioSource sound = Explosion.GetComponent<AudioSource>();
            sound.Play();
            PlayerController PC = (PlayerController)GameObject.Find("InputManager").GetComponent("PlayerController");
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

            PlayerController PC = (PlayerController)GameObject.Find("InputManager").GetComponent("PlayerController");
            PC.Obstacles.Remove(this.gameObject);

            Destroy(this.gameObject);
            Destroy(InstantiateExplosion, 1);

            GameOverObject.SetActive(true);

            UIManager UIM = (UIManager)GameObject.Find("MenuControllerObject").GetComponent<UIManager>();
            UIM.isGameOver = true;
        }
    }

}
