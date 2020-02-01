using UnityEngine;
using System.Collections;

public class SaltoPersonaje01: MonoBehaviour
{
	// Para funcionar tiene que haber un Layer llamado "Piso", y evidentemente el piso tiene que tener este layer

	// Necesita el Script Gravedad01 para funcionar

	public float SaltosRestantes;
	public float FuerzaSalto;
	public float SaltosMultiples;
	
	void FixedUpdate()
	{
		Gravedad01 Grav = gameObject.GetComponentInChildren<Gravedad01> ();
		//BoxCollider Coll = gameObject.GetComponentInChildren<BoxCollider> ();// Sólo usar si en el código Gravedad01, en la función EnAire, dejamos la parte que anula el Trigger cuando el personaje está ascendiendo

		if (Input.GetKeyDown(KeyCode.Space) && SaltosRestantes > 0 && Grav.EnPiso)
		{
			//Debug.Log ("Salto");
			Grav.FuerzaVertical = FuerzaSalto;
			Grav.EnAire();
			SaltosRestantes--;
			//Coll.isTrigger = true;// Sólo usar si en el código Gravedad01, en la función EnAire, dejamos la parte que anula el Trigger cuando el personaje está ascendiendo
		}

		if (Grav.EnPiso)
		{
			SaltosRestantes = SaltosMultiples;
		}
	}
}