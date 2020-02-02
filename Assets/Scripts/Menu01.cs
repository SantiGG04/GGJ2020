using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu01 : MonoBehaviour
{
    public GameObject menuInentario;

    public GameObject contenedorTubos;
    public Image imagenTubos;
    public GameObject contenedorTuercas;
    public Image imagenTuercas;
    public GameObject contenedorTornillos;
    public Image imagenTornillos;
    public GameObject contenedorBateria;
    public Image imagenBateria;
    public GameObject contenedorCinta;
    public Image imagenCinta;
    void Update()
    {
        if (Input.GetKey(KeyCode.S))
        {
            menuInentario.SetActive(true);
        }
        else
        {
            menuInentario.SetActive(false);
        }

        if (contenedorTubos.GetComponent<ContenedorPiezas01>().cantidadPieza > 0)
        {
            imagenTubos.gameObject.SetActive(true);
        }
        else
        {
            imagenTubos.gameObject.SetActive(false);
        }

        if (contenedorTuercas.GetComponent<ContenedorPiezas01>().cantidadPieza > 0)
        {
            imagenTuercas.gameObject.SetActive(true);
        }
        else
        {
            imagenTuercas.gameObject.SetActive(false);
        }

        if (contenedorTornillos.GetComponent<ContenedorPiezas01>().cantidadPieza > 0)
        {
            imagenTornillos.gameObject.SetActive(true);
        }
        else
        {
            imagenTornillos.gameObject.SetActive(false);
        }

        if (contenedorBateria.GetComponent<ContenedorPiezas01>().cantidadPieza > 0)
        {
            imagenBateria.gameObject.SetActive(true);
        }
        else
        {
            imagenBateria.gameObject.SetActive(false);
        }

        if (contenedorCinta.GetComponent<ContenedorPiezas01>().cantidadPieza > 0)
        {
            imagenCinta.gameObject.SetActive(true);
        }
        else
        {
            imagenCinta.gameObject.SetActive(false);
        }
    }
}
