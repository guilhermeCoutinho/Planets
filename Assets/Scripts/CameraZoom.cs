using UnityEngine;
using System.Collections;

public class CameraZoom : MonoBehaviour {

	// Essas variaveis se referem ao "Field of view"
	public float maxZoom = -1f; // Menor valor possível no "Field of view" (Mais perto)
	public float minZoom = -5f; // Maior valor possível no "Field of view" (Mais afastado)
	public float sensibilidade; // Velocidade com que a camera aproxima/afasta
	
	// Use this for initialization
	void Start () {
	
	}

	void Update()
	{
		// O Mathf.Clamp pega o valor atual do "fieldOfView" e checa se ele está dentro do limite minino ou máximo, retornando um valor dentro do intervalo

		Camera.main.fieldOfView = Mathf.Clamp ( Camera.main.fieldOfView - (Input.GetAxis ("Mouse ScrollWheel") *sensibilidade), minZoom, maxZoom	);

	}
}
