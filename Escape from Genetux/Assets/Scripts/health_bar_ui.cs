using UnityEngine;

public class health_bar_ui : MonoBehaviour
{
    [SerializeField]
    private UnityEngine.UI.Image health_bar;
    private player_health_controller hc;
    private void Start() {
        health_bar.fillAmount = 1;
    }

    public void update_health_bar(player_health_controller hc)
    {
        health_bar.fillAmount = hc.health_remaining;
    }
}
