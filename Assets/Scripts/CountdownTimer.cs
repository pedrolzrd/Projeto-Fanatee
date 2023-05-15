using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{

    public Text countDownText;
    [SerializeField]
    private float totalTime = 300f; // 5 minutos em segundos
    private float timeLeft;


    // Start is called before the first frame update
    void Start()
    {
        timeLeft = totalTime;
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;

        int minutes = Mathf.FloorToInt(timeLeft / 60f);
        int seconds = Mathf.FloorToInt(timeLeft % 60f);


        countDownText.text = string.Format("{0:00}:{1:00}", minutes, seconds);


        if(timeLeft <= 0f)
        {
            Debug.Log("Fim da contagem");
            enabled = false;
        }

    }
}
