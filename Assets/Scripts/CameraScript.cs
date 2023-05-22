using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    //variaveis
    private Vector3 offset;

    //Objetos/Componentes
    [SerializeField]
    GameObject player;
    [SerializeField]


    private void Start()
    {
        offset = transform.position - player.transform.position;
    }

    private void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}
