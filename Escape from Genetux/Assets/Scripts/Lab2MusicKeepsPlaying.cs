using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lab2MusicKeepsPlaying : MonoBehaviour
{
    private void Awake()
    {
        Destroy(GameObject.Find("Lab1Music"));
        GameObject[] musicObj = GameObject.FindGameObjectsWithTag("MusicLab2");
        if(musicObj.Length > 1){
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }
}
