using UnityEngine;
using System.Collections;

public class MainMenuManager : MonoBehaviour {

    public GameObject MainMenuObject;
    public GameObject InstructionsObject;

	// Use this for initialization
	void Start () {
        MainMenuObject = GameObject.Find("MainMenuObject");
        InstructionsObject = GameObject.Find("InstructionsObject");
        InstructionsObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {

        if (MainMenuObject.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                Application.LoadLevel(1);
            }
            else if (Input.GetKeyDown(KeyCode.H))
            {
                InstructionsObject.SetActive(true);
                MainMenuObject.SetActive(false);
            }
            else if (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.Escape))
            {
                Application.Quit();
            }
        }
        else if (InstructionsObject.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.B) || Input.GetKeyDown(KeyCode.Escape))
            {
                InstructionsObject.SetActive(false);
                MainMenuObject.SetActive(true);
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                Application.LoadLevel(1);
            }
        }

	}
}
