using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;

public class ObjetoRoto01 : MonoBehaviour
{
    public GameObject Cartel;
    public GameObject contenedorPieza01;
    public GameObject contenedorPieza02;
    public GameObject contenedorPieza03;
    public bool pieza01;
    public bool pieza02;
    public bool pieza03;
    public GameObject tildePieza01;
    public GameObject tildePieza02;
    public GameObject tildePieza03;

    public void OnTriggerEnter()
    {
        ContenedorPiezas01 cont01= contenedorPieza01.GetComponentInChildren<ContenedorPiezas01>();
        if (cont01.cantidadPieza > 0 && pieza01 == false)
        {
            cont01.cantidadPieza--;
            pieza01 = true;
        }
        
        if (pieza01 == true) tildePieza01.SetActive(true);

        ContenedorPiezas01 cont02 = contenedorPieza02.GetComponentInChildren<ContenedorPiezas01>();
        if (cont02.cantidadPieza > 0 && pieza02 == false)
        {
            cont02.cantidadPieza--;
            pieza02 = true;
        }

        if (pieza02 == true) tildePieza02.SetActive(true);

        ContenedorPiezas01 cont03 = contenedorPieza03.GetComponentInChildren<ContenedorPiezas01>();
        if (cont03.cantidadPieza > 0 && pieza03 == false)
        {
            cont03.cantidadPieza--;
            pieza03 = true;
        }
        
        if (pieza03 == true) tildePieza03.SetActive(true);

        Cartel.SetActive(true);
    }

    public void OnTriggerExit()
    {
        Cartel.SetActive(false);
    }
}
