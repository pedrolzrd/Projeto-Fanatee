using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    //variaveis
    private Vector3 offset;

    //Objetos/Componentes
    [SerializeField]
    private Transform player;

    private void Awake()
    {
        offset = transform.position - player.transform.position;
    }

    private void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}
