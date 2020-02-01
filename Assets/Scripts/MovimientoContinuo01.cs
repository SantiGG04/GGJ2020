using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoContinuo01 : MonoBehaviour
{

	public float VelocidadMovimiento;

	void Update ()
	{
		transform.Translate(0, VelocidadMovimiento * Time.deltaTime, 0);
	}
}