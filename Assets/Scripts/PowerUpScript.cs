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
        gameObject.LeanScale(new Vector3(70f, 70f, 70f), 0.9f).setLoopPingPong();
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
        if (other.CompareTag("Player") && player.GetComponent<CharacterControl>().powerUpColected == false)
        {
            colected = true;
            player.GetComponent<CharacterControl>().powerUpColected = true;
            
            StartCoroutine(PowerUpSpeed());
            StopCoroutine(destroyCoroutine);
        }


        if (other.CompareTag("Player 2") && player2.GetComponent<CharacterControl>().powerUpColectedByPlayer2 == false)
        {
            collectByPlayer2 = true;
            player2.GetComponent<CharacterControl>().powerUpColectedByPlayer2 = true;

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
        player.GetComponent<CharacterControl>().m_moveSpeed *= 2;
        player.GetComponent<CharacterControl>().powerUpEffect.SetActive(true);
        yield return new WaitForSeconds(2f);
        player.GetComponent<CharacterControl>().powerUpEffect.SetActive(false);
        player.GetComponent<CharacterControl>().m_moveSpeed = player.GetComponent<CharacterControl>().initialSpeed;
        player.GetComponent<CharacterControl>().powerUpColected = false;
        Destroy(gameObject);

    }

    IEnumerator PowerUpSpeedPlayer2()
    {
        player2.GetComponent<CharacterControl>().m_moveSpeed *= 2;
        player2.GetComponent<CharacterControl>().powerUpEffect.SetActive(true);
        yield return new WaitForSeconds(2f);
        player2.GetComponent<CharacterControl>().powerUpEffect.SetActive(false);
        player2.GetComponent<CharacterControl>().m_moveSpeed = player2.GetComponent<CharacterControl>().initialSpeed;
        player2.GetComponent<CharacterControl>().powerUpColectedByPlayer2 = false;
        Destroy(gameObject);

    }
}
