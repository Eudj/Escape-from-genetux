using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class global : MonoBehaviour
{
       const int ScreenFadingIn = -1;
       const int ScreenIdle = 0;
       const int ScreenFadingOut   =   1;
       public static float ScreenFadeAlpha = 1.0f;
       public static int ScreenFadeStatus = ScreenFadingIn;
       public float player_health = 100f;
       public Vector3 spawn_point ;

}
