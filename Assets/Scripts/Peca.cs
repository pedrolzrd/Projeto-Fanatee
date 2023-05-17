using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Peca : MonoBehaviour
{
    //Variaveis
    public int id;
    [SerializeField]
    float timeToDestroy;
    [SerializeField]
    float timeToColect;
    bool colected = false;

    //Objetos/Componentes
    GameObject spawner;
    GameObject player;
    GameObject operador;
    IEnumerator destroyCoroutine;

    private void Start()
    {
        destroyCoroutine = destroyLifetime();
        id = Random.Range(0, 5);
        spawner = GameObject.FindGameObjectWithTag("Spawner");
        player = GameObject.FindGameObjectWithTag("Player");
        operador = GameObject.FindGameObjectWithTag("Operator");
        StartCoroutine(destroyCoroutine);
    }

    private void Update()
    {
        if(id == 0)
        {
            this.GetComponent<MeshRenderer>().material.color = Color.red;
        }
        else if(id == 1)
        {
            this.GetComponent<MeshRenderer>().material.color = Color.green;
        }
        else if(id == 2)
        {
            this.GetComponent<MeshRenderer>().material.color = Color.cyan;
        }
        else if(id == 3)
        {
            this.GetComponent<MeshRenderer>().material.color = Color.black;
        }
        else if(id == 4)
        {
            this.GetComponent<MeshRenderer>().material.color = Color.white;
        } 
        //muda a cor da bolinha de acordo com o numero dela, não tá muito inteligente mas funcionou bem

        /*
        if (id == operador.GetComponent<OperationsGenerator>().c)
        {
            this.GetComponent<MeshRenderer>().material.color = Color.blue;
        }
        */

        if(colected == true)
        {
            transform.position = new Vector3(player.transform.position.x, 4, player.transform.position.z);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            colected = true;
            StopCoroutine(destroyCoroutine);
            //StartCoroutine(colect());
        }
    }

    /*
    IEnumerator colect()
    {
        yield return new WaitForSeconds(timeToColect);

        player.GetComponent<CountPoints>().points++;
        print(player.GetComponent<CountPoints>().points);
        Destroy(gameObject, 0.1f);
    }
    */

    IEnumerator destroyLifetime()
    {
        yield return new WaitForSeconds(timeToDestroy);
        Destroy(gameObject);
        spawner.GetComponent<Spawner>().spawned--;
    }
}
