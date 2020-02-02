using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pieza02 : MonoBehaviour
{
    public string nombrePieza;
    public GameObject contenedor;

    public void OnTriggerEnter()
    {
        ContenedorPiezas01 cont = contenedor.GetComponent<ContenedorPiezas01>();
        if (cont.cantidadPieza < cont.cantidadMaxima)
        {
            cont.cantidadPieza++;
            Destroy(gameObject);
        }
    }
}
