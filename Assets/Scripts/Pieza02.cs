using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pieza02 : MonoBehaviour
{
    public string nombrePieza;
    public GameObject contenedor;

    // Variables de Sonido
    [Header("Variables de Sonido")]
    public GameObject contendedorSonidoAgarrarPieza;

    private void Start()
    {
        // Inicializacion de Sonidos en false, para que no suenen si nos los olvidamos habilitados
        contendedorSonidoAgarrarPieza.SetActive(false);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.transform.gameObject.tag == "Player")
        {
            ContenedorPiezas01 cont = contenedor.GetComponent<ContenedorPiezas01>();
            if (cont.cantidadPieza < cont.cantidadMaxima)
            {
                cont.cantidadPieza++;
                contendedorSonidoAgarrarPieza.SetActive(false); // Primero se deshabilita, ya que luego de que suene por primera vez hay que dejarlo habilitado para que termine el sonido
                contendedorSonidoAgarrarPieza.SetActive(true); // Habilitamos el contenedor para que suenen los sonidos que contiene
                Destroy(gameObject);
            }
        }
    }
}
