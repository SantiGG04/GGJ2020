using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectarColisionEnemigo : MonoBehaviour
{
    public MovimientoPersonaje01 movPj;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.parent.name == "Enemigo")
        {
            movPj.estoyPenalizado = true;
            movPj.timer = movPj.duracionPenalizacion;
        }
    }
}
