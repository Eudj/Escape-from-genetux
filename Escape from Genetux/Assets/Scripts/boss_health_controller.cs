using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class boss_health_controller : MonoBehaviour
{
    [SerializeField]
    private GameObject pc;
    private void Start() {
        boss_bar.update_boss_health(current_health,max_health);
    }
    
    [SerializeField] public float current_health =50f;
    private Collider2D collider ;
    private Rigidbody2D rb;
    private Animator animator;

    [SerializeField] private float max_health =50f;
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
        boss_bar = GetComponentInChildren<boss_bar_ui1>();
        collider = GetComponent<Collider2D>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        collider = GetComponent<Collider2D>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        animator.enabled = true;

    }

    IEnumerator death(){
        collider.enabled = false;
        animator.SetBool("Dead", true);
        rb.velocity = Vector3.zero;
        rb.isKinematic = true;
        rb.Sleep();
        yield return new WaitForSeconds(1);
        Destroy(this.gameObject);
    }

    public void take_damage(float damage_amount)
    {
        if (current_health == 0)
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
            StartCoroutine(death());
            death();
            pc = GameObject.Find("player");
            pc.transform.position = new Vector3(0f,0f,0f);
            SceneManager.LoadScene("death scene");
            Destroy(this.gameObject);
            
        }
        else
        {
            is_damaged.Invoke();            
            boss_bar.update_boss_health(current_health,max_health);
        }

    }
    private void OnCollisionEnter2D(Collision2D other){
        if (other.gameObject.CompareTag("pelotte")){
            take_damage(10);
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
