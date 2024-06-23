using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class player_controller : MonoBehaviour
{
    public int health = 5;
    public float move_speed = 5f;
    public Rigidbody2D rb;
    public weapon weapon;
    public SpriteRenderer sr;
    public List<Sprite> n_sprite;
    public List<Sprite> ne_sprite;
    public List<Sprite> e_sprite;
    public List<Sprite> se_sprite;
    public List<Sprite> s_sprite;
    public List<Sprite> sw_sprite;
    public List<Sprite> w_sprite;
    public List<Sprite> nw_sprite;
    public float framerate;
    float idle_time = 0;
    Vector2 move_direction;
    Vector2 mouse_position;
    private static player_controller playerInstance;
    public UnityEvent start;


    private void Start() {
        idle_time = Time.time;
        start.Invoke();       

    }
    
void Awake(){
	DontDestroyOnLoad (this);
		
	if (playerInstance == null) {
		playerInstance = this;
	} else {
		Destroy(gameObject);
	}
}
   // Update is called once per frame
    void Update()
    {
        //transform.localRotation = new Quaternion ();
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        

        if(Input.GetMouseButtonDown(0)){
            weapon.fire();
        }
        
        move_direction = new Vector2(moveX,moveY).normalized;
        mouse_position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        List<Sprite> sprite_direction = get_sprite_direction();

        if(sprite_direction!=null){
            float play_time =Time.time - idle_time;
            int total_frames = (int)(play_time*framerate);
            int frame = (int)((play_time *framerate) % sprite_direction.Count);
            sr.sprite = sprite_direction[frame];

        }else {//input=0
            idle_time=Time.time;
            sr.sprite = s_sprite[0];
        }

    }
    private void FixedUpdate() {
        rb.velocity =new Vector2(move_direction.x * move_speed,move_direction.y * move_speed);
        Vector2 aim_direction = mouse_position - rb.position;
        float aim_angle = Mathf.Atan2(aim_direction.y,aim_direction.x) * Mathf.Rad2Deg - 90f;
        rb.rotation=aim_angle;
    }
    List<Sprite> get_sprite_direction(){
        List<Sprite> selected_sprite =null;
        if (move_direction.y>0){//nord
            if (move_direction.x>0){//est
                selected_sprite=ne_sprite;
            } else if (move_direction.x<0){//west
                selected_sprite=nw_sprite;
            } else{//nord neutre
                selected_sprite = n_sprite;
            }
        } else if (move_direction.y<0){//sud
            if (move_direction.x>0){//est
                selected_sprite=se_sprite;
            } else if (move_direction.x<0){//ouest
                selected_sprite=sw_sprite;
            } else{//sud neutre
                selected_sprite = s_sprite;
            }    
        } else if(move_direction.x<0){// ouest neutre
            selected_sprite = w_sprite;
        } else if(move_direction.x>0){//est neutre
            selected_sprite = e_sprite;
        }
        return selected_sprite;
    }
    

}

