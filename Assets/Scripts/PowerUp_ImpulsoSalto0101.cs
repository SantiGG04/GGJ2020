using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp_ImpulsoSalto0101 : MonoBehaviour
{
    public float impulsoSalto;

    public void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.transform.parent.name == "Fisica")
        {
            Gravedad01 Grav = col.gameObject.GetComponentInParent<Gravedad01>();
            Debug.Log(Grav.FuerzaVertical);
            Grav.FuerzaVertical = Grav.FuerzaVertical + impulsoSalto;
            Debug.Log(Grav.FuerzaVertical);
            Grav.EnAire();

            SaltoPersonaje01 Salto = col.gameObject.GetComponentInParent<SaltoPersonaje01>();
            Salto.SaltosRestantes = 0;
        }
    }

    public void OnTriggerStay(Collider col)
    {
        if (col.gameObject.transform.parent.name == "Fisica")
        {
            
        }
    }
}
