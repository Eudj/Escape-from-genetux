using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canvas : MonoBehaviour
{
    private static canvas canvasInstance;

    void Awake(){
        DontDestroyOnLoad (this);
            
        if (canvasInstance == null) {
            canvasInstance = this;
        } else {
            Destroy(gameObject);
	    }
    }
}
