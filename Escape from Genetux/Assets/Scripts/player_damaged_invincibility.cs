using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_damaged_invincibility : MonoBehaviour
{
    [SerializeField]
    private float Invincibility_duration;

    private invincibility_controller ic;

    private void Awake()
    {
        ic = GetComponent<invincibility_controller>();    
    }

    public void StartInvincibility()
    {
        ic.start_invincibility(Invincibility_duration);
    }
}
