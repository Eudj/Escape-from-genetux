using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour
{
    public GameObject pelotte_prefab;
    public Transform fire_point;
    public float fire_force = 20f;

    public void fire(){
        GameObject pelotte = Instantiate(pelotte_prefab,fire_point.position, fire_point.rotation);
        pelotte.GetComponent<Rigidbody2D>().AddForce(fire_point.up * fire_force,ForceMode2D.Impulse);

    }

}
