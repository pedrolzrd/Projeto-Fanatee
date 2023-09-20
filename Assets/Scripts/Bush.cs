using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bush : MonoBehaviour
{
    [SerializeField]
    GameObject player;

    //Materiais da moita
    [SerializeField]
    Material transpMat;
    [SerializeField]
    Material opaqMat;

    private void Awake()
    {
        //Material OPACO colocado ao começar o jogo
        this.GetComponent<Renderer>().material = opaqMat;
    }

    private void OnTriggerStay(Collider player)
    {
        //Altera o material para o material translucido
        if (player.gameObject.layer == 8)
        {
            this.GetComponent<Renderer>().material = transpMat;
        }
    }

    private void OnTriggerExit(Collider player)
    {
        //Retorna o material para o materal opaco
        if (player.gameObject.layer == 8)
        {
            this.GetComponent<Renderer>().material = opaqMat;
        }
    }
}
