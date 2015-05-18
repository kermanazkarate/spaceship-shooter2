﻿using UnityEngine;
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
		GetComponent<AudioSource> ().Play ();

		if (coll.gameObject.tag == "disparo") {
			// Sumar la puntuación de este asteroide
			marcador.GetComponent<ControlMarcador> ().puntos += puntos;

			// El disparo desaparece
			coll.gameObject.GetComponent<Renderer> ().enabled = false;
			coll.gameObject.GetComponent<Collider2D> ().enabled = false;
		} 
		else if (coll.gameObject.tag == "mina") 
		{
				// Sumar la puntuación de este asteroide
				marcador.GetComponent<ControlMarcador> ().puntos += puntos;
				
				// El disparo desaparece
				coll.gameObject.GetComponent<Renderer> ().enabled = false;
				coll.gameObject.GetComponent<Collider2D> ().enabled = false;
		} 
		else if (coll.gameObject.tag == "nave") 
		{
				// Hemos chocado con la nave, restamos una vida
				if (marcador.GetComponent<ControlMarcador> ().vidas > 0) {
					marcador.GetComponent<ControlMarcador> ().vidas -= 1;
				}

		}

		// El asteroide se destruye
		GetComponent<Renderer>().enabled = false;
		GetComponent<Collider2D>().enabled = false;

		//Genero la animacion de la explosion del asteroide
		//GetComponent<Animator>().enabled = true
	}

}
