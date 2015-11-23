using UnityEngine;
using System.Collections;

public class TouchRaycast : MonoBehaviour {
	
	void Update() {
		if ( Input.GetMouseButtonDown (0)){ 
			RaycastHit hit; 
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); 
			if ( Physics.Raycast (ray,out hit,200.0f)) {
				TouchMe [] touchInteractions = 
					hit.collider.gameObject.GetComponents<TouchMe>();
				foreach (TouchMe touchesInteraction in touchInteractions ){
					touchesInteraction.OnTouch();
				}
			}
		}
	}
}
