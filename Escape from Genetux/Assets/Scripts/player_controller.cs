using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_controller : MonoBehaviour
{
    public float move_speed = 5f;
    public Rigidbody2D rb;
    public weapon weapon;

    Vector2 move_direction;
    Vector2 mouse_position;
   // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        if(Input.GetMouseButtonDown(0)){
            weapon.fire();
        }
        move_direction = new Vector2(moveX,moveY).normalized;
        mouse_position = Camera.main.ScreenToWorldPoint(Input.mousePosition);

    }
    private void FixedUpdate() {
        rb.velocity =new Vector2(move_direction.x * move_speed,move_direction.y * move_speed);
        Vector2 aim_direction = mouse_position - rb.position;
        float aim_angle = Mathf.Atan2(aim_direction.y,aim_direction.x) * Mathf.Rad2Deg - 90f;
        rb.rotation=aim_angle;
    }
}
