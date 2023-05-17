using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Validator : MonoBehaviour
{
    [SerializeField]
    GameObject piece;
    [SerializeField]
    GameObject operador;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Number"))
        {
            print("colidiu");
            /*
            if (piece.GetComponent<Peca>().id == operador.GetComponent<OperationsGenerator>().c)
            {
                print("resposta certa");
                Destroy(piece);
            }
            else
            {
                print("EROOOOOOOU");
                Destroy(piece);
            }
            */
        }
    }
}
