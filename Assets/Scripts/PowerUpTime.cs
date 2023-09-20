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

    void Start()
    {
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
            Destroy(gameObject, 1);
        }
    }

    IEnumerator destroyLifetime()
    {
        yield return new WaitForSeconds(timeToDestroy);
        Destroy(gameObject);
        spawner.GetComponent<UpTimeSpawner>().spawned--;
    }
}
