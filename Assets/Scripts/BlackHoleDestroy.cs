using UnityEngine;
using System.Collections;

public class BlackHoleDestroy : MonoBehaviour {

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Obstacle")
        {
            Destroy(col.gameObject);

            PlayerController PC = (PlayerController)GameObject.Find("InputManager").GetComponent("PlayerController");
            PC.obstacles.Remove(col.gameObject);

        }
    }

}
