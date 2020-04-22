using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pieza02 : MonoBehaviour
{
    [Header("General")]
    public string nombrePieza;
    public GameObject contenedor;
    public Collider colliderPieza;
    public GameObject imagenPieza;

    [Header("Respawn")]
    public bool hasRespawn;
    public float timeRespawn;
    public float timer;
    private bool canCount;
    private bool doOnce;

    [Header("Variables de Sonido")]
    public GameObject contendedorSonidoAgarrarPieza;

    private void Start()
    {
        // Inicializacion de Sonidos en false, para que no suenen si nos los olvidamos habilitados
        contendedorSonidoAgarrarPieza.SetActive(false);

        // Inicializacion de Variables de Respawn
        canCount = false;
        doOnce = false;
    }

    private void Update()
    {
        if (timer >= 0.0f && canCount)
        {
            timer -= Time.deltaTime;
        }
        else if (timer <= 0.0f && doOnce) // Cuando termina el Contador
        {
            canCount = false;
            doOnce = false;
            colliderPieza.enabled = true; // Habilito el Collider de la Pieza
            imagenPieza.SetActive(true); // Habilito la Imagen de la Pieza
        }
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

                colliderPieza.enabled = false; // Deshabilito el Collider de la Pieza
                imagenPieza.SetActive(false); // Deshabilito la Imagen de la Pieza

                if (hasRespawn) // Si tiene Respawn, inicio el Contador
                {
                    timer = timeRespawn;
                    canCount = true;
                    doOnce = true;
                }
            }
        }
    }
}
