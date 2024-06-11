using UnityEngine;

public class health_bar_ui : MonoBehaviour
{
    [SerializeField]
    private UnityEngine.UI.Image health_bar;

    public void update_health_bar(health_controller hc)
    {
        health_bar.fillAmount = hc.health_remaining;
    }
}
