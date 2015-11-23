using UnityEngine;
using System.Collections;

public class TouchFocus : TouchMe {
	public Transform cameraTarget ;
	private Vector3 prevsCameraPosition;
	private Camera myCam ;
	private Vector3 newCamPosition ;


	void Start () {
		myCam = Camera.main;

	}

	public override void OnTouch () {
		newCamPosition = cameraTarget.position;
		prevsCameraPosition = myCam.transform.position;
		StartCoroutine(changeCameras ());
	}

	IEnumerator changeCameras () {
		while (Vector3.Distance (myCam.transform.position,newCamPosition) > 0.01) {
			myCam.transform.position = Vector3.Slerp (myCam.transform.position,newCamPosition,Time.deltaTime * 3 );
			myCam.transform.LookAt(this.transform , transform.position);
			yield return null;
		}
		Debug.Log ("sai do while ");
	}


/*
	public override void OnTouch ()
	{
		Vector3 diferencaDoEdificio ;

		diferencaDoEdificio = this.transform.position - planet.transform.position;

		diferencaDoEdificio = this.transform.position - planet.transform.position;
		Vector3 diferencaDaCamera   = Camera.main.transform.position - planet.transform.position;
		
		float angleY = Vector2.Angle ( new Vector2 (diferencaDaCamera.x , diferencaDaCamera.z ) ,
		                              new Vector2 (diferencaDoEdificio.x , diferencaDoEdificio.z) );
		
		if (diferencaDaCamera.x > diferencaDoEdificio.x)
			angleY = - angleY;
		
		planet.transform.Rotate (0f, angleY, 0f, Space.World);
		
		diferencaDoEdificio = this.transform.position - planet.transform.position;
		diferencaDaCamera   = Camera.main.transform.position - planet.transform.position;
		float angleX = Vector2.Angle (new Vector2 (diferencaDaCamera.y , diferencaDaCamera.z) ,
		                              new Vector2 (diferencaDoEdificio.y , diferencaDoEdificio.z ));
		if (diferencaDaCamera.y < diferencaDoEdificio.y)
			angleX = -angleX;
		
		planet.transform.Rotate (angleX + perspectiveAngle, 0f, 0f, Space.World);

	}
*/
}
