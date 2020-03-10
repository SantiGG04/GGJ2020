using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovCamCambioEscena : MonoBehaviour
{
    [Header("Main Camera")]
    public Camera mainCam;

    [Header("Parametros Movimiento")]
    public float cantidadMovimiento; // Cuanto se mueve la Camara
    private Transform transformEntrada;
    private Transform transformSalida;

    private void OnTriggerEnter(Collider other)
    {
        transformEntrada = other.transform.gameObject.transform;
    }

    private void OnTriggerExit(Collider other)
    {
        transformSalida = other.transform.gameObject.transform;
        float diferenciaEjeX;

        if (transformEntrada.position.x < transformSalida.position.x)
        {
            diferenciaEjeX = transformEntrada.position.x / transformSalida.position.x;
            Debug.Log(diferenciaEjeX);
        }
        else
        {
            diferenciaEjeX = transformSalida.position.x / transformEntrada.position.x;
            Debug.Log(diferenciaEjeX);
        }

        if (other.gameObject.transform.parent.name == "Personaje" && diferenciaEjeX >= 1)
        {
            cantidadMovimiento *= -1;
            mainCam.gameObject.transform.Translate(cantidadMovimiento, 0, 0);
        }
    }
}