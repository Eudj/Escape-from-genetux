using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.Mathematics;
using UnityEngine;

public class sceneloader : MonoBehaviour{
    public GameObject canvas;
    private Vector3 player_spawn_point = new Vector3(0f, 0f, 0f);
    public GameObject player_prefab;
    private health_controller hc;
    private door_script ds ;




    // Start is called before the first frame update
    void Start(){   
        Instantiate(canvas);
        //player_spawn_point = GetComponent<door_script>().spawnpoint;
        float ch= hc.current_health;
        GameObject player1 = Instantiate(player_prefab, player_spawn_point,quaternion.identity);
        hc.current_health = ch;
        hc.update_health();

    }
    
}
