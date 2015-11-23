using UnityEngine;
using System.Collections;

public class SerraAnimation : MonoBehaviour {


	void Start () {
		StartCoroutine (Animate ());
	}

	IEnumerator Animate () {
		while (true) {
			transform.Rotate (new Vector3 ( 0 , 15 , 0) );
			yield return new WaitForSeconds (0.1f);
		}
	}

}
