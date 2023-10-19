using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Cutscene : MonoBehaviour
{
    public PlayableDirector cutscene;
    void Start()
    {
        cutscene.GetComponent<PlayableDirector>().Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
