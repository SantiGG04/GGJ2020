using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lanzador02 : MonoBehaviour
{
	public GameObject jugador;
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

	public GameObject Proyectil;
	private Vector3 ubiActual;
	//private Vector2 direccionProyectil;
	private float rotacionProyectilZ;
	public float velocidadProyectil;
	public int CantidadActual;
	public int CantidadMaxima;
	public float Enfriamiento;
	public float Contador;

	void Update ()
	{


		Contador += Time.deltaTime;

		if (Input.GetKeyDown (KeyCode.S) && Contador >= Enfriamiento && CantidadActual > 0/* && GetComponentInParent<Gravedad01>().EnPiso == false*/)
		{
			//Instantiate (Proyectil, Fuente.transform.position, Fuente.transform.rotation);

			Contador = 0;
			CantidadActual--;

			ubiActual = Fuente.transform.position;
			Vector3 diferencia = ubiActual - jugador.transform.position;
			float distancia = diferencia.magnitude;
			Vector2 direccion = diferencia / distancia;
			direccion.Normalize();

			DispararBala (direccion, rotacionProyectilZ);
		}

		if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.UpArrow))
		{
			Fuente.transform.position = ubiFuenteRU.transform.position;
			rotacionProyectilZ = ubiFuenteRU.transform.position.z;
		}

		if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.DownArrow))
		{
			Fuente.transform.position = ubiFuenteRD.transform.position;
			rotacionProyectilZ = ubiFuenteRD.transform.position.z;
		}

		if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.UpArrow))
		{
			Fuente.transform.position = ubiFuenteLU.transform.position;
			rotacionProyectilZ = ubiFuenteLU.transform.position.z;
		}

		if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.DownArrow))
		{
			Fuente.transform.position = ubiFuenteLD.transform.position;
			rotacionProyectilZ = ubiFuenteLD.transform.position.z;
		}

		if (Input.GetKeyDown(KeyCode.RightArrow))
		{
			Fuente.transform.position = ubiFuenteRR.transform.position;
			rotacionProyectilZ = ubiFuenteRR.transform.position.z;
		}

		if (Input.GetKeyDown (KeyCode.LeftArrow))
		{
			Fuente.transform.position = ubiFuenteLL.transform.position;
			rotacionProyectilZ = ubiFuenteLL.transform.position.z;
		}

		if (Input.GetKeyDown(KeyCode.UpArrow))
		{
			Fuente.transform.position = ubiFuenteUU.transform.position;
			rotacionProyectilZ = ubiFuenteUU.transform.position.z;
		}

		if (Input.GetKeyDown (KeyCode.DownArrow))
		{
			Fuente.transform.position = ubiFuenteDD.transform.position;
			rotacionProyectilZ = ubiFuenteDD.transform.position.z;
		}

		//direccionProyectil = ubiFuenteRU.transform.position;
	}

	void DispararBala(Vector2 direccion, float rotacionZ)
	{
		Debug.Log (direccion);
		Debug.Log (rotacionZ);
		GameObject instProyectil = Instantiate (Proyectil) as GameObject;
		instProyectil.transform.position = ubiFuenteRU.transform.position;
		instProyectil.transform.rotation = Quaternion.Euler (0, 0, rotacionZ);
		instProyectil.GetComponent<Rigidbody2D> ().velocity = direccion * velocidadProyectil;
	}
}
