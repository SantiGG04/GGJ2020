using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pieza01 : MonoBehaviour
{
    public string nombrePieza;
    public int ID;

    public void OnTriggerEnter()
    {
        GameObject PJ = GameObject.FindGameObjectWithTag("Player");
        Inventario01 Inv = PJ.GetComponentInChildren<Inventario01>();
        Inv.pieza01++;
        Destroy(gameObject);
    }
}
