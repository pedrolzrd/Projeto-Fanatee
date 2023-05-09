using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Variaveis
    [SerializeField]
    float speed;
    [HideInInspector]
    public int id;

    //Objetos/Componentes
    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        print(id);
    }

    private void Start()
    {
        id = Random.Range(1, 5);
    }

    void FixedUpdate()
    {
        //Movimentação
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));

        rb.MovePosition(rb.position + move * speed * Time.deltaTime);
    }
}
