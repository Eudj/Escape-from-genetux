using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ennemy_attack : MonoBehaviour
{
    [SerializeField]
    private float damage_amount;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            animator.SetBool("Attack", true);
            var player_health_controller = collision.gameObject.GetComponent<player_health_controller>();

            player_health_controller.take_damage(damage_amount);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        animator.SetBool("Attack", false);
    }
}