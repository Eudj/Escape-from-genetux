using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;

public class door_script : MonoBehaviour{
    public Vector3 spawnpoint;

    public string scene_name;
    private GameObject GO;
    private health_controller hc ;
    private global glb;




   private void OnTriggerEnter2D(Collider2D trigger) {
    if (trigger.gameObject.CompareTag("Player")){
        SceneManager.LoadScene(scene_name);
    }
    
   }
}
