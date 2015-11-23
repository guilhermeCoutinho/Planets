using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UI : MonoBehaviour {

	public Text madeira;
	public Text pedra ;
	public Text energia; 

	void OnEnable () {
		BroadCastSystem.StartListening (BroadCastSystem.RECURSOS_ATUALIZARAM, UpdateUI);
	}

	void OnDisable () {
		BroadCastSystem.StopListening (BroadCastSystem.RECURSOS_ATUALIZARAM, UpdateUI);
	}
	void Start () {
		UpdateUI ();
	}

	public void UpdateUI () {
		madeira.text = ""+ PlanetStats.madeira;
		pedra.text = ""+ PlanetStats.pedra;
		energia.text = "" + PlanetStats.energiaUsada + "/" + PlanetStats.energiaMaxima;
	}


}