using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonSalir : MonoBehaviour
{
    [Header("Parametros")]
    public float tiempoDelay;
    private float timer = 1;
    private bool canCount = false;
    private bool doOnce = false;

    private void Update()
    {
        if (timer >= 0.0f && canCount)
        {
            timer -= Time.deltaTime;
        }
        else if (timer <= 0.0f && !doOnce)
        {
            Application.Quit();
            Debug.Log("Se ha cerrado el juego");
            doOnce = true;
        }
    }

    public void SalirJuego()
    {
        timer = tiempoDelay;
        canCount = true;
    }
}