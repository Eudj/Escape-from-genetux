using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class ennemy_script : MonoBehaviour
{
    public Transform target;
    public float rotate_speed =0.0025f;
    public float speed =2f;
    private Rigidbody2D rb;
    private PlayerAwarenessController pac;
    private Vector2 target_direction;
    private float direction_change_cooldown = 3f;


    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        pac = GetComponent<PlayerAwarenessController>();
        target_direction = transform.up;
    }

    private void FixedUpdate()
    {//avancer
        if (!target) {
            get_target();
        } else if (pac.aware_of_player){
            rotate_towards_target();
        }else{
            random_direction();
        }
        set_velocity();
    }
    
    
    private void get_target ()
    {
        if (GameObject.FindGameObjectWithTag("Player").transform){
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }
       
    }
    private void random_direction (){
        direction_change_cooldown = direction_change_cooldown - Time.deltaTime;
        if (direction_change_cooldown <=0){
            float angle_change = UnityEngine.Random.Range(-90,90)*Mathf.Rad2Deg;
            Quaternion q = Quaternion.Euler(new Vector3(0,0,angle_change));
            transform.localRotation = Quaternion.Slerp(transform.localRotation,q,rotate_speed);
            direction_change_cooldown = UnityEngine.Random.Range(1f,5f);

        }

    }
    private void rotate_towards_target()
    {
        
        target_direction = target.position-transform.position;
        float angle = Mathf.Atan2(target_direction.y,target_direction.x)*Mathf.Rad2Deg -90f;
        Quaternion q = Quaternion.Euler(new Vector3(0,0,angle));
        transform.localRotation = Quaternion.Slerp(transform.localRotation,q,rotate_speed);
    }
    /*private void OnCollisionEnter2D(Collision2D other){
        if (other.gameObject.CompareTag("Player")){
            Destroy(other.gameObject);
            target=null;
        } else if (other.gameObject.CompareTag("pelotte"));
        Destroy(gameObject);
        Destroy(other.gameObject);
    }*/
    private void set_velocity()
    {
        
        rb.velocity = transform.up * speed;
        
    }
}
