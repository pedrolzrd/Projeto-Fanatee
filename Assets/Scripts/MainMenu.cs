using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    public GameObject gameModeUi;

    public void openPopup()
    {
        gameModeUi.SetActive(true);
    }

    public void closePopup()
    {
        gameModeUi.SetActive(false);
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void backToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void QuitGame()
    {
        print("quit game");
        Application.Quit();
    }

 
}
