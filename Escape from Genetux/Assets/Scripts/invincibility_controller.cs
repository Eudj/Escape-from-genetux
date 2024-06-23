using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class invincibility_controller : MonoBehaviour
{
    private player_health_controller hc;

    private SpriteFlash sf;

    private void Awake()
    {
        hc = GetComponent<player_health_controller>();
        sf = GetComponent<SpriteFlash>();
    }

    public void start_invincibility(float invincibility_duration,Color fc, int nof)
    {
        StartCoroutine(Invincibility_coroutine(invincibility_duration,fc, nof));
    }

    private IEnumerator Invincibility_coroutine(float invincibility_duration,Color fc, int nof)
    {
        hc.is_invincible = true;
        yield return sf.FlashCoroutine(invincibility_duration, fc, nof);
        hc.is_invincible = false;
    }
}