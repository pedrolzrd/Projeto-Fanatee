using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpScript : MonoBehaviour
{
    [SerializeField]
    float timeToDestroy;
    bool colected = false;

    GameObject powerUpSpawner;
    GameObject player;

    IEnumerator destroyCoroutine;

    void Start()
    {
        destroyCoroutine = destroyLifetime();
        powerUpSpawner = GameObject.FindGameObjectWithTag("PowerUpSpawner");
        player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(destroyCoroutine);
    }

    
    void Update()
    {
        if (colected == true)
        {
            transform.position = new Vector3(player.transform.position.x, 6, player.transform.position.z);
                    }
        if (Input.GetKeyDown(KeyCode.F) && colected == true)
        {
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && player.GetComponent<SimpleSampleCharacterControl>().powerUpColected == false)
        {
            colected = true;
            player.GetComponent<SimpleSampleCharacterControl>().powerUpColected = true;
            
            StartCoroutine(PowerUpSpeed());
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
        player.GetComponent<SimpleSampleCharacterControl>().m_moveSpeed = 10f;
        player.GetComponent<SimpleSampleCharacterControl>().effect.SetActive(true);
        yield return new WaitForSeconds(4f);
        player.GetComponent<SimpleSampleCharacterControl>().effect.SetActive(false);
        player.GetComponent<SimpleSampleCharacterControl>().m_moveSpeed = 7.5f;
        player.GetComponent<SimpleSampleCharacterControl>().powerUpColected = false;
        Destroy(gameObject);

    }

}
