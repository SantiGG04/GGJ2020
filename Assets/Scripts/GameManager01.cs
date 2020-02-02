﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager01 : MonoBehaviour
{
    public int nivelDeRotura;

    public float tiempoVictoria;

    public Text txtCountDown;

    private float timer;
    private bool canCount = true;
    private bool doOnce = false;

    public string escenaVictoria;
    public string escenaDerrota;

    void OnEnable()
    {
        timer = tiempoVictoria;
    }

    void Update()
    {
        if (timer >= 0.0f && canCount)
        {
            timer -= Time.deltaTime;
            txtCountDown.text = timer.ToString("F");
        }
        else if (timer <= 0.0f && !doOnce)
        {
            canCount = false;
            doOnce = true;
            txtCountDown.text = "0.00";
            timer = 0.0f;
            SceneManager.LoadScene(escenaVictoria);
        }

        if (nivelDeRotura == 3)
        {
            SceneManager.LoadScene(escenaDerrota);
        }
    }
}
