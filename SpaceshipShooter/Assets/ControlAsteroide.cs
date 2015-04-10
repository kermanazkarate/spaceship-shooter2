using UnityEngine;
using System.Collections;

public class ControlAsteroide : MonoBehaviour {

	// Detectar la colisión entre el asteroide y el disparo
	void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.tag == "disparo")
		{
			// Los dos objetos se destruyen
			Destroy (coll.gameObject);
			Destroy(this.gameObject);
		}
	}

}
