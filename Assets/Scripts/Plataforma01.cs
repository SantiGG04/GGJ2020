using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataforma01 : MonoBehaviour
{
	public float impulsoSalto;

 	public void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.transform.parent.name == "Personaje")
		{
			Gravedad01 Grav = col.gameObject.GetComponentInChildren<Gravedad01>();
			if (Grav.FuerzaVertical >= 0)
			{
				Grav.FuerzaVertical += impulsoSalto;
				Grav.EnAire();
			}
		}
	}
}
