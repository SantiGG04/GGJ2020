using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProyectilAmigo : MonoBehaviour
{
	public float VelocidadMovimiento;

	void Update ()
	{
		transform.Translate(VelocidadMovimiento * Time.deltaTime, 0, 0);
	}

	public void OnCollisionEnter (Collision col)
	{
		if (col.gameObject.layer == LayerMask.NameToLayer ("Enemigo"))
		{
			Destroy (gameObject);
		}
	}
}