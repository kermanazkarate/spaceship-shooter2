using UnityEngine;
using System.Collections;

public class ControlAsteroide : MonoBehaviour
{
	public GameObject marcador;

	// Acceso animación Explosion2, cuando explota un asteroide
	public Rigidbody2D explosionAsteroide;

	//public flota escalaExplosion;

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
				
				// La mina desaparece
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

		//El Renderer hay que dejarlo porque la animación de la explosión salta de la imagen de los asteroides
		//Si no se forma la imagen de los asteroides, no salta luego la animación de la explosión de los asteroides

		GetComponent<Renderer>().enabled = false;
		GetComponent<Collider2D>().enabled = false;

		// Clonar el objeto Explosion2
		Rigidbody2D exp = (Rigidbody2D)Instantiate (explosionAsteroide, transform.position, transform.rotation);

		// obtengo la escala a la que esta el asteroide
		//escalaExplosion = GetComponent<Renderer>().local

		//Pongo la explosion2 a la misma escala a la que esta el asteroide
		//exp.transform.localScale = new Vector3 (escala, escala, escala);

		//Genero la animacion de la explosion del asteroide
		//GetComponent<Animator>().enabled = true;
		//GetComponent<Animator>().locals

		//Quito la gravedad de los asteroides para que aparezca la animación de la explosión quieta cuando le pega un disparo
		GetComponent<Rigidbody2D> ().gravityScale = 0;


		
	

	}

}
