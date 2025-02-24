using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class player_health_controller : MonoBehaviour
{
    private void Start() {
        DontDestroyOnLoad(gameObject);
        current_health = 100f;
    }
    
    [SerializeField] public float current_health;

    [SerializeField] private float max_health = 100f;

    [SerializeField] public float health_remaining
    {
        get
        {
            return current_health / max_health;
        }
    }
    private Canvas canvas;

    public bool is_invincible { get; set; }

    public UnityEvent is_dead;

    public UnityEvent is_damaged;
    public UnityEvent on_health_changed;

    public void update_health(){
        on_health_changed.Invoke();
    }

    public void take_damage(float damage_amount)
    {
        if (current_health == 0)
        {
            return;
        }

        if (is_invincible)
        {
            return;
        }

        current_health -= damage_amount;
        on_health_changed.Invoke();

        if (current_health < 0)
        {
            current_health = 0;
        }

        if (current_health == 0)
        {
            is_dead.Invoke();
            SceneManager.LoadScene("death scene");
            Destroy(this.gameObject);
            Destroy(canvas.gameObject);
        }
        else
        {
            is_damaged.Invoke();
        }

    }

    public void add_health(float ammount_to_add)
    {
        if (current_health == max_health)
        {
            return;
        }

        current_health += ammount_to_add;
        on_health_changed.Invoke();

        if (current_health > max_health)
        {
            current_health = max_health;
        }
    }
}
