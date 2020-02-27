using UnityEngine;
using System.Collections;

public class SaltoPersonaje01: MonoBehaviour
{
	// Para funcionar tiene que haber un Layer llamado "Piso", y evidentemente el piso tiene que tener este layer

	// Necesita el Script Gravedad01 para funcionar

	public float SaltosRestantes;
	public float FuerzaSalto;
	public float SaltosMultiples;

	// Variables de Sonido
	[Header("Variables de Sonido")]
	public GameObject contendedorSonidoSaltando;

	private void Start()
	{
		// Inicializacion de Sonidos en false, para que no suenen si nos los olvidamos habilitados
		contendedorSonidoSaltando.SetActive(false);
	}

	void Update()
	{
		Gravedad01 Grav = gameObject.GetComponentInChildren<Gravedad01> ();
		//BoxCollider Coll = gameObject.GetComponentInChildren<BoxCollider> ();// Sólo usar si en el código Gravedad01, en la función EnAire, dejamos la parte que anula el Trigger cuando el personaje está ascendiendo

		if (Input.GetKeyDown(KeyCode.Space) && SaltosRestantes > 0 && Grav.EnPiso)
		{
			//Debug.Log ("Salto");
			Grav.FuerzaVertical = FuerzaSalto;
			contendedorSonidoSaltando.SetActive(false); // Primero se deshabilita, ya que luego de que suene por primera vez hay que dejarlo habilitado para que termine el sonido
			contendedorSonidoSaltando.SetActive(true); // Habilitamos el contenedor para que suenen los sonidos que contiene
			Grav.EnAire();
			Animator anim = gameObject.GetComponentInChildren<Animator>();
			anim.SetBool("Jumping", true);
			SaltosRestantes--;
			//Coll.isTrigger = true;// Sólo usar si en el código Gravedad01, en la función EnAire, dejamos la parte que anula el Trigger cuando el personaje está ascendiendo
		}

		if (Grav.EnPiso)
		{
			Animator anim = gameObject.GetComponentInChildren<Animator>();
			anim.SetBool("Jumping", false);
			SaltosRestantes = SaltosMultiples;
		}
	}
}