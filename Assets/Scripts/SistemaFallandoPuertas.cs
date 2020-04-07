using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SistemaFallandoPuertas : MonoBehaviour
{
    // La idea que tengo es hacer una funcion que busque en la Escena los Objetos que tengan un Tag llamado "ColliderPuerta" y que lo active. Así podemos agregar puetas sin tener que cambiar el Script ni las Variables.

    // También tiene que activar la Animacion de Cerrar Puertas

    /*     
     * https://answers.unity.com/questions/24257/how-do-i-find-all-game-objects-with-the-same-name.html 
     *
     *           foreach(GameObject fooObj in GameObject.FindGameObjectsWithTag("foo"))
     *           {
     *               if(fooObj.name == "bar")
     *               {
     *                   //Do Something
     *               }
     *           }
    */

    private GameObject[] listPuertaGOs;

    public void SistemaFallando()
    {
        listPuertaGOs = GameObject.FindGameObjectsWithTag("Puerta"); // Busco todos los GameObjects que tengan el Tag "ColliderPuerta"

        foreach (GameObject PuertaGO in listPuertaGOs) // Para todos los Objetos que están en "listPuertaGOs"
        {
            Debug.Log("Encontré un Objeto! '" + PuertaGO.name + "'");
            PuertaGO.gameObject.SetActive(true); // Los activo
            Animator anim = PuertaGO.GetComponentInChildren<Animator>(); // Busco el Animator en los Hijos del Padre
            anim.SetBool("cerrarPuerta", true); // Seteo la Variable "cerrarPuerta" en TRUE
            ContenedorColliderPuerta contColliderPuerta = PuertaGO.GetComponent<ContenedorColliderPuerta>(); // Busco el Contenedor del ColliderPuerta
            contColliderPuerta.objColliderPuerta.SetActive(true); // Activo el ColliderPuerta
        }
    }
}
