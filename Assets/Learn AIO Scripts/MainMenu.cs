using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1;

    void Update()
    {
        
    }

    public void PlayAnimalsRush()
    {
        StartCoroutine(LoadScene("Animals Rush"));
    }

    public void PlayDogsandBalls()
    {
        StartCoroutine(LoadScene("DogsAndBalls"));
    }

    public void PlayPlane()
    {
        StartCoroutine(LoadScene("Planes"));
    }

    IEnumerator LoadScene(string sceneName)
    {
        transition.SetTrigger("Start");//Play animation

        yield return new WaitForSeconds(transitionTime);//wait

        SceneManager.LoadScene(sceneName);//Load Scene
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
