using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class PauseMenuScript : MonoBehaviour
{
    public GameObject pauseMenu;
    private bool isPaused;
    public GameObject ResumeBtn;
    public GameObject RestartBtn;
    private GameObject[] inputs;
    public PlayerController playerScript;
    public TextMeshProUGUI menuText;

    public void Start()
    {
        pauseMenu.SetActive(false);
        if (inputs == null)
        {
            inputs = GameObject.FindGameObjectsWithTag("Input");
        }
        ResumeBtn.SetActive(true);
        RestartBtn.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }

        if(playerScript.health <= 0)
        {
            PauseGame();
        }
    }
    public void NextScene(int sceneBuildIndex)
    {
        Debug.Log("Game has been restarted!");
        SceneManager.LoadScene(sceneBuildIndex);
        Time.timeScale = 1f;
    }

    public void Quit(int sceneBuildIndex)
    {
        Debug.Log("Game has been exited to main Menu!");
        SceneManager.LoadScene(sceneBuildIndex);
    }

    public void PauseGame()
    {
        Debug.Log("Game Paused");
        if (playerScript.health <= 0)
        {
            menuText.text = "game over";
            RestartBtn.SetActive(true);
            ResumeBtn.SetActive(false);
        }
        else
        {
            menuText.text = "paused";
            RestartBtn.SetActive(false);
            ResumeBtn.SetActive(true);
        }
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        foreach (GameObject input in inputs)
        {
            input.SetActive(false);
        }
        
        isPaused = true;

    }

    public void ResumeGame()
    {
        Debug.Log("Game Resumed");
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        foreach (GameObject input in inputs)
        {
            input.SetActive(true);
        }
        Time.timeScale = 1f;
        isPaused = false;
    }
}
