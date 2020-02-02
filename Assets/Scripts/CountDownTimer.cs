﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDownTimer : MonoBehaviour
{
    public Text txtCountDown;
    public float timeQuest;

    private float timer;
    private bool canCount = true;
    private bool doOnce = false;

    void OnEnable()
    {
        timer = timeQuest;
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
        }
    }

}
