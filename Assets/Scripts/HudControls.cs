using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HudControls : MonoBehaviour
{
    [SerializeField]GameObject controlsButtonOFF;
    [SerializeField]GameObject controlsButtonON;

    [SerializeField]CanvasGroup controlsCanvasGroup;
    void Awake()
    {
        controlsCanvasGroup = GetComponent<CanvasGroup>();  
    }

   
    void Update()
    {
        
    }

    public void MobileControlsOFF()
    {
        // mudar logica
        controlsCanvasGroup.LeanAlpha(0, 0.2f);
        controlsButtonOFF.SetActive(false);
        controlsButtonON.SetActive(true);
    }
    public void MobileControlsON()
    {
        controlsCanvasGroup.LeanAlpha(1, 0.2f);
        controlsButtonOFF.SetActive(true);
        controlsButtonON.SetActive(false);
    }
}
