using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour {

    public GameObject PauseMenuObject;
    public GameObject GameOverBlackHoleObject;
    public GameObject GameOverCollisionObject;
    public GameObject PromptQuitObject;

    public bool isGameOver;
    public bool isPaused; 

    // Use this for initialization
    void Start()
    {
        GameOverBlackHoleObject = GameObject.Find("GameOverBlackHoleMenuObject");
        GameOverCollisionObject = GameObject.Find("GameOverCollisionMenuObject");
        PromptQuitObject = GameObject.Find("PromptQuitMenuObject");
        PauseMenuObject = GameObject.Find("PauseMenuObject");
        PromptQuitObject.SetActive(false);
        GameOverBlackHoleObject.SetActive(false);
        GameOverCollisionObject.SetActive(false);
        PauseMenuObject.SetActive(false);

        isGameOver = false;
        isPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (!isPaused && !isGameOver)
            {
                PauseMenuObject.SetActive(true);
                Time.timeScale = 0.0f;
                isPaused = true;
            }
            else if (isPaused && !isGameOver && !PromptQuitObject.activeSelf)
            {
                PauseMenuObject.SetActive(false);
                Time.timeScale = 1.0f;
                isPaused = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused && PauseMenuObject.activeSelf && PromptQuitObject.activeSelf)
            {
                PromptQuitObject.SetActive(false);
            }
            else if (isPaused && PauseMenuObject.activeSelf && !PromptQuitObject.activeSelf)
            {
                PauseMenuObject.SetActive(false);
                Time.timeScale = 1.0f;
                isPaused = false;
            }
            else if (!isPaused && !isGameOver)
            {
                PauseMenuObject.SetActive(true);
                Time.timeScale = 0.0f;
                isPaused = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            if ((isPaused && PauseMenuObject.activeSelf) || (isGameOver && (GameOverBlackHoleObject.activeSelf || GameOverCollisionObject.activeSelf)))
            {
                PromptQuitObject.SetActive(true);
            }
        }

        if (Input.GetKeyDown(KeyCode.Y))
        {
            if (PromptQuitObject.activeSelf)
            {
                Time.timeScale = 1.0f;
                Application.LoadLevel(0);
            }
        }

        if (Input.GetKeyDown(KeyCode.N))
        {
            PromptQuitObject.SetActive(false);
            if(isGameOver){
                GameOverBlackHoleObject.SetActive(true);
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            if (isGameOver && (GameOverBlackHoleObject.activeSelf || GameOverCollisionObject.activeSelf) && !PromptQuitObject.activeSelf)
                Application.LoadLevel(Application.loadedLevel);
        }
    }

    public void YesButton()
    {
        Time.timeScale = 1.0f;
        Application.LoadLevel(0);
    }

    public void NoButtonShow(GameObject UIObject)
    {
        UIObject.SetActive(true);
    }
    public void NoButtonHide(GameObject UIObject)
    {
        UIObject.SetActive(false);
    }

    public void QuitButtonShow(GameObject UIObject)
    {
        UIObject.SetActive(true);
    }

    public void QuitButtonHide(GameObject UIObject)
    {
        UIObject.SetActive(false);
    }

    public void ResumeButton(GameObject UIObject)
    {
        UIObject.SetActive(false);
        Time.timeScale = 1.0f;
        isPaused = false;
    }

    public void RetryButton()
    {
        Application.LoadLevel(1);
    }

}
