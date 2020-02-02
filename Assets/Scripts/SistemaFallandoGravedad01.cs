using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SistemaFallandoGravedad01 : MonoBehaviour
{
    public float porcentajePenalizacionVelocidad;
    public void SistemaFallando()
    {
        GameObject PJ = GameObject.FindGameObjectWithTag("Player");
        SaltoPersonaje01 saltoPJ = PJ.GetComponentInChildren<SaltoPersonaje01>();

        saltoPJ.FuerzaSalto = saltoPJ.FuerzaSalto - ((saltoPJ.FuerzaSalto * porcentajePenalizacionVelocidad) / 100);
    }
}
