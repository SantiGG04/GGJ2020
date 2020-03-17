using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SistemaFallandoEscudo : MonoBehaviour
{
    [Header("Objetos a Mover")]
    public GameObject objetoEscenario;
    public GameObject objetoJugador;

    [Header("Cantidad a Mover")]
    public float movMaxEjeX;
    public float movMinEjeX;

    [Header("Cada cuanto Movemos")]
    public float tiempoMinFalla;
    public float tiempoMaxFalla;
    public float tiempoDuracionFalla;

    [Header("Variables Privadas")]
    private bool fallaActiva = false;
    private float timer = 1;
    private float timer2 = 1;
    private bool canCount = false;
    private bool canCount2 = false;
    private float movRandomEjeX;

    private void Update()
    {
        if (fallaActiva)
        {
            if (timer >= 0.0f && canCount)
            {
                timer -= Time.deltaTime;
            }
            else if (timer <= 0.0f && canCount)
            {
                movRandomEjeX = Random.Range(movMinEjeX, movMaxEjeX);

                objetoEscenario.transform.Translate(transform.position.x + movRandomEjeX, transform.position.y, transform.position.z);
                objetoJugador.transform.Translate(transform.position.x + movRandomEjeX, transform.position.y, transform.position.z);

                timer2 = tiempoDuracionFalla;
                canCount = false;
                canCount2 = true;
            }

            if (timer2 >= 0.0f && canCount2)
            {
                timer2 -= Time.deltaTime;
            }
            else if(timer2 <= 0.0f && canCount2)
            {
                objetoEscenario.transform.Translate(transform.position.x - movRandomEjeX, transform.position.y, transform.position.z);
                objetoJugador.transform.Translate(transform.position.x - movRandomEjeX, transform.position.y, transform.position.z);

                timer = Random.Range(tiempoMinFalla, tiempoMaxFalla);
                canCount = true;
                canCount2 = false;
            }
        }
    }

    public void SistemaFallando()
    {
        timer = Random.Range(tiempoMinFalla, tiempoMaxFalla);
        canCount = true;
        fallaActiva = true;
    }
}
