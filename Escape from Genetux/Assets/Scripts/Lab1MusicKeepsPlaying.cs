using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lab1MusicKeepsPlaying : MonoBehaviour
{
    private void Awake()
    {
        Destroy(GameObject.Find("Lab2Music"));
        GameObject[] musicObj = GameObject.FindGameObjectsWithTag("MusicLab1");
        if(musicObj.Length > 1){
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }
}
