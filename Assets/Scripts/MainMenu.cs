using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEditor;
using UnityEditorInternal;

public class MainMenu : MonoBehaviour
{
    public Animator transition;

    public GameObject gameModeUi;

    public GameObject gameModes;

    public GameObject playerSelection;

    [SerializeField]GameObject creditsMenu;

    public float transitionTime = 1;

    public void openPopup()
    {
        gameModeUi.SetActive(true);
    }

    public void PlayerSelectionMenu()
    {
        gameModes.SetActive(false);
        playerSelection.SetActive(true);

    }

    public void closePopup()
    {
        gameModeUi.SetActive(false);
    }
    public void PlayGame()
    {
        StartCoroutine(LoadGame());
    }

    IEnumerator LoadGame()
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene("Game");
    }

    public void PlayGameTeams()
    {
        SceneManager.LoadScene("Game Teams");
    }

    public void backToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void backtoMenu()
    {
        creditsMenu.SetActive(false);
        gameObject.SetActive(true);
    }

 

    public void Credits()
    {
        gameObject.SetActive(false);
        creditsMenu.SetActive(true);
    }
    public void QuitGame()
    {
        print("quit game");
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }


}
