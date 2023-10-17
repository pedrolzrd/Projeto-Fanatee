using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slowScript : MonoBehaviour
{
    GameObject player;
    GameObject player2;

    [SerializeField]
    float vel;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        player2 = GameObject.FindGameObjectWithTag("Player 2");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            player.GetComponent<SimpleSampleCharacterControl>().m_moveSpeed /= 2;
        }

        if (other.CompareTag("Player 2"))
        {
            player2.GetComponent<SimpleSampleCharacterControl>().m_moveSpeed /= 2;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player.GetComponent<SimpleSampleCharacterControl>().m_moveSpeed = player.GetComponent<SimpleSampleCharacterControl>().initialSpeed;
        }

        if (other.CompareTag("Player 2"))
        {
            player2.GetComponent<SimpleSampleCharacterControl>().m_moveSpeed = player2.GetComponent<SimpleSampleCharacterControl>().initialSpeed ;
        }
    }

    //private void OnDrawGizmos()
    //{
    //    Vector3 size = new Vector3(5, 1, 5);
    //    Gizmos.DrawWireCube(transform.position, size);
    //}
}
