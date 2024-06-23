using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_damaged_invincibility : MonoBehaviour
{
    [SerializeField]
    private float _invincibilityDuration;

    [SerializeField]
    private Color _flashColor;

    [SerializeField]
    private int _numberOfFlashes;

    private invincibility_controller ic;

    private void Awake()
    {
        ic = GetComponent<invincibility_controller>();    
    }

    public void StartInvincibility()
    {
        ic.start_invincibility(_invincibilityDuration, _flashColor, _numberOfFlashes);
    }
}
