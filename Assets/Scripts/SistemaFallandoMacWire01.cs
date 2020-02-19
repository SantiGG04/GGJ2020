using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SistemaFallandoMacWire01 : MonoBehaviour
{
    public void SistemaFallando()
    {
        GameObject PJ = GameObject.FindGameObjectWithTag("Player");
        MovimientoPersonaje01 MovPJ = PJ.GetComponentInChildren<MovimientoPersonaje01>();

        MovPJ.modificadorDireccion = -1;
    }
}
