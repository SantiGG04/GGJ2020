using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovCamDesdePersonaje : MonoBehaviour
{
	[Header("Main Camara")]
	public Camera mainCamara;

	[Header("Posicion Camara 01")]
	public Vector3 positionCamara01;
	public float posCam01_A;
	public float posCam01_B;

	[Header("Posicion Camara 02")]
	public Vector3 positionCamara02;
	public float posCam02_A;
	public float posCam02_B;

	[Header("Posicion Camara 03")]
	public Vector3 positionCamara03;
	public float posCam03_A;
	public float posCam03_B;

	[Header("Posicion Camara 04")]
	public Vector3 positionCamara04;
	public float posCam04_A;
	public float posCam04_B;

	[Header("Posicion Camara 05")]
	public Vector3 positionCamara05;
	public float posCam05_A;
	public float posCam05_B;

	[Header("Posicion Camara 06")]
	public Vector3 positionCamara06;
	public float posCam06_A;
	public float posCam06_B;

	[Header("Posicion Camara 07")]
	public Vector3 positionCamara07;
	public float posCam07_A;
	public float posCam07_B;
	private void Start()
	{
		mainCamara = Camera.main;
	}

	private void Update()
	{
		if (transform.position.x >= posCam01_A && transform.position.x <= posCam01_B)
		{
			mainCamara.gameObject.transform.position = positionCamara01;
		}
		else if (transform.position.x >= posCam02_A && transform.position.x <= posCam02_B)
		{
			mainCamara.gameObject.transform.position = positionCamara02;
		}
		else if (transform.position.x >= posCam03_A && transform.position.x <= posCam03_B)
		{
			mainCamara.gameObject.transform.position = positionCamara03;
		}
		else if (transform.position.x >= posCam04_A && transform.position.x <= posCam04_B)
		{
			mainCamara.gameObject.transform.position = positionCamara04;
		}
		else if (transform.position.x >= posCam05_A && transform.position.x <= posCam05_B)
		{
			mainCamara.gameObject.transform.position = positionCamara05;
		}
		else if (transform.position.x >= posCam06_A && transform.position.x <= posCam06_B)
		{
			mainCamara.gameObject.transform.position = positionCamara06;
		}
		else if (transform.position.x >= posCam07_A && transform.position.x <= posCam07_B)
		{
			mainCamara.gameObject.transform.position = positionCamara07;
		}
	}
}
