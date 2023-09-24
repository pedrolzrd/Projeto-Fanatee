using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MathScript : MonoBehaviour
{
    public Text scoreP1;
    public Text scoreP2;
    public Text operationText;
    public Text correctAwnsersText;
    public Text winGameTotalPoints;
    public GameObject wingGameUi;
    public int correctAnwsers;
    public int correctAnwsersP1;
    public int correctAnwsersP2;
    private int actualOperationIndex;
    private string[] operations = { "2 + 3", "2 x 2", "4 - 1", "4 x 2", "0 + 3", "7 x 1", "3 + 2","1 + 8", "0 x 9", "3 - 3","3 + 4","9 - 0","2 + 7","5 - 3"};
    public int operationsLength;

    private int[] results = {5, 4, 3, 8, 3, 7, 5, 9, 0, 0, 7, 9, 9, 2};
    GameObject player;
    GameObject player2;
    [SerializeField]
    AudioSource rightSound;
    [SerializeField]
    AudioSource wrongSound;

    [SerializeField]
    float timeToVerify = 0.2f;

    [SerializeField]
    Color goldMaterial;

    [SerializeField]
    GameObject coin;

    void Start()
    {
        operationsLength = operations.Length;
        player = GameObject.FindGameObjectWithTag("Player");
        player2 = GameObject.FindGameObjectWithTag("Player 2");
        actualOperationIndex = 0;
        operationText.text = string.Format(operations[actualOperationIndex]);
        correctAnwsers = 0;
        correctAnwsersP1 = 0;
        correctAnwsersP2 = 0;
        //correctAwnsersText.text = correctAnwsers.ToString();
        correctAwnsersText.text = correctAnwsers + "/" + operations.Length;

    }

    void Update()
    {
        
    }  

    private void OnTriggerEnter(Collider other)
    {

        if(other.CompareTag("CollectedNumberP1") || other.CompareTag("CollectedNumberP2"))
        {
            Number number = other.gameObject.GetComponent<Number>();
            Destroy(other.gameObject);

            bool wasCollectedByPlayer1 = player.GetComponent<Player1>().colected;

            player.GetComponent<Player1>().colected = false;
            player2.GetComponent<Player2>().colectedByPlayer2 = false;
                
            if (number.value == results[actualOperationIndex])
            {
                print("acertou");
                StartCoroutine(changeCoinColorGreen());
                actualOperationIndex++;
                correctAnwsers++;
                correctAwnsersText.text = correctAnwsers + "/" + operations.Length;

                if(wasCollectedByPlayer1) {
                    correctAnwsersP1++;
                    player.GetComponent<Player1>().p1CanSteal = true;  
                    scoreP1.text = correctAnwsersP1.ToString();
                }else{
                    correctAnwsersP2++;
                    player2.GetComponent <Player2>().p2CanSteal = true;
                    scoreP2.text = correctAnwsersP2.ToString();
                }

                if (actualOperationIndex < operations.Length)
                {
                    operationText.text = string.Format(operations[actualOperationIndex]);
                }
                else
                {
                    print("ganhou!");
                    wingGameUi.SetActive(true);
                    winGameTotalPoints.text = correctAnwsers + "/" + operations.Length;
                   
                }
                
            }
            else
            {
                print("erro");
                StartCoroutine(changeCoinColorRed());
            }
        }
    }

    IEnumerator changeCoinColorGreen()
    {
        coin.GetComponent<MeshRenderer>().material.color = Color.green;
        rightSound.Play();
        yield return new WaitForSeconds(timeToVerify);
        coin.GetComponent<MeshRenderer>().material.color = goldMaterial;
    }

    IEnumerator changeCoinColorRed()
    {
        coin.GetComponent<MeshRenderer>().material.color = Color.red;
        wrongSound.Play();
        yield return new WaitForSeconds(timeToVerify);
        coin.GetComponent<MeshRenderer>().material.color = goldMaterial;
    }
}
