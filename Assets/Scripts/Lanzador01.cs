using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lanzador01 : MonoBehaviour
{
	public GameObject Proyectil;
	public int CantidadActual;
	public int CantidadMaxima;
	public float Enfriamiento;
	public float Contador;

	void Update ()
	{
		Contador += Time.deltaTime;

		if (Input.GetKeyDown (KeyCode.S) && Contador >= Enfriamiento && CantidadActual > 0 && GetComponentInParent<Gravedad01>().EnPiso == false)
		{
			Instantiate (Proyectil, gameObject.transform.position, gameObject.transform.rotation);
			Contador = 0;
			CantidadActual--;
		}
	}
}
