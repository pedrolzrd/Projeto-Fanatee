using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{

    public Text countDownText;
    public Text totalPointsText;
    public GameObject countDownUi;
     GameObject numbercollector;
    GameObject player;
    [SerializeField]
    private float totalTime = 120f; // 300f 5 minutos em segundos
    private float timeLeft;

    


    // Start is called before the first frame update
    void Start()
    {
        timeLeft = totalTime;
        numbercollector = GameObject.FindGameObjectWithTag("NumberCollector");
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;

        int minutes = Mathf.FloorToInt(timeLeft / 60f);
        int seconds = Mathf.FloorToInt(timeLeft % 60f);


        countDownText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        int totalPoints = numbercollector.GetComponent<MathScript>().correctAnwsers;
        int totalAwsers = numbercollector.GetComponent<MathScript>().operationsLength;

        if (timeLeft <= 0f)
        {
            countDownUi.SetActive(true);
            Debug.Log("Fim da contagem");
            totalPointsText.text = totalPoints.ToString() + "/" + totalAwsers;
            enabled = false;
           
        }

    }
}
