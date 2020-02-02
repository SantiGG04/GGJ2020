using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SistemaFallandoGeoposicionamiento01 : MonoBehaviour
{
    public GameObject miniMapa;
    public void SistemaFallando()
    {
        miniMapa.SetActive(false);
    }
}
