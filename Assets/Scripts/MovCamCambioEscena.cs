using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovCamCambioEscena : MonoBehaviour
{
    public Camera mainCam;
    public float velocidadMovimiento;
    public GameObject mainCanvas;

    void Start()
    {
        mainCam = Camera.main;
        mainCanvas = GameObject.Find("Canvas");
        velocidadMovimiento *= Time.deltaTime;
        mainCanvas.GetComponent<Canvas>().enabled = false;
    }

    void Update()
    {
        mainCam.gameObject.transform.Translate(velocidadMovimiento, 0, 0);
    }
}
