using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectarColisionEnemigo : MonoBehaviour
{
    public MovimientoPersonaje01 movPj;

    public void OnTriggerEnter(Collider other)
    {
        if (other.transform.gameObject.tag == "Boss")
        {
            movPj.estoyPenalizado = true;
            movPj.timer = movPj.duracionPenalizacion;
        }
    }
}
