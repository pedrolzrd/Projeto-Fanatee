using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MathScript : MonoBehaviour
{
    public Text operationText;
    public Text correctAwnsersText;
    private int correctAnwsers;
    private int actualOperationIndex;
    string[] operations = { "2 + 3",
    "4 - 1",
    "0 + 3",
    "3 + 2",
    "1 + 8",
    "3 - 3",
    "3 + 4",
    "9 - 0",
    "2 + 7",
    "5 - 3",
    "1 + 4",
    "4 - 2",
    "0 + 1",
    "3 - 2",
    "6 + 3",
  };

    int[] results = {  5,
    3,
    3,
    5,
    9,
    0,
    7,
    9,
    9,
    2,
    5,
    2,
    1,
    1,
    9,
    };
    GameObject player;
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

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        actualOperationIndex = 0;
        operationText.text = string.Format(operations[actualOperationIndex]);
        correctAnwsers = 0;
        //correctAwnsersText.text = correctAnwsers.ToString();
        correctAwnsersText.text = correctAnwsers + "/" + operations.Length;

    }

    // Update is called once per frame
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
           
            if (number.value == results[actualOperationIndex])
            {
                print("acertou");
                StartCoroutine(changeCoinColorGreen());
               actualOperationIndex++;
                correctAnwsers++;
                correctAwnsersText.text = correctAnwsers.ToString();
                if (actualOperationIndex < operations.Length)
                {
                    operationText.text = string.Format(operations[actualOperationIndex]);
                }
                else
                {
                    print("ganhou!");
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
