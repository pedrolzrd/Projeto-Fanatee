using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slowScript : MonoBehaviour
{
    GameObject player;
    GameObject player2;

    [SerializeField]
    float vel;

    [SerializeField]
    float multiplicador;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        player2 = GameObject.FindGameObjectWithTag("Player 2");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            player.GetComponent<CharacterControl>().m_moveSpeed /= multiplicador;
        }

        if (other.CompareTag("Player 2"))
        {
            player2.GetComponent<CharacterControl>().m_moveSpeed /= multiplicador;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player.GetComponent<CharacterControl>().m_moveSpeed *= multiplicador;
        }

        if (other.CompareTag("Player 2"))
        {
            player2.GetComponent<CharacterControl>().m_moveSpeed *= multiplicador;
        }
    }

    //private void OnDrawGizmos()
    //{
    //    Vector3 size = new Vector3(5, 1, 5);
    //    Gizmos.DrawWireCube(transform.position, size);
    //}
}
