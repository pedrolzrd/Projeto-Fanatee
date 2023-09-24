using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{

    public Text finalScoreP1;
    public Text finalScoreP2;

    public Text countDownText;
    public Text totalPointsText;
    public GameObject countDownUi;
    GameObject numbercollector;
    GameObject player;
    GameObject player2;

    [SerializeField]
    private float totalTime = 120f; // 300f 5 minutos em segundos
    public float timeLeft;

    void Start()
    {
        timeLeft = totalTime;
        numbercollector = GameObject.FindGameObjectWithTag("NumberCollector");
        numbercollector = GameObject.FindGameObjectWithTag("NumberCollector");
        player = GameObject.FindGameObjectWithTag("Player");
        player2 = GameObject.FindGameObjectWithTag("Player 2");
    }


    void Update()
    {
        timeLeft -= Time.deltaTime;

        int minutes = Mathf.FloorToInt(timeLeft / 60f);
        int seconds = Mathf.FloorToInt(timeLeft % 60f);


        countDownText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        Text scoreP1 = numbercollector.GetComponent<MathScript>().scoreP1;
        Text scoreP2 = numbercollector.GetComponent<MathScript>().scoreP2;

        int totalPoints = numbercollector.GetComponent<MathScript>().correctAnwsers;
        int totalAwsers = numbercollector.GetComponent<MathScript>().operationsLength;

        if (timeLeft <= 0f)
        {
            countDownUi.SetActive(true);
            player.SetActive(false);
            player2.SetActive(false);
            Debug.Log("Fim da contagem");
            finalScoreP1.text = scoreP1.text;
            finalScoreP2.text = scoreP2.text;
            totalPointsText.text = totalPoints.ToString() + "/" + totalAwsers;
            enabled = false;
           
        }

    }
}
