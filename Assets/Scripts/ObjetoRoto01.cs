using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;

public class ObjetoRoto01 : MonoBehaviour
{
    public GameObject Cartel;
    public bool pieza01;
    public bool pieza02;
    public bool pieza03;
    public GameObject tildePieza01;
    public GameObject tildePieza02;
    public GameObject tildePieza03;
    public void OnTriggerEnter()
    {
        GameObject PJ = GameObject.FindGameObjectWithTag("Player");
        Inventario01 Inv = PJ.GetComponentInChildren<Inventario01>();
        if (Inv.pieza01 > 0 && pieza01 == false)
        {
            Inv.pieza01--;
            pieza01 = true;
        }

        if (pieza01 == true) tildePieza01.SetActive(true);
        if (pieza02 == true) tildePieza02.SetActive(true);
        if (pieza03 == true) tildePieza03.SetActive(true);

        Cartel.SetActive(true);
    }

    public void OnTriggerExit()
    {
        Cartel.SetActive(false);
    }
}
