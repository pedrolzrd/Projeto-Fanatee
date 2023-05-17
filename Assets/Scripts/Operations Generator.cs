using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OperationsGenerator : MonoBehaviour
{
    int a;
    int b;
    public int c;

    private void Start()
    {
        a = Random.Range(0, 3);
        b = Random.Range(0, 3);
        c = a + b;
        print("resultado da soma " + c);
    }

}
