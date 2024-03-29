﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager01 : MonoBehaviour
{
    [Header("Singleton")]
    public static GameManager01 instance;

    [Header("Condiciones Derrota/Victoria")]
    public int nivelDeRoturaParaDerrota;
    public int nivelDeRotura;
    public float tiempoVictoria;

    [Header("Canvas")]
    public Image imgCountDown;
    public Text txtCountDown;

    [Header("Timer")]
    private float timer = 1;
    private bool canCount = false;
    private bool doOnce = false;
    private bool doOnce2 = false;

    [Header("Escenas")]
    public string escenaVictoria;
    public string escenaDerrota;
    public string escenaJuego;

    [Header("Archivos de Música")]
    public AudioSource audioGameA;
    public AudioSource audioGameB;

    void Start()
    {
        MakeSingleton();
        imgCountDown.enabled = false; // Deshabilitamos la Imagen del Contador
        txtCountDown.enabled = false; // Ocultamos el Texto que muestra el Conteo
    }

    void Update()
    {
        Scene escenaActual = SceneManager.GetActiveScene(); // Chequeamos la Escena en la que estamos

        if ((escenaActual.name == escenaJuego) && (!doOnce2))
        {
            IniciarNivel(); // Si la Escena corresponde al Nivel de Juego, llamamos a Iniciar Nivel
        }

        if (timer >= 0.0f && canCount)
        {
            timer -= Time.deltaTime;
            int intTimer = Mathf.FloorToInt(timer);
            txtCountDown.text = intTimer.ToString("D"); // Se muestra el Contador en el Objeto Text
        }
        else if (timer <= 0.0f && !doOnce)
        {
            SalirDeNivel();
            SceneManager.LoadScene(escenaVictoria); // Se carga la Escena Victoria
        }

        if (nivelDeRotura >= nivelDeRoturaParaDerrota)
        {
            SalirDeNivel();
            SceneManager.LoadScene(escenaDerrota); // Se carga la Escena Derrota
        }
        //TODO: Habría que hacer una función que haga que cada vez que se rompe la máquina esto cambie, y que calcule cuánto debería cambiar según el nivelDeRoturaParaDerrota, que podría cambiar en ciertos niveles de dificultad
        else if (nivelDeRotura == 2)
        {
            audioGameA.volume = 0.0f; // Música OFF
            audioGameB.volume = 0.5f; // Distorsión ON
        }
        else if (nivelDeRotura == 1)
        {
            audioGameA.volume = 0.5f; // Música ON
            audioGameB.volume = 0.5f; // Distorsión ON
        }
        else if (nivelDeRotura == 0)
        {
            audioGameA.volume = 0.5f; // Música ON
            audioGameB.volume = 0.0f; // Distorsión OFF
        }
    }

    private void MakeSingleton()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void IniciarNivel()
    {
        timer = tiempoVictoria; // Incializamos el Timer

        doOnce = false; // Para que pueda entrar al IF de Condicion de Victoria
        doOnce2 = true; // Para que no vuelva a Inciar el Nivel
        canCount = true; // Para que empiece a Contar

        imgCountDown.enabled = true; // Mostramos la Imagen que muestra el Conteo
        txtCountDown.enabled = true; // Ocultamos el Texto que muestra el Conteo
    }

    private void SalirDeNivel()
    {
        audioGameA.volume = 0.5f; // Música ON
        audioGameB.volume = 0.0f; // Distorsión OFF

        nivelDeRotura = 0; // Re inicializamos el Nivel de Rotura (Esto tiene que hacerse acá, sino al perder no carga la Escena siguiente)

        doOnce = true; // Para que no vuelva a entrar al IF de Condicion de Victoria
        doOnce2 = false; // Para que cuando carge la nueva escena vuelva a comprobar cuando se carga de nuevo el Nivel0001
        canCount = false; // Para que no siga contando

        timer = 0.0f; // Ponemos el Contador en cero

        imgCountDown.enabled = false; // Ocultamos la Imagen que muestra el Conteo
        txtCountDown.enabled = false; // Ocultamos el Texto que muestra el Conteo
        txtCountDown.text = ""; // Ponemos el Texto del Contador en vacio
    }
}