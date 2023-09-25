using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpTime : MonoBehaviour
{
    [SerializeField] float timeToDestroy;
    [SerializeField] float addTime;
    
    GameObject timePoints;
    GameObject spawner;

    IEnumerator destroyCoroutine;

    [SerializeField]ParticleSystem powerUpTimeEffect;



    void Start()
    {
        gameObject.LeanScale(new Vector3(70f, 70f, 70f), 0.9f).setLoopPingPong();
        transform.Rotate(-45, 0, 0);
        timePoints = GameObject.FindGameObjectWithTag("timer");
        spawner = GameObject.FindGameObjectWithTag("spawnerTime");
        destroyCoroutine = destroyLifetime();
        StartCoroutine(destroyCoroutine);
    }

    private void OnTriggerEnter(Collider player)
    {
        if(player.gameObject.layer == 8)
        {
            print("col");
            timePoints.GetComponent<CountdownTimer>().timeLeft += addTime;
            
            Instantiate(powerUpTimeEffect, transform.position, Quaternion.Euler(-90,0f,0f));
            Destroy(gameObject);
        }
    }

    IEnumerator destroyLifetime()
    {
        yield return new WaitForSeconds(timeToDestroy);
        Destroy(gameObject);
        spawner.GetComponent<UpTimeSpawner>().spawned--;
    }
}
