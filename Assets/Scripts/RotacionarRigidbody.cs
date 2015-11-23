using UnityEngine;
using System.Collections;

public class RotacionarRigidbody : MonoBehaviour {
	public int speed; // Velocidade com que o corpo ira girar
	private float rotationX;
	private float rotationY;
	private Transform referenceCamera; // Camera de referencia para o corpo girar

	public static bool podeGirar = true;

	// Use this for initialization
	void Start () {
		// Checa se há uma camera de referência
		if (!referenceCamera) {
			// Checa se há alguma camera
			if (!Camera.main) {
				Destroy (this);
				return;
			}
			// Usa a camera principal como referencia
			referenceCamera = Camera.main.transform;
		}
	}



	// Update is called once per frame
	void Update () {
		// Se o botao esquerdo for apertado
		if (Input.GetMouseButton (0) && podeGirar) {
			// Recebe o movimento do mouse
			rotationX = Input.GetAxis("Mouse X") * speed;
			rotationY = Input.GetAxis("Mouse Y") * speed;
			// Aplica forca no corpo, fazendo-o girar
			GetComponent<Rigidbody> ().AddTorque (-referenceCamera.up * rotationX);
			GetComponent<Rigidbody> ().AddTorque (referenceCamera.right * rotationY);
			// manda mensagem de que planeta girou para metodos cadastrados para recebe-las
			BroadCastSystem.TriggerEvent (BroadCastSystem.PLANETA_GIROU);
		}
	}
}