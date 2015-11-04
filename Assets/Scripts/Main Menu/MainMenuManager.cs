using UnityEngine;
using System.Collections;

public class MainMenuManager : MonoBehaviour {

    public GameObject MainMenuObject;
    public GameObject InstructionsObject;
    public GameObject CreditsObject;

	// Use this for initialization
	void Start () {
        MainMenuObject = GameObject.Find("MainMenuObject");
        InstructionsObject = GameObject.Find("InstructionsObject");
        InstructionsObject.SetActive(false);
        CreditsObject = GameObject.Find("CreditObject");
        CreditsObject.SetActive(false);

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
            else if (Input.GetKeyDown(KeyCode.C))
            {
                CreditsObject.SetActive(true);
                MainMenuObject.SetActive(false);
            }
            else if (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.Escape))
            {
                Application.Quit();
            }
        }
        else if (InstructionsObject.activeSelf || CreditsObject.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.B) || Input.GetKeyDown(KeyCode.Escape))
            {
                InstructionsObject.SetActive(false);
                CreditsObject.SetActive(false);
                MainMenuObject.SetActive(true);
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                Application.LoadLevel(1);
            }
        }

	}

    public void PlayButton(int index)
    {
        Application.LoadLevel(index);
    }

    public void InstructionButton(GameObject UIObject)
    {
        UIObject.SetActive(true);
        MainMenuObject.SetActive(false);
    }

    public void BackButton(GameObject UIObject)
    {
        UIObject.SetActive(false);
        MainMenuObject.SetActive(true);
    }

    public void CreditButton(GameObject UIObject)
    {
        UIObject.SetActive(true);
        MainMenuObject.SetActive(false);
    }
    public void QuitButton()
    {
        Application.Quit();
    }
}
