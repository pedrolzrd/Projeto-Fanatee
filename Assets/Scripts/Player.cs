using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Variaveis
    [SerializeField]
    float speed;

    //Objetos/Componentes
    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        print("acordou suiAHBSHAUYVDAHGV DHGAS DHG AS");
    }

    void FixedUpdate()
    {
        //Movimenta��o
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));

        rb.MovePosition(rb.position + move * speed * Time.deltaTime);
    }
}
