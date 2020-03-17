using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SistemaFallandoIluminacion01 : MonoBehaviour
{
    //    public Image imagenError;
    //    public Sprite imagenError;
    public GameObject imagenError;

    public void SistemaFallando()
    {
        imagenError.SetActive(true);
    }
}
