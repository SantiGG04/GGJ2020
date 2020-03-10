using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SistemaFallandoSeguridad01 : MonoBehaviour
{
    public GameObject enemigoAActivar01;
    public GameObject enemigoAActivar02;
    public GameObject enemigoAActivar03;

    public void SistemaFallando()
    {
        enemigoAActivar01.GetComponent<MovimientoEnemigos>().estaActivo = true;
        enemigoAActivar02.GetComponent<MovimientoEnemigos>().estaActivo = true;
        enemigoAActivar03.GetComponent<MovimientoEnemigos>().estaActivo = true;
    }
}
