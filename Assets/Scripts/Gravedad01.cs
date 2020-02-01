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

	void OnCollisionStay(Collision col)
	{
		if (col.gameObject.layer == LayerMask.NameToLayer("Piso"))
		{
			//De momento lo saco, prefiero que siempre que esté en el piso haga que la FuerzaVertical sea 0
			/*if (FuerzaVertical <= -4)// Hace un pequeño y casi imperceptible rebote si cae con mucha fuerza, para que no rompa la física atravezando el piso
			{
				FuerzaVertical = 0;
			}*/

			EnPiso = true;
			FuerzaVertical = 0;
		}
	}

	void OnCollisionExit(Collision col)
	{
		if (col.gameObject.layer == LayerMask.NameToLayer("Piso"))
		{
			EnPiso = false;
		}
	}

	void FixedUpdate()
	{
		if (EnPiso == false)
		{
			EnAire ();
		}

		if (FuerzaVertical <= 0)// Activa el IgnoreLayerCollision para poder atravesar pisos (Plataformero)
		{
			NoSaltarPisos ();
		}

		if (FuerzaVertical > 0)// Desactiva el IgnoreLayerCollision para poder atravesar pisos (Plataformero)
		{
			SaltarPisos ();
		}
	}

	void EnAire()
	{
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
				//FuerzaVertical = 0; //De momento lo saco porque ya lo hago en el OnCollisionStay
				Contador = 0;
			}
		}
	}

	public void SaltarPisos()
	{
		Physics.IgnoreLayerCollision(8,9);
	}

	public void NoSaltarPisos()
	{
		Physics.IgnoreLayerCollision(8,9, false);
	}
}