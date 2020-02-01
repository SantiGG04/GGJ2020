using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiroContinuo01 : MonoBehaviour
{
	public float VelocidadRotacion;

	void Update ()
	{
		transform.Rotate (0, 0, VelocidadRotacion * Time.deltaTime);
	}
}
