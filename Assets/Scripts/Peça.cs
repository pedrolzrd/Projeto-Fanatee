using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Peça : MonoBehaviour
{
    //Variaveis
    int id;

    //Objetos/Componentes
    GameObject spawner;
    GameObject player;

    private void Start()
    {
        id = Random.Range(1, 5);
        spawner = GameObject.FindGameObjectWithTag("Spawner");
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if(id == player.GetComponent<Player>().id) 
        {
            this.GetComponent<MeshRenderer>().material.color = Color.blue;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && player.GetComponent<Player>().id == id)
        {
            Destroy(gameObject);
            spawner.GetComponent<Spawner>().spawned--;
        }
    }
}
