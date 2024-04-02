using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    void Awake()
    {
        //Awake is the first part of the flowchart
   
        int num = FindObjectsOfType<MusicPlayer>().Length;   
        if (num > 1)
        {
            Destroy(gameObject); //Destroy any dupllicated Music players
        }
        else
        {
            DontDestroyOnLoad(gameObject); //Dont destroy the first music player
        }
    }
}
