using UnityEngine;
using System.Collections;

public class ControlDisparo : MonoBehaviour {

	// Eliminamos el objeto si se sale de la pantalla
	void Update () {
		if (transform.position.y>100)
		{
			Destroy(gameObject);
		}	
	}
}
