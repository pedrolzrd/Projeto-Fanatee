using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Peça : MonoBehaviour
{
    //Variaveis
    int id;
    [SerializeField]
    float timeToDestroy;
    [SerializeField]
    float timeToColect;
    bool colected = false;

    //Objetos/Componentes
    GameObject spawner;
    GameObject player;
    IEnumerator destroyCoroutine;

    private void Start()
    {
        destroyCoroutine = destroyLifetime();
        id = Random.Range(1, 5);
        spawner = GameObject.FindGameObjectWithTag("Spawner");
        player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(destroyCoroutine);
    }

    private void Update()
    {
        if(id == player.GetComponent<Player>().id) 
        {
            this.GetComponent<MeshRenderer>().material.color = Color.blue;
        }

        if(colected == true)
        {
            transform.position = new Vector3(player.transform.position.x, 4, player.transform.position.z);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && player.GetComponent<Player>().id == id)
        {
            colected = true;
            StopCoroutine(destroyCoroutine);
            StartCoroutine(colect());
        }
    }

    IEnumerator colect()
    {
        yield return new WaitForSeconds(timeToColect);

        player.GetComponent<CountPoints>().points++;
        print(player.GetComponent<CountPoints>().points);
        Destroy(gameObject, 0.1f);
    }

    IEnumerator destroyLifetime()
    {
        yield return new WaitForSeconds(timeToDestroy);
        Destroy(gameObject);
        spawner.GetComponent<Spawner>().spawned--;
    }
}
