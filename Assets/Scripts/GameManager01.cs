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
    private float timer;
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
        timer = tiempoVictoria;
    }

    void Update()
    {
        Scene escenaActual = SceneManager.GetActiveScene();

        if ((escenaActual.name == escenaJuego) && (!doOnce2))
        {
            timer = tiempoVictoria;
            doOnce2 = true;
            canCount = true;
            doOnce = false;
        }

        if (timer >= 0.0f && canCount)
        {
            timer -= Time.deltaTime;
            txtCountDown.text = timer.ToString("F");
        }
        else if (timer <= 0.0f && !doOnce)
        {
            canCount = false;
            doOnce = true;
            txtCountDown.text = "0.00";
            timer = 0.0f;
            audioGameA.volume = 0.5f;
            audioGameB.volume = 0.0f;
            nivelDeRotura = 0;
            doOnce2 = false;
            SceneManager.LoadScene(escenaVictoria);
        }

        if (nivelDeRotura == 3)
        {
            audioGameA.volume = 0.5f;
            audioGameB.volume = 0.0f;
            nivelDeRotura = 0;
            doOnce2 = false;
            SceneManager.LoadScene(escenaDerrota);
        }
        else if (nivelDeRotura == 2)
        {
            audioGameA.volume = 0.0f;
            audioGameB.volume = 0.5f;
        }
        else if (nivelDeRotura == 1)
        {
            audioGameA.volume = 0.5f;
            audioGameB.volume = 0.5f;
        }
        else if (nivelDeRotura == 0)
        {
            audioGameA.volume = 0.5f;
            audioGameB.volume = 0.0f;
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
}
