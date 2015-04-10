using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ControlMarcador : MonoBehaviour
{
	// Puntos ganados en la partida
	public int puntos = 0;

	// Vidas
	public int vidas = 5;

	// Referencia para el resto de objetos
	public GameObject marcador;

	// Actualizar el marcador
	void Update ()
	{
		// Localizamos el componente del UI
		Text t = marcador.GetComponent<Text> ();
		t.text = puntos.ToString ();
	}
}
