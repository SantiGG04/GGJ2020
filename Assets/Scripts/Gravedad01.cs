using UnityEngine;
using System.Collections;

public class Gravedad01 : MonoBehaviour
{
	// Para funcionar tiene que haber un Layer llamado "Piso", y evidentemente el piso tiene que tener este layer

	public float FuerzaVertical;
	public float FuerzaVerticalMaximaParaCaidas; //Para evitar que rompa la física atravezando el piso por una caída muy fuerte
	public bool EnPiso;
	public float Gravedad;
	public float TiempoMinimoEnAire = 0.1f;
	public float Contador;

	public GameObject origenRayCast;
	public float distanciaRayCast;

	public LayerMask layerPiso;

	void FixedUpdate()
	{
        //Amortiguación Caída (Detecta un poco antes de tocar el suelo para bajar la fuerza de la caída y que no se entierre en el piso)
        float distanciaAmortiguacion;
        distanciaAmortiguacion = distanciaRayCast + 0.2f; //Quizás hay que ajustar este número dependiendo de cada juego
        RaycastHit amortiguarCaida;
        Ray Col = new Ray(origenRayCast.transform.position, Vector3.down);
        Debug.DrawRay(origenRayCast.transform.position, Vector3.down * distanciaAmortiguacion);

        if (FuerzaVertical < -1 && Physics.Raycast(Col, out amortiguarCaida, distanciaAmortiguacion, layerPiso))
        {
            FuerzaVertical = -1;
        }

        RaycastHit Hit;
        Ray Colision = new Ray(origenRayCast.transform.position, Vector3.down);
        Debug.DrawRay(origenRayCast.transform.position, Vector3.down * distanciaRayCast);

        if (FuerzaVertical <= 0 && //Esto es sólo porque es un plataformero y no quiero que detecte las colisiones con el piso al saltar
            Physics.Raycast(Colision, out Hit, distanciaRayCast, layerPiso))
		{
            EnPiso = true;
			Animator anim = gameObject.GetComponentInChildren<Animator>();
			anim.SetBool("Jumping", false);
			FuerzaVertical = 0;
		}
		else
		{
			EnPiso = false;
		}

		if (EnPiso == false)
		{
			EnAire ();
		}
        /*
		if (FuerzaVertical <= 0)// Activa el IgnoreLayerCollision para poder atravesar pisos (Plataformero)
		{
			NoSaltarPisos ();
		}

		if (FuerzaVertical > 0)// Desactiva el IgnoreLayerCollision para poder atravesar pisos (Plataformero)
		{
			SaltarPisos ();
		}
        */
	}

	public void EnAire()
	{
		Animator anim = gameObject.GetComponentInChildren<Animator>();
		anim.SetBool("Jumping", true);

		Contador += Time.deltaTime;

		transform.Translate(0, FuerzaVertical * Time.deltaTime, 0);

		FuerzaVertical -= Gravedad * Time.deltaTime;

		if (FuerzaVertical < FuerzaVerticalMaximaParaCaidas)
		{
			FuerzaVertical = FuerzaVerticalMaximaParaCaidas;
		}

		if (Contador >= TiempoMinimoEnAire && EnPiso)
		{
			{
				//FuerzaVertical = 0; //De momento lo saco porque ya lo hago en el RayCast
				Contador = 0;
			}
		}
	}
    /*
	public void SaltarPisos()
	{
		Physics.IgnoreLayerCollision(8,9);
	}

	public void NoSaltarPisos()
	{
		Physics.IgnoreLayerCollision(8,9, false);
	}
    */
}