using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager01 : MonoBehaviour
{
    [Header("Singleton")]
    public static GameManager01 instance;

    [Header("Condiciones Derrota/Victoria")]
    public int nivelDeRotura;
    public float tiempoVictoria;

    [Header("Canvas")]
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
        txtCountDown.enabled = false; // Deshabilitamos el Text del Contador
    }

    void Update()
    {
        Scene escenaActual = SceneManager.GetActiveScene();

        if ((escenaActual.name == escenaJuego) && (!doOnce2))
        {
            IniciarNivel();
        }

        if (timer >= 0.0f && canCount)
        {
            timer -= Time.deltaTime;
            txtCountDown.text = timer.ToString("F"); // Se muestra el Contador en el Objeto Text
        }
        else if (timer <= 0.0f && !doOnce)
        {
            SalirDeNivel();
            SceneManager.LoadScene(escenaVictoria); // Se carga la Escena Victoria
        }

        if (nivelDeRotura == 3)
        {
            SalirDeNivel();
            SceneManager.LoadScene(escenaDerrota); // Se carga la Escena Derrota
        }
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

    private void SalirDeNivel()
    {
        audioGameA.volume = 0.5f; // Subimos la Música
        audioGameB.volume = 0.0f; // Bajaos la Distorsión
 
        nivelDeRotura = 0; // Re inicializamos el Nivel de Rotura (Esto tiene que hacerse acá, sino al perder no carga la Escena siguiente)

        doOnce = true; // Para que no vuelva a entrar a este IF
        doOnce2 = false; // Lo ponemos en falso para que cuando carge la nueva escena vuelva a comprobar cuando se carga de nuevo el Nivel0001
        canCount = false; // Para que no siga contando

        timer = 0.0f; // Ponemos el Contador en cero

        txtCountDown.enabled = false; // Deshabilitamos el Text del Contador
        txtCountDown.text = ""; // Ponemos el Texto del Contador en vacio para que no se vea
    }

    private void IniciarNivel()
    {
        timer = tiempoVictoria;
        txtCountDown.enabled = true;
        doOnce2 = true;
        canCount = true;
        doOnce = false;
    }
}