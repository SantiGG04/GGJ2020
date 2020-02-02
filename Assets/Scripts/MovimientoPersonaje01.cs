using UnityEngine;
using System.Collections;

public class MovimientoPersonaje01 : MonoBehaviour

{
    public float velocidadMovimiento;

	public bool estoyPenalizado = false;
	public float velocidadMovPenalizado;
	public float duracionPenalizacion;
	public float timer;


	public GameObject origenRayCasts;
	public float distanciaRayCastL;
	public float distanciaRayCastR;
	public bool lBloqueada;
	public bool rBloqueada;

	public LayerMask layerParedes;

    void FixedUpdate ()
	{
		RaycastHit lHit;
		Ray lColision = new Ray (origenRayCasts.transform.position, Vector3.left);
		Debug.DrawRay (origenRayCasts.transform.position, Vector3.left * distanciaRayCastL);

		if (Physics.Raycast (lColision, out lHit, distanciaRayCastL, layerParedes))
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

		if (Physics.Raycast (rColision, out rHit, distanciaRayCastR, layerParedes))
		{
			rBloqueada = true;
		}

		else
		{
			rBloqueada = false;
		}

		if(Input.GetKey(KeyCode.RightArrow) && rBloqueada == false && estoyPenalizado == false)
			transform.Translate(velocidadMovimiento * Time.deltaTime, 0, 0);
		if (Input.GetKey(KeyCode.LeftArrow) && lBloqueada == false && estoyPenalizado == false)
			transform.Translate(-velocidadMovimiento * Time.deltaTime, 0, 0);

		if (Input.GetKey(KeyCode.RightArrow) && rBloqueada == false && estoyPenalizado == true)
			transform.Translate(velocidadMovPenalizado * Time.deltaTime, 0, 0);
		if (Input.GetKey(KeyCode.LeftArrow) && lBloqueada == false && estoyPenalizado == true)
			transform.Translate(-velocidadMovPenalizado * Time.deltaTime, 0, 0);
		
		if (timer >= 0.0f)
		{
			timer -= Time.deltaTime;
		}
		else if (timer <= 0.0f)
		{
			estoyPenalizado = false;
			timer = 0.0f;
		}
	}
}
