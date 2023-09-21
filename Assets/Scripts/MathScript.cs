using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Experimental.GraphView.GraphView;

public class MathScript : MonoBehaviour
{
    public Text operationText;
    public Text correctAwnsersText;
    public Text winGameTotalPoints;
    public GameObject wingGameUi;
    public int correctAnwsers;
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
        //correctAwnsersText.text = correctAnwsers.ToString();
        correctAwnsersText.text = correctAnwsers + "/" + operations.Length;

    }

    void Update()
    {
        
    }  

    private void OnTriggerEnter(Collider other)
    {

        if(other.tag == "Number")
        {
            Number number = other.gameObject.GetComponent<Number>();
            Destroy(other.gameObject);
            player.GetComponent<SimpleSampleCharacterControl>().colected = false;
            player2.GetComponent<SimpleSampleCharacterControl>().colectedByPlayer2 = false;

            if (number.value == results[actualOperationIndex])
            {
                print("acertou");
                StartCoroutine(changeCoinColorGreen());
                actualOperationIndex++;
                correctAnwsers++;
                correctAwnsersText.text = correctAnwsers + "/" + operations.Length;
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
