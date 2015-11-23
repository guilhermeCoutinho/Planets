using UnityEngine;
using System.Collections;

public class Build : MonoBehaviour {

    public GameObject planeta;

    public GameObject madereira, pedreira, usina;

	public void placeBuilding () {

        float raio = planeta.GetComponent<SphereCollider>().bounds.size.x/2;
        
        Vector3 cameraD = Camera.main.transform.position;
        Vector3 initialBuildPosition = raio * cameraD / cameraD.magnitude;
        Debug.Log("raio: " + raio);
        GameObject newMadereira =  (GameObject) Instantiate(madereira, initialBuildPosition, planeta.transform.rotation ) ;
        Vector3 prevsScale = newMadereira.transform.localScale;
        


        newMadereira.transform.SetParent(planeta.transform);
        Vector3 bodyUp = newMadereira.transform.up;
        newMadereira.transform.rotation = Quaternion.FromToRotation(bodyUp, cameraD.normalized) * newMadereira.transform.rotation;


//        newMadereira.transform.LookAt(Camera.main.transform, newMadereira.transform.up);
        newMadereira.transform.localScale = madereira.transform.localScale;
    }

}
