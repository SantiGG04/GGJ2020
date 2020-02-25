using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectarColisionEnemigo : MonoBehaviour
{
    public MovimientoPersonaje01 movPj;

    // Variables de Sonido
    [Header("Variables de Sonido")]
    public GameObject contendedorSonidoContactoEnemigo;

    private void Start()
    {
        // Inicializacion de Sonidos en false, para que no suenen si nos los olvidamos habilitados
        contendedorSonidoContactoEnemigo.SetActive(false);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.transform.gameObject.tag == "Boss")
        {
            movPj.estoyPenalizado = true;
            movPj.timer = movPj.duracionPenalizacion;
            contendedorSonidoContactoEnemigo.SetActive(false); // Primero se deshabilita, ya que luego de que suene por primera vez hay que dejarlo habilitado para que termine el sonido
            contendedorSonidoContactoEnemigo.SetActive(true); // Habilitamos el contenedor para que suenen los sonidos que contiene
        }
    }
}
