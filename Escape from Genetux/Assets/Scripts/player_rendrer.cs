using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_rendrer : MonoBehaviour
{
 
    // Update is called once per frame
    void Update()
    {
        transform.localRotation = transform.localRotation * Quaternion.Inverse(transform.rotation);
    }
}
