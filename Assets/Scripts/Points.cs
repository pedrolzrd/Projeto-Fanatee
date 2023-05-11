using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Points : MonoBehaviour
{
    [SerializeField]
    GameObject pecas;
    [SerializeField]
    Text textPoints;

    private void Update()
    {
        //textPoints.text = pecas.GetComponent<Peça>().piecesColected.ToString();
    }
}
