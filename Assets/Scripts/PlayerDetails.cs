using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDetails : MonoBehaviour
{
    public int playerID;
    public Vector3 startPos;

    public GameObject circleImage;

    public string playerTag;

    void Start()
    {
        transform.position = startPos;  
        gameObject.tag = playerTag;
    }

    private void Update()
    {
        circleImage.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }


}
