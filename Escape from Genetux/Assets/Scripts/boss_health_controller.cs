using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class boss_health_controller : MonoBehaviour
{
    private void Start() {
        DontDestroyOnLoad(gameObject);
        boss_bar.update_boss_health(current_health,max_health);
    }
    
    [SerializeField] public float current_health =50f;

    [SerializeField] private float max_health;
    [SerializeField] private boss_bar_ui1 boss_bar;

    [SerializeField] public float health_remaining
    {
        get
        {
            return current_health / max_health;
        }
    }

    public bool is_invincible { get; set; }

    public UnityEvent is_dead;

    public UnityEvent is_damaged;
    public UnityEvent on_health_changed;

    public void update_health(){
        on_health_changed.Invoke();
    }
    private void Awake() {
        //boss_bar = getc

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
            Destroy(this.gameObject);
            SceneManager.LoadScene("death scene");
        }
        else
        {
            is_damaged.Invoke();
            boss_bar.update_boss_health(current_health,max_health);
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
