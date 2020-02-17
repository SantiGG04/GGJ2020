using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp_Velocidad0101 : MonoBehaviour
{
    public void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.transform.parent.name == "Personaje")
        {
            MovimientoPersonaje01 movPj = col.GetComponentInParent<MovimientoPersonaje01>();
            movPj.estoyBonificado = true;
            movPj.timerBonificacion = movPj.duracionBonificacion;
        }
    }
}
