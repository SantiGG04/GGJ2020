using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoEnemigos : MonoBehaviour
{
	public float velocidadMovimiento;

	public GameObject origenRayCasts;

	public float distanciaRayCastL;
	public float distanciaRayCastR;
	public LayerMask layerParedes;

	void FixedUpdate()
	{
		RaycastHit lHit;
		Ray lColision = new Ray(origenRayCasts.transform.position, Vector3.left);
		Debug.DrawRay(origenRayCasts.transform.position, Vector3.left * distanciaRayCastL);

		RaycastHit rHit;
		Ray rColision = new Ray(origenRayCasts.transform.position, Vector3.right);
		Debug.DrawRay(origenRayCasts.transform.position, Vector3.right * distanciaRayCastR);

		if (Physics.Raycast(lColision, out lHit, distanciaRayCastL, layerParedes))
		{
			velocidadMovimiento *= -1;
		}
		
		if  (Physics.Raycast(rColision, out rHit, distanciaRayCastR, layerParedes))
		{
			velocidadMovimiento *= -1;
		}
		
		transform.Translate(velocidadMovimiento * Time.deltaTime, 0, 0);
	}
}
