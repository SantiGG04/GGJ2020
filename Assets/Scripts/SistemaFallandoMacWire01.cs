using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SistemaFallandoMacWire01 : MonoBehaviour
{
    [Header("Parametros Error")]
    public float tiempoMinimo;
    public float tiempoMaximo;

    private float timer;
    private bool canCount;

    private void Update()
    {
        if (timer >= 0.0f && canCount)
        {
            timer -= Time.deltaTime;
        }
        else if (timer <= 0.0f && canCount)
        {
            canCount = false;
            SistemaFallando();
        }
    }

    public void SistemaFallando()
    {
        timer = Random.Range(tiempoMinimo, tiempoMaximo);
        canCount = true;

        GameObject PJ = GameObject.FindGameObjectWithTag("Player");
        MovimientoPersonaje01 MovPJ = PJ.GetComponentInChildren<MovimientoPersonaje01>();

        if (!MovPJ.modificadorDireccion)
        {
            MovPJ.modificadorDireccion = true;
        }
        else
        {
            MovPJ.modificadorDireccion = false;
        }
    }
}
