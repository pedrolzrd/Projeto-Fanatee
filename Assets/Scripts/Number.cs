using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Number : MonoBehaviour
{
    public int value;
    [SerializeField]
    float timeToDestroy;
    bool colected = false;

    GameObject spawner;
    GameObject player;
    IEnumerator destroyCoroutine;

    private void Start()
    {
        destroyCoroutine = destroyLifetime();
        spawner = GameObject.FindGameObjectWithTag("Spawner");
        player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(destroyCoroutine);
    }

    private void Update()
    {
        if (colected == true)
        {
            transform.position = new Vector3(player.transform.position.x, 4, player.transform.position.z);
        }
        if (Input.GetKeyDown(KeyCode.F) && colected == true)
        {
            Destroy(gameObject);
            player.GetComponent<SimpleSampleCharacterControl>().colected = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && player.GetComponent<SimpleSampleCharacterControl>().colected == false)
        {
            colected = true;
            player.GetComponent<SimpleSampleCharacterControl>().colected = true;
            StopCoroutine(destroyCoroutine);
            //StartCoroutine(colect());
        }
    }

    IEnumerator destroyLifetime()
    {
        yield return new WaitForSeconds(timeToDestroy);
        Destroy(gameObject);
        spawner.GetComponent<Spawner>().spawned--;
    }
}
