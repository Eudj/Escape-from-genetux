using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAwarenessController : MonoBehaviour
{
    public bool aware_of_player { get; private set; }

    public Vector2 direction_to_player { get; private set; }

    [SerializeField]
    private float pa_distance;

    private Transform player;

    private void Awake()
    {
        player = FindObjectOfType<player_controller>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 ennemy_to_player = player.position - transform.position;
        direction_to_player = ennemy_to_player.normalized;

        if (ennemy_to_player.magnitude <= pa_distance)
        {
            aware_of_player = true;
        }
        else
        {
            aware_of_player = false;
        }
    }
}