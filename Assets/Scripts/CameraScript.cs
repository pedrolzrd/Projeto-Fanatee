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
    [SerializeField]
    private float smoothTime;

    private Vector3 _currentVelocity = Vector3.zero;

    private void Awake()
    {
        offset = transform.position - player.transform.position;
    }

    private void LateUpdate()
    {
        transform.position = player.transform.position + offset;

        //transform.position = Vector3.SmoothDamp(transform.position, playerPosition, ref _currentVelocity, smoothTime);


    }
}
