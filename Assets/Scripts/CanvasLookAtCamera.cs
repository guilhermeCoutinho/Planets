using UnityEngine;
using System.Collections;

public class CanvasLookAtCamera : MonoBehaviour {

    GameObject planet;
	public GameObject edificio ;


    void Start() {
        Debug.Log("rodei ");
        planet = GameObject.FindGameObjectWithTag("Planet");
        Debug.Log(planet.transform.position);

        lookAtCamera();
    }


	void OnEnable () {

		BroadCastSystem.StartListening (BroadCastSystem.PLANETA_GIROU, lookAtCamera);
	}

	void OnDisable () {
		BroadCastSystem.StopListening (BroadCastSystem.PLANETA_GIROU, lookAtCamera);
	}

	void lookAtCamera () {
		this.transform.LookAt (Camera.main.transform ,
		                       edificio.transform.position - planet.transform.position);
	}
}
