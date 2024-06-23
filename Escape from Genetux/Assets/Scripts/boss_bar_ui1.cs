using UnityEngine;
using UnityEngine.UI;

public class boss_bar_ui1 : MonoBehaviour
{
    [SerializeField]
    private Slider boss_health_bar;
    public void update_boss_health(float current, float max){
        boss_health_bar.value = current/max;
    }

    public void update_health_bar(boss_health_controller hc)
    {
        

    }
}
