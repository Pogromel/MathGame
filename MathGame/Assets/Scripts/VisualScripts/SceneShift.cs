using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class SceneShift : MonoBehaviour
{ 
    public void NextScene(int sceneBuildIndex)
    {
        SceneManager.LoadScene("Game");
    }

    public void Quit()
    {
        Debug.Log("Game has been exited!");
        Application.Quit();
    }

    public void Restart()
    {
        Debug.Log("Game Restarted");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
