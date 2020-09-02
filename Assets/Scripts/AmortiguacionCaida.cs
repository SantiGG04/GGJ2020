using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmortiguacionCaida : MonoBehaviour
{
	public float intensidadAmortiguacion = 1;

 	public void OnTriggerEnter(Collider col)
	{
        Debug.Log("1");
        if (col.gameObject.transform.parent.name == "Personaje")
		{
			Gravedad01 Grav = col.gameObject.GetComponentInChildren<Gravedad01>();
            Debug.Log("2");
			if (Grav.FuerzaVertical < 0)
			{
				Grav.FuerzaVertical -= intensidadAmortiguacion;
				Grav.EnAire();
			}
		}
	}
}
