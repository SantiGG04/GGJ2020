using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectarColisionEnemigo : MonoBehaviour
{
    public MovimientoPersonaje01 movPj;

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("No tan rapido", other.gameObject);
        if (other.transform.gameObject.tag == "Boss"/*other.transform.parent.name == "Enemigo"*/)
        {
            Debug.Log("Está bien así?...");
            movPj.estoyPenalizado = true;
            movPj.timer = movPj.duracionPenalizacion;
        }
    }
}
