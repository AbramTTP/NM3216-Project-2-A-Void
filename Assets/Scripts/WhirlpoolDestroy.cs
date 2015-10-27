using UnityEngine;
using System.Collections;

public class WhirlpoolDestroy : MonoBehaviour {

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Obstacles")
        {
            Destroy(col.gameObject);

            PlayerController PC = (PlayerController)GameObject.Find("InputManager").GetComponent("PlayerController");
            PC.obstacles.Remove(col.gameObject);

        }
    }

}
