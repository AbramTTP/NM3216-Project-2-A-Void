using UnityEngine;
using System.Collections;

public class GameStateManager : MonoBehaviour {

    public bool isAlive = true; // The amount of health the player starts the game with.
    public bool gameOver = false;
    public GameObject CanvasObject;

    void start()
    {
        isAlive = true;
        gameOver = false;
        CanvasObject = GameObject.FindGameObjectWithTag("Canvas");
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Whirlpool")
        {
            Death();
        }
    }

    void Death()
    {
        // Set the death flag so this function won't be called again.
        isAlive = false;

        CanvasObject.SetActive(true);

        // Turn off any remaining shooting effects.
        //playerShooting.DisableEffects();

        // Tell the animator that the player is dead.
        //anim.SetTrigger("Die");

        // Set the audiosource to play the death clip and play it (this will stop the hurt sound from playing).
        //playerAudio.clip = deathClip;
        //playerAudio.Play();

        // Turn off the movement and shooting scripts.
        //playerMovement.enabled = false;
        //playerShooting.enabled = false;
    }

}
