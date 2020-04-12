using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SistemaFallandoPuertas : MonoBehaviour
{
    public GameObject objetoSonido;
    private GameObject[] listaPuertaGOs;

    public void SistemaFallando()
    {
        objetoSonido.SetActive(true);
        listaPuertaGOs = GameObject.FindGameObjectsWithTag("Puerta"); // Busco todos los GameObjects que tengan el Tag "ColliderPuerta"

        foreach (GameObject PuertaGO in listaPuertaGOs) // Para todos los Objetos que están en "listPuertaGOs"
        {
            PuertaGO.gameObject.SetActive(true); // Los activo
            Animator anim = PuertaGO.GetComponentInChildren<Animator>(); // Busco el Animator en los Hijos
            anim.SetBool("cerrarPuerta", true); // Seteo la Variable "cerrarPuerta" en TRUE
            ContenedorColliderPuerta contColliderPuerta = PuertaGO.GetComponent<ContenedorColliderPuerta>(); // Busco el Contenedor del ColliderPuerta
            contColliderPuerta.objColliderPuerta.SetActive(true); // Activo el ColliderPuerta
        }
    }
}
