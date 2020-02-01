using UnityEngine;
using System.Collections;

public class MovimientoPersonaje01 : MonoBehaviour

{
    public float VelocidadMovimiento;

	public GameObject origenRayCasts;
	public float distanciaRayCastL;
	public float distanciaRayCastR;
	public bool lBloqueada;
	public bool rBloqueada;

    void FixedUpdate ()
	{
		RaycastHit lHit;
		Ray lColision = new Ray (origenRayCasts.transform.position, Vector3.left);
		Debug.DrawRay (origenRayCasts.transform.position, Vector3.left * distanciaRayCastL);

		if (Physics.Raycast (lColision, out lHit, distanciaRayCastL))
		{
			lBloqueada = true;
		}

		else
		{
			lBloqueada = false;
		}

		RaycastHit rHit;
		Ray rColision = new Ray (origenRayCasts.transform.position, Vector3.right);
		Debug.DrawRay (origenRayCasts.transform.position, Vector3.right * distanciaRayCastR);

		if (Physics.Raycast (rColision, out rHit, distanciaRayCastR))
		{
			rBloqueada = true;
		}

		else
		{
			rBloqueada = false;
		}

		if(Input.GetKey(KeyCode.RightArrow) && rBloqueada == false)
			transform.Translate(VelocidadMovimiento * Time.deltaTime, 0, 0);
		if (Input.GetKey(KeyCode.LeftArrow) && lBloqueada == false)
			transform.Translate(-VelocidadMovimiento * Time.deltaTime, 0, 0);
    }
}
