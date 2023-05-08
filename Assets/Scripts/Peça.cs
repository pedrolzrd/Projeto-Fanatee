using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Peça : MonoBehaviour
{
    GameObject spawner;

    private void Start()
    {
        spawner = GameObject.FindGameObjectWithTag("Spawner");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
            spawner.GetComponent<Spawner>().spawned--;
        }
    }
}
