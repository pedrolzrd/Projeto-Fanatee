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
    string[] operations = { "2 + 2", "3 + 3", "2 x 4"};
    int[] results = { 4, 6, 8 };
    GameObject player;
    [SerializeField]
    GameObject lanterna;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        actualOperationIndex = 0;
        operationText.text = string.Format(operations[actualOperationIndex]);
        correctAnwsers = 0;
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
                correctAwnsersText.text = correctAnwsers + "/" + operations.Length;
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
        lanterna.GetComponent<MeshRenderer>().material.color = Color.green;
        yield return new WaitForSeconds(1f);
        lanterna.GetComponent<MeshRenderer>().material.color = Color.white;
    }

    IEnumerator changeCoinColorRed()
    {
        lanterna.GetComponent<MeshRenderer>().material.color = Color.red;
        yield return new WaitForSeconds(1f);
        lanterna.GetComponent<MeshRenderer>().material.color = Color.white;
    }
}
