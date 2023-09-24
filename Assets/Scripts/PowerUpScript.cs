using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpScript : MonoBehaviour
{
    [SerializeField]
    float timeToDestroy;
    bool colected = false;
    bool collectByPlayer2 = false;

    GameObject powerUpSpawner;
    GameObject player;
    GameObject player2;

    IEnumerator destroyCoroutine;

    void Start()
    {
        transform.Rotate(-45f, 0, 0);
        destroyCoroutine = destroyLifetime();
        powerUpSpawner = GameObject.FindGameObjectWithTag("PowerUpSpawner");
        player = GameObject.FindGameObjectWithTag("Player");
        player2 = GameObject.FindGameObjectWithTag("Player 2");
        StartCoroutine(destroyCoroutine);
    }

    
    void Update()
    {
        if (colected == true)
        {
            transform.position = new Vector3(player.transform.position.x, 6, player.transform.position.z);
        }

        if (collectByPlayer2 == true)
        {
            transform.position = new Vector3(player2.transform.position.x, 6, player2.transform.position.z);
        }
        if (Input.GetKeyDown(KeyCode.F) && colected == true)
        {
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && player.GetComponent<Player1>().powerUpColected == false)
        {
            colected = true;
            player.GetComponent<Player1>().powerUpColected = true;
            
            StartCoroutine(PowerUpSpeed());
            StopCoroutine(destroyCoroutine);
        }


        if (other.CompareTag("Player 2") && player2.GetComponent<Player2>().powerUpColectedByPlayer2 == false)
        {
            collectByPlayer2 = true;
            player2.GetComponent<Player2>().powerUpColectedByPlayer2 = true;

            StartCoroutine(PowerUpSpeedPlayer2());
            StopCoroutine(destroyCoroutine);
        }
    }
    IEnumerator destroyLifetime()
    {
        yield return new WaitForSeconds(timeToDestroy);
        Destroy(gameObject);
        powerUpSpawner.GetComponent<PowerUpSpawner>().spawned--;
    }

    IEnumerator PowerUpSpeed()
    {
        player.GetComponent<Player1>().m_moveSpeed = 15f;
        player.GetComponent<Player1>().powerUpEffect.SetActive(true);
        yield return new WaitForSeconds(2f);
        player.GetComponent<Player1>().powerUpEffect.SetActive(false);
        player.GetComponent<Player1>().m_moveSpeed = 9f;
        player.GetComponent<Player1>().powerUpColected = false;
        Destroy(gameObject);

    }

    IEnumerator PowerUpSpeedPlayer2()
    {
        player2.GetComponent<Player2>().m_moveSpeed = 15f;
        player2.GetComponent<Player2>().powerUpEffect.SetActive(true);
        yield return new WaitForSeconds(2f);
        player2.GetComponent<Player2>().powerUpEffect.SetActive(false);
        player2.GetComponent<Player2>().m_moveSpeed = 9f;
        player2.GetComponent<Player2>().powerUpColectedByPlayer2 = false;
        Destroy(gameObject);

    }
}
