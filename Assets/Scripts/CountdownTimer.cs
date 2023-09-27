using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{

    public Text finalScoreP1;
    public Text finalScoreP2;
    
    public GameObject crownP1;
    public GameObject crownP2;

    public GameObject controlsHud;

    public Text countDownText;
    public Text totalPointsText;
    public GameObject countDownUi;
    GameObject numbercollector;
    GameObject player;
    GameObject player2;
    [SerializeField]
    private float totalTime = 120f; // 300f 5 minutos em segundos
    public float timeLeft;

    PlayerInput p1;
    PlayerInput p2;

    void Start()
    {
        timeLeft = totalTime;
        numbercollector = GameObject.FindGameObjectWithTag("NumberCollector");
        numbercollector = GameObject.FindGameObjectWithTag("NumberCollector");
        player = GameObject.FindGameObjectWithTag("Player");
        player2 = GameObject.FindGameObjectWithTag("Player 2");

        p1 = player.GetComponent<PlayerInput>();    
        p2 = player2.GetComponent<PlayerInput>();   

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

        if (timeLeft <= 0f || Input.GetKeyDown(KeyCode.Escape))
        {
            countDownUi.SetActive(true);
            //player.SetActive(false);
            controlsHud.SetActive(false);

            p1.SwitchCurrentActionMap("DisableControlMap");
            p2.SwitchCurrentActionMap("DisableControlMap");

            //Debug.Log("Fim da contagem");

            finalScoreP1.text = scoreP1.text;
            finalScoreP2.text = scoreP2.text;

            int pointsP1 = int.Parse(scoreP1.text);
            int pointsP2 = int.Parse(scoreP2.text);

            crownP1.SetActive(pointsP1 > 0 && pointsP1 >= pointsP2);
            crownP2.SetActive(pointsP2 > 0 && pointsP2 >= pointsP1);

            //totalPointsText.text = totalPoints.ToString() + "/" + totalAwsers;
            enabled = false;

            // Time. timeScale = 0;           
        }

    }
}
