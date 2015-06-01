using UnityEngine;
using System.Collections;

public class ControlNave : MonoBehaviour
{
	public float velocidadNave = 20f;
	public float velocidadDisparo = 10f;
	public float velocidadBomba = 900f;

	// Acceso al prefab Disparo
	public Rigidbody2D disparo;

	// Acceso al prefab Disparo
	public Rigidbody2D bomba;

	//Disparo de Bomba
	void disparo_bomba()
	{
		// Clonar el objeto
		Rigidbody2D b = (Rigidbody2D)Instantiate (bomba, transform.position, transform.rotation);

		//Genero la rotación de la bomba
		b.AddTorque (200f);

		// Desactivar la gravedad para este objeto, si no, ¡se cae!
		b.gravityScale = 0;

		// Posición de partida, en la punta de la nave
		b.transform.Translate (Vector2.up * 3f);

		// Lanzarlo
		b.AddForce (Vector2.up * velocidadBomba);	

	}


	// Hacemos copias del prefab del disparo y las lanzamos
	void Disparar ()
	{
		// Clonar el objeto
		Rigidbody2D d = (Rigidbody2D)Instantiate (disparo, transform.position, transform.rotation);
		//Añado 2 disparos mas
		Rigidbody2D dcha = (Rigidbody2D)Instantiate (disparo, transform.position, transform.rotation);
		Rigidbody2D dizq = (Rigidbody2D)Instantiate (disparo, transform.position, transform.rotation);

		// Desactivar la gravedad para este objeto, si no, ¡se cae!
		d.gravityScale = 0;
		dcha.gravityScale = 0;
		dizq.gravityScale = 0;


		// Posición de partida, en la punta de la nave
		d.transform.Translate (Vector2.up * 3f);
		dcha.transform.Translate (Vector2.right * 1f);
		dizq.transform.Translate (Vector2.right * -1f);

		// Lanzarlo
		d.AddForce (Vector2.up * velocidadDisparo);	
		dcha.AddForce (Vector2.up * velocidadDisparo);	
		dizq.AddForce (Vector2.up * velocidadDisparo);	
	}

	void Update ()
	{
		float topeIzq = ((Camera.main.orthographicSize * Screen.width / Screen.height) + 3) * -1 ;
		float topeDcha = (Camera.main.orthographicSize * Screen.width / Screen.height) + 3;

		// Izquierda
		if (Input.GetKey (KeyCode.LeftArrow)) {


			if ( transform.position.x <= topeIzq ) {

				transform.position = new Vector3( topeDcha, 0, 0);
			} else {
				transform.Translate (Vector3.left * velocidadNave * Time.deltaTime);

			}

		}

		// Derecha
		if (Input.GetKey (KeyCode.RightArrow)) {

			if ( transform.position.x >= topeDcha ) {

				transform.position = new Vector3( topeIzq, 0, 0);

			} else {

				transform.Translate (Vector3.right * velocidadNave * Time.deltaTime);

			}
		}

		// Disparo
		if (Input.GetKeyDown (KeyCode.Space)) {
			Disparar ();
		}

		// Disparo Bomba
		if (Input.GetKeyDown (KeyCode.B)) {
			disparo_bomba();
		}
	}

}
