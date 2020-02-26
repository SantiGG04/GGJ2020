using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BotonSiguiente : MonoBehaviour
{
    [Header("Imagenes")]
    public Image imagenTutorial01;
    public Image imagenTutorial02;
    public Image imagenTutorial03;
    public Image imagenTutorial04;
    public Image imagenTutorial05;
    public Image imagenTutorial06;
    public Image imagenTutorial07;

    [Header("Botones")]
    public Button botonSkip;
    public Button botonSiguiente;
    public Button botonJugar;

    private int contadorImagenes;

    private void Start()
    {
        contadorImagenes = 1;
        imagenTutorial01.gameObject.SetActive(true);
        imagenTutorial02.gameObject.SetActive(false);
        imagenTutorial03.gameObject.SetActive(false);
        imagenTutorial04.gameObject.SetActive(false);
        imagenTutorial05.gameObject.SetActive(false);
        imagenTutorial06.gameObject.SetActive(false);
        imagenTutorial07.gameObject.SetActive(false);
        botonSkip.gameObject.SetActive(true);
        botonSiguiente.gameObject.SetActive(true);
        botonJugar.gameObject.SetActive(false);
    }

    public void ImagenSiguiente()
    {
        if (contadorImagenes == 1)
        {
            imagenTutorial01.gameObject.SetActive(false);
            imagenTutorial02.gameObject.SetActive(true);
            contadorImagenes++;
        }
        else if (contadorImagenes == 2)
        {
            imagenTutorial02.gameObject.SetActive(false);
            imagenTutorial03.gameObject.SetActive(true);
            contadorImagenes++;
        }
        else if (contadorImagenes == 3)
        {
            imagenTutorial03.gameObject.SetActive(false);
            imagenTutorial04.gameObject.SetActive(true);
            contadorImagenes++;
        }
        else if (contadorImagenes == 4)
        {
            imagenTutorial04.gameObject.SetActive(false);
            imagenTutorial05.gameObject.SetActive(true);
            contadorImagenes++;
        }
        else if (contadorImagenes == 5)
        {
            imagenTutorial05.gameObject.SetActive(false);
            imagenTutorial06.gameObject.SetActive(true);
            contadorImagenes++;
        }
        else if (contadorImagenes == 6)
        {
            imagenTutorial06.gameObject.SetActive(false);
            imagenTutorial07.gameObject.SetActive(true);
            botonSkip.gameObject.SetActive(false);
            botonSiguiente.gameObject.SetActive(false);
            botonJugar.gameObject.SetActive(true);
        }
    }
}
