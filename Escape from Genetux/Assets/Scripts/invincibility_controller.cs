using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class invincibility_controller : MonoBehaviour
{
    private player_health_controller hc;

    private void Awake()
    {
        hc = GetComponent<player_health_controller>();
    }

    public void start_invincibility(float invincibility_duration)
    {
        StartCoroutine(Invincibility_coroutine(invincibility_duration));
    }

    private IEnumerator Invincibility_coroutine(float invincibility_duration)
    {
        hc.is_invincible = true;
        yield return new WaitForSeconds(invincibility_duration);
        hc.is_invincible = false;
    }
}