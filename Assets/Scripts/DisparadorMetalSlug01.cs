using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparadorMetalSlug01 : MonoBehaviour
{
	public GameObject Fuente;
	public GameObject ubiFuenteRU;
	public GameObject ubiFuenteRD;
	public GameObject ubiFuenteLU;
	public GameObject ubiFuenteLD;
	public GameObject ubiFuenteRR;
	public GameObject ubiFuenteLL;
	public GameObject ubiFuenteUU;
	public GameObject ubiFuenteDD;

	private bool apuntandoIzq;
	private bool apuntando;

	public GameObject Proyectil;
	private Vector3 ubiActual;
	public int CantidadActual;
	public int CantidadMaxima;
	public float Enfriamiento;
	public float Contador;

	void Update ()
	{
		Contador += Time.deltaTime;

		if (Input.GetKeyDown (KeyCode.S) && Contador >= Enfriamiento && CantidadActual > 0)
		{
			Instantiate (Proyectil, Fuente.transform.position, Fuente.transform.rotation);
			Contador = 0;
			CantidadActual--;
		}

		if (Input.GetKey(KeyCode.RightArrow))
		{
			Fuente.transform.position = ubiFuenteRR.transform.position;
			Fuente.transform.rotation = ubiFuenteRR.transform.rotation;

			apuntando = true;
			apuntandoIzq = false;

			if(Input.GetKey(KeyCode.UpArrow))
			{
				Fuente.transform.position = ubiFuenteRU.transform.position;
				Fuente.transform.rotation = ubiFuenteRU.transform.rotation;
			}

			if(Input.GetKey(KeyCode.DownArrow))
			{
				Fuente.transform.position = ubiFuenteRD.transform.position;
				Fuente.transform.rotation = ubiFuenteRD.transform.rotation;
			}
		}

		if (Input.GetKey (KeyCode.LeftArrow))
		{
			Fuente.transform.position = ubiFuenteLL.transform.position;
			Fuente.transform.rotation = ubiFuenteLL.transform.rotation;

			apuntando = true;
			apuntandoIzq = true;

			if(Input.GetKey(KeyCode.UpArrow))
			{
				Fuente.transform.position = ubiFuenteLU.transform.position;
				Fuente.transform.rotation = ubiFuenteLU.transform.rotation;
			}

			if(Input.GetKey(KeyCode.DownArrow))
			{
				Fuente.transform.position = ubiFuenteLD.transform.position;
				Fuente.transform.rotation = ubiFuenteLD.transform.rotation;
			}
		}

		if (Input.GetKey(KeyCode.UpArrow))
		{
			Fuente.transform.position = ubiFuenteUU.transform.position;
			Fuente.transform.rotation = ubiFuenteUU.transform.rotation;

			apuntando = true;

			if(Input.GetKey(KeyCode.RightArrow))
			{
				Fuente.transform.position = ubiFuenteRU.transform.position;
				Fuente.transform.rotation = ubiFuenteRU.transform.rotation;
			}

			if(Input.GetKey(KeyCode.LeftArrow))
			{
				Fuente.transform.position = ubiFuenteLU.transform.position;
				Fuente.transform.rotation = ubiFuenteLU.transform.rotation;
			}
		}

		if (Input.GetKey (KeyCode.DownArrow))
		{
			Fuente.transform.position = ubiFuenteDD.transform.position;
			Fuente.transform.rotation = ubiFuenteDD.transform.rotation;

			apuntando = true;

			if(Input.GetKey(KeyCode.RightArrow))
			{
				Fuente.transform.position = ubiFuenteRD.transform.position;
				Fuente.transform.rotation = ubiFuenteRD.transform.rotation;
			}

			if(Input.GetKey(KeyCode.LeftArrow))
			{
				Fuente.transform.position = ubiFuenteLD.transform.position;
				Fuente.transform.rotation = ubiFuenteLD.transform.rotation;
			}
		}

		if (Input.GetKeyUp(KeyCode.RightArrow)) apuntando = false;
		if (Input.GetKeyUp(KeyCode.LeftArrow)) apuntando = false;
		if (Input.GetKeyUp(KeyCode.UpArrow)) apuntando = false;
		if (Input.GetKeyUp(KeyCode.DownArrow)) apuntando = false;

		if(apuntando == false && apuntandoIzq == false)
		{
			Fuente.transform.position = ubiFuenteRR.transform.position;
			Fuente.transform.rotation = ubiFuenteRR.transform.rotation;
		}
		if(apuntando == false && apuntandoIzq == true)
		{
			Fuente.transform.position = ubiFuenteLL.transform.position;
			Fuente.transform.rotation = ubiFuenteLL.transform.rotation;
		}
	}
}
