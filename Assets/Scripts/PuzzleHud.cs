using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleHud : MonoBehaviour
{
    [SerializeField]
    Image puzzleBG;
    [SerializeField]
    Button buttonBG;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            puzzleBG.gameObject.SetActive(true);
            buttonBG.gameObject.SetActive(true);
        }
        else if(Input.GetKeyUp(KeyCode.P))
        {
            CloseHUD();
        }
    }

    public void Button()
    {
        CloseHUD();
    }

    void CloseHUD()
    {
        puzzleBG.gameObject.SetActive(false);
        buttonBG.gameObject.SetActive(false);
    }
}
