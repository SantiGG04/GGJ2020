using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiarEscena : MonoBehaviour
{
    [Header("Parametros")]
    public string nombreEscena;
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
            CambiarDeEscena();
            doOnce = true;
        }
    }

    public void IniciarCambioEscena()
    {
        timer = tiempoDelay;
        canCount = true;
    }

    public void CambiarDeEscena()
    {
        SceneManager.LoadScene(nombreEscena);
    }
}