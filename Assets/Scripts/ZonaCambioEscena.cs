using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ZonaCambioEscena : MonoBehaviour
{
	public string Escena;

	public void OnTriggerEnter (Collider col)
	{
		if (col.gameObject.layer == LayerMask.NameToLayer ("Personaje"))
		{
			SceneManager.LoadScene (Escena);
		}
	}
}