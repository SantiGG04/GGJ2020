using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SistemaFallandoIluminacion01 : MonoBehaviour
{
    public Image imagenError;

    public void SistemaFallando()
    {
        imagenError.gameObject.SetActive(true);
    }
}
