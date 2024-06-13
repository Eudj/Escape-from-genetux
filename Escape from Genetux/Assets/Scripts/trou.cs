using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trou : MonoBehaviour
{
public float damage_amount;

private void OnTriggerEnter2D(Collider2D trigger) {
        if (trigger.gameObject.CompareTag("Player")){
            var health_controller = trigger.gameObject.GetComponent<health_controller>();

            health_controller.take_damage(damage_amount);
        
    }
}
}