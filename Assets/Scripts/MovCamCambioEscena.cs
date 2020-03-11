using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovCamCambioEscena : MonoBehaviour
{
    [Header("Main Camera")]
    public Camera mainCam;

    [Header("Parametros Movimiento")]
    public float cantidadMovimiento; // Cuanto se mueve la Camara
    private Vector3 positionEntrada;
    private GameObject goPersonaje;

    private void Start()
    {
        goPersonaje = null;
    }

    private void Update()
    {
        if (goPersonaje != null)
        {
            if (Vector3.Distance(positionEntrada, transform.position) >= 7.0f)
            {
                Debug.Log(Vector3.Distance(positionEntrada, transform.position));

                mainCam.gameObject.transform.Translate(cantidadMovimiento, 0, 0);
                cantidadMovimiento *= -1;

                goPersonaje = null;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.transform.parent.name == "Personaje")
        {
            goPersonaje = other.transform.gameObject;
            Debug.Log(goPersonaje.transform.parent.name);

            positionEntrada = goPersonaje.transform.position;
            Debug.Log(Vector3.Distance(positionEntrada, transform.position));
        }
    }
}