using UnityEngine;
using System.Collections;

public class ControlAsteroide : MonoBehaviour
{
	public GameObject marcador;

	// Por defecto, 100 puntos
	public int puntos = 100;

	// Localizar y conectar el marcador para poder actualizarlo
	void Start ()
	{
		marcador = GameObject.Find ("Marcador");
	}

	// Detectar la colisión entre el asteroide y el disparo
	void OnCollisionEnter2D (Collision2D coll)
	{
		if (coll.gameObject.tag == "disparo") {
			// Sumar la puntuación de este asteroide
			marcador.GetComponent<ControlMarcador> ().puntos += puntos;

			// Los dos objetos se destruyen
			Destroy (coll.gameObject);
			Destroy (this.gameObject);
		}
	}

}
