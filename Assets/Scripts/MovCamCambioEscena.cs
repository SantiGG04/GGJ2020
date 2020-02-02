using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovCamCambioEscena : MonoBehaviour
{
    public Camera mainCam;
    // public GameObject mainCanvas;

    /*
    public float cantidaMovimientos; // La Cantidad de veces que va a llamar la funcion MoverCamara
    public float velocidadMovimiento; // Cuanto pasa entre cada vez que llama a la funcion MoverCamara
    public float longitudMovimiento; // Que tanto se mueve cada vez que llamamos a la funcion MoverCamara
    */

    public float cantidadMovimiento; // Cuanto se mueve la Camara

    private bool deboMoverme = false;
    // private int contadorMovimientos = 0;

    void Update()
    {
        if (deboMoverme)
        {
            //mainCanvas.GetComponent<Canvas>().enabled = false;

            //InvokeRepeating("MoverCamara", 0, velocidadMovimiento);

            mainCam.gameObject.transform.Translate(cantidadMovimiento, 0, 0);

            deboMoverme = false;
        }        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.transform.parent.name == "Personaje")
        {
            deboMoverme = true;
            cantidadMovimiento = cantidadMovimiento * -1;
        }
    }

    /*
    void MoverCamara()
    {
        mainCam.gameObject.transform.Translate(longitudMovimiento, 0, 0);

        contadorMovimientos++;

        if (contadorMovimientos == cantidaMovimientos)
        {
            CancelInvoke();
        }
    }
    */
}
