using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjetoRoto01 : MonoBehaviour
{
    public string sistemaDe;

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

    public GameObject objetoFuncionando;
    public GameObject objetoRoto;
    
    public GameManager01 gameManager;

    public GameObject uIMision;
    public Text textoReloj;

    public bool error = false;
    public bool roto = false;
    public float tiempoParaErrorOriginal;
    public float tiempoParaErrorReal;
    public float tiempoParaError;
    public float tiempoParaRomperOriginal;
    public float tiempoParaRomperReal;
    public float tiempoParaRomper;
    public bool errorEjecutado;
    public float tiempoDisminuidoError;
    public float tiempoDisminuidoReparar;
    public Image imagenObjetoRoto;

    // Variables Canvas Quest
    [Header("Variables de QuestCanvas")]
    public Text txtTitle;

    // Variables de Sonido
    [Header("Variables de Sonido")]
    public GameObject contendedorSonidoError;
    public GameObject contendedorSonidoRota;
    public GameObject contendedorSonidoArreglando;

    public void Start()
    {
        // Inicializacion de Timers
        tiempoParaError = tiempoParaErrorOriginal;
        tiempoParaRomper = tiempoParaRomperOriginal;
        tiempoParaErrorReal = tiempoParaError;
        tiempoParaRomperReal = tiempoParaRomper;

        // Busca el GameManager
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager01>();

        // Inicializacion de Sonidos en false, para que no suenen si nos los olvidamos habilitados
        contendedorSonidoError.SetActive(false);
        contendedorSonidoRota.SetActive(false);
        contendedorSonidoArreglando.SetActive(false);

        // Inicializacion del Color del Titulo de la Quest
        txtTitle.color = Color.green;
    }

    public void Update()
    {
        tiempoParaError -= Time.deltaTime;
        
        if (tiempoParaError <= 0 && error == false)
        {
            error = true;
            contendedorSonidoError.SetActive(false); // Primero se deshabilita, ya que luego de que suene por primera vez hay que dejarlo habilitado para que termine el sonido
            contendedorSonidoError.SetActive(true); // Habilitamos el contenedor para que suenen los sonidos que contiene
            uIMision.SetActive(true);
            objetoRoto.SetActive(true);
            objetoFuncionando.SetActive(false);
            imagenObjetoRoto.gameObject.SetActive(true);
        }

        if (error == true && roto == false)
        {
            tiempoParaRomper -= Time.deltaTime;
            textoReloj.text = tiempoParaRomper.ToString("F");

            if (tiempoParaRomper <= (tiempoParaRomperReal/2))
            {
                txtTitle.color = Color.yellow; // Cambia el Color del Titulo de la Quest a Amarillo porque ya paso la mitad del tiempo que tiene para reparar
            }
        }

        if (tiempoParaRomper <= 0)
        {
            roto = true;
            if (errorEjecutado == false)
            {
                contendedorSonidoRota.SetActive(false); // Primero se deshabilita, ya que luego de que suene por primera vez hay que dejarlo habilitado para que termine el sonido
                contendedorSonidoRota.SetActive(true); // Habilitamos el contenedor para que suenen los sonidos que contiene
                gameManager.nivelDeRotura++;
                gameObject.SendMessage("SistemaFallando");
                errorEjecutado = true;
                textoReloj.text = ">>> ERROR <<<"; // Se acabo el tiempo, así que en el TIMER aparece este mensaje de ERROR
                textoReloj.color = Color.red; // Se acabo el tiempo, así que el Color del Texto del TIMER para a Rojo
                txtTitle.color = Color.red; // Se acabo el tiempo, así que el Color del Titulo pasa a Rojo
            }
        }
    }

    public void OnTriggerEnter(Collider col)
    {
        //if (col.gameObject.transform.parent.name == "Personaje")
        ///{
            Debug.Log(col.gameObject.transform.parent.name);
            if (error == true && roto == false)
            {
                ContenedorPiezas01 cont01 = contenedorPieza01.GetComponentInChildren<ContenedorPiezas01>();
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

                if (pieza01 == true && pieza02 == true && pieza03 == true)
                {
                    error = false;
                    contendedorSonidoArreglando.SetActive(false); // Primero se deshabilita, ya que luego de que suene por primera vez hay que dejarlo habilitado para que termine el sonido
                    contendedorSonidoArreglando.SetActive(true); // Habilitamos el contenedor para que suenen los sonidos que contiene
                    uIMision.SetActive(false);
                    imagenObjetoRoto.gameObject.SetActive(false);
                    tiempoParaError = tiempoParaErrorOriginal - tiempoDisminuidoError;
                    tiempoParaRomper = tiempoParaRomperOriginal - tiempoDisminuidoReparar;
                    tiempoParaErrorReal = tiempoParaError; // Actualizo el Tiempo Real que pasa hasta que se genere el Error
                    tiempoParaRomperReal = tiempoParaRomper; // Actualizo el Tiempo Real que tiene hasta que se Rompe
                    txtTitle.color = Color.green; // Ya arregló la máquina, así que volvemos a inicializar el Color del Titulo en Verde


                objetoRoto.SetActive(false);
                    objetoFuncionando.SetActive(true);

                    /*pieza01 = false; //Probando!!
                    pieza02 = false; //Probando!!
                    pieza03 = false; //Probando!!*/

                    tildePieza01.SetActive(false);
                    tildePieza02.SetActive(false);
                    tildePieza03.SetActive(false);
                }

                Cartel.SetActive(true);
            }
        //}
    }

    public void OnTriggerExit()
    {
        Cartel.SetActive(false);
    }
}
