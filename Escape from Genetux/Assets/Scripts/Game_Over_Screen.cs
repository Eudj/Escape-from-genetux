/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Over_Screen : MonoBehaviour
{
    public GameObject gameOverCanvas;

    void Start()
    {
        gameOverCanvas.SetActive(false);
    }

    void OnEnable()
    {
        health_controller.is_dead += ActivateGameOverScreen;
    }

    void OnDisable()
    {
        health_controller.is_dead -= ActivateGameOverScreen;
    }

    void ActivateGameOverScreen()
    {
        gameOverCanvas.SetActive(true);
    }
}
*/