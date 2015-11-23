using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using System.Collections.Generic;

public class BroadCastSystem : MonoBehaviour {

	// NOME DOS EVENTOS DEVEM SER INICIALIZADOS AQUI PARA TODOS SABEREM QUAIS EVENTOS FAZEM O QUE

	public static string PLANETA_GIROU  = "planeta_girou";   //trigado quando o planeta girar
	public static string RECURSOS_ATUALIZARAM = "atualizar_recursos";


	private Dictionary < string , UnityEvent> eventDictionary ;
	private static BroadCastSystem broadcast ;

	public static BroadCastSystem instance {

		get {
			if (!broadcast){
				broadcast = FindObjectOfType (typeof (BroadCastSystem)) as BroadCastSystem;
				if (!broadcast)
					Debug.LogError ("Nao tem broadcastSystem na cena");
				else 
					broadcast.Init();
			}
			return broadcast ;
		}
	}

	void Init () {
		if (eventDictionary == null)
			eventDictionary = new Dictionary<string , UnityEvent> ();
	}

	public static void  StartListening (string name ,UnityAction listener){
		UnityEvent thisEvent = null;
		if (instance.eventDictionary.TryGetValue (name, out thisEvent)) {
			thisEvent.AddListener (listener);
		} else {
			thisEvent = new UnityEvent ();
			thisEvent.AddListener (listener);
			instance.eventDictionary.Add (name , thisEvent );
		}
	}
	
	public static void StopListening (string name , UnityAction listener) {
		if (broadcast == null)
			return;
		UnityEvent thisEvent = null;
		
		if (instance.eventDictionary.TryGetValue (name, out thisEvent)) {
			thisEvent.RemoveListener(listener);
		}
		
	}
	
	public static void  TriggerEvent (string eventName) {
		UnityEvent thisEvent = null ;
		
		if (instance.eventDictionary.TryGetValue (eventName, out thisEvent)) {
			thisEvent.Invoke();
		}
	}
	
}