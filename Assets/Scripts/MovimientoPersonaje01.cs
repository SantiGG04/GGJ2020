﻿using UnityEngine;
using System.Collections;

public class MovimientoPersonaje01 : MonoBehaviour

{
	[Header("Movimiento")]
	public float velocidadMovimientoOriginal;
    public float velocidadMovimientoActual;

	[Header("Falla MacWire")]
	public bool modificadorDireccion = false;

	[Header("Penalizador Velocidad")]
	public bool estoyPenalizado = false;
	public float velocidadMovPenalizado;
	public float duracionPenalizacion;
	public float timer;

	[Header("Bonificador Velocidad")]
    public bool estoyBonificado = false;
    public float velocidadMovBonificada;
    public float duracionBonificacion;
    public float timerBonificacion;

	[Header("Raycast")]
    public GameObject origenRayCasts;
	public float distanciaRayCastL;
	public float distanciaRayCastR;
	public bool lBloqueada;
	public bool rBloqueada;

	[Header("Layers")]
	public LayerMask layerParedes;

	void Update()
    {
        if (estoyPenalizado)
        {
            velocidadMovimientoActual = velocidadMovPenalizado;
        }
        else if (estoyBonificado)
        {
            velocidadMovimientoActual = velocidadMovBonificada;
        }
        else
        {
            velocidadMovimientoActual = velocidadMovimientoOriginal;
        }

		if (!modificadorDireccion)
		{
			RaycastHit lHit;
			Ray lColision = new Ray(origenRayCasts.transform.position, Vector3.left);
			Debug.DrawRay(origenRayCasts.transform.position, Vector3.left * distanciaRayCastL);

			if (Physics.Raycast(lColision, out lHit, distanciaRayCastL, layerParedes))
			{
				lBloqueada = true;
			}
			else
			{
				lBloqueada = false;
			}

			RaycastHit rHit;
			Ray rColision = new Ray(origenRayCasts.transform.position, Vector3.right);
			Debug.DrawRay(origenRayCasts.transform.position, Vector3.right * distanciaRayCastR);

			if (Physics.Raycast(rColision, out rHit, distanciaRayCastR, layerParedes))
			{
				rBloqueada = true;
			}
			else
			{
				rBloqueada = false;
			}
		}
		else
		{
			RaycastHit lHit;
			Ray lColision = new Ray(origenRayCasts.transform.position, Vector3.right);
			Debug.DrawRay(origenRayCasts.transform.position, Vector3.right * distanciaRayCastL);

			if (Physics.Raycast(lColision, out lHit, distanciaRayCastL, layerParedes))
			{
				lBloqueada = true;
			}
			else
			{
				lBloqueada = false;
			}

			RaycastHit rHit;
			Ray rColision = new Ray(origenRayCasts.transform.position, Vector3.left);
			Debug.DrawRay(origenRayCasts.transform.position, Vector3.left * distanciaRayCastR);

			if (Physics.Raycast(rColision, out rHit, distanciaRayCastR, layerParedes))
			{
				rBloqueada = true;
			}
			else
			{
				rBloqueada = false;
			}
		}

		if (Input.GetKey(KeyCode.RightArrow) && rBloqueada == false && modificadorDireccion == false)
		{
			SpriteRenderer rend = gameObject.GetComponentInChildren<SpriteRenderer>();
			rend.flipX = true;
			Animator anim = gameObject.GetComponentInChildren<Animator>();
			anim.SetInteger("Velocidad", 1);
			transform.Translate(velocidadMovimientoActual * Time.deltaTime, 0, 0);
		}
		else if (Input.GetKey(KeyCode.RightArrow) && rBloqueada == false && modificadorDireccion == true)
		{
			SpriteRenderer rend = gameObject.GetComponentInChildren<SpriteRenderer>();
			rend.flipX = false;
			Animator anim = gameObject.GetComponentInChildren<Animator>();
			anim.SetInteger("Velocidad", 1);
			transform.Translate(-velocidadMovimientoActual * Time.deltaTime, 0, 0);
		}

		if (Input.GetKey(KeyCode.LeftArrow) && lBloqueada == false && modificadorDireccion == false)
		{
			SpriteRenderer rend = gameObject.GetComponentInChildren<SpriteRenderer>();
			rend.flipX = false;
			Animator anim = gameObject.GetComponentInChildren<Animator>();
			anim.SetInteger("Velocidad", 1);
			transform.Translate(-velocidadMovimientoActual * Time.deltaTime, 0, 0);
		}
		else if (Input.GetKey(KeyCode.LeftArrow) && lBloqueada == false && modificadorDireccion == true)
		{
			SpriteRenderer rend = gameObject.GetComponentInChildren<SpriteRenderer>();
			rend.flipX = true;
			Animator anim = gameObject.GetComponentInChildren<Animator>();
			anim.SetInteger("Velocidad", 1);
			transform.Translate(velocidadMovimientoActual * Time.deltaTime, 0, 0);
		}

		if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow))
		{
			Animator anim = gameObject.GetComponentInChildren<Animator>();
			anim.SetInteger("Velocidad", 0);
		}
		
		if (timer >= 0.0f)
		{
			timer -= Time.deltaTime;
		}
		else if (timer <= 0.0f)
		{
			estoyPenalizado = false;
			timer = 0.0f;
		}

        if (timerBonificacion >= 0.0f)
        {
            timerBonificacion -= Time.deltaTime;
        }
        else if (timerBonificacion <= 0.0f)
        {
            estoyBonificado = false;
            timerBonificacion = 0.0f;
        }
	}
}
