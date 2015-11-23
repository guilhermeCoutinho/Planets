using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ResourceGenerator : TouchMe {

	public PlanetStats.recursos RecursoGerado ;

	public GameObject recolherRecursosCanvas ;
	public int capacidadeMaxima ; // o quanto esse edificio 'segura' de recursos antes de parar de produzir e esperar ser recolhido 
 	public int energiaNescessaria ; // quanto precisa para funcionar na producao maxima
	public int capacidadeUtilizada ; // o quanto este edificio esta 'segurando' de recursos atualmente
	public int geracaoPorTick ; // quanto recurso gerar por tick de recursos, o intervalo do tick eh setado manualmente na classe 'PlanetStats'
	
	void Start () {
		PlanetStats.energiaUsada += energiaNescessaria;
		StartCoroutine (generate ()); 
	}

//	public override void OnTouch ()
//	{
//		base.OnTouch ();
//		RecolheRecursos ();
//	}

	IEnumerator generate () {
		while (capacidadeUtilizada < capacidadeMaxima){
			capacidadeUtilizada += geracaoPorTick;
			if (capacidadeUtilizada >= capacidadeMaxima){
				capacidadeUtilizada = capacidadeMaxima;
				break;
			}
			if (PlanetStats.energiaUsada <= PlanetStats.energiaMaxima)
				yield return new WaitForSeconds (PlanetStats.resorceTick);
			else 
				yield return new WaitForSeconds (PlanetStats.resorceTick*2f);
		}
		recolherRecursosCanvas.SetActive (true);

	}

	public void RecolheRecursos () {
		if (capacidadeUtilizada == capacidadeMaxima) {
			PlanetStats.incrementaRecursos (RecursoGerado, capacidadeUtilizada);
			BroadCastSystem.TriggerEvent (BroadCastSystem.RECURSOS_ATUALIZARAM);
			capacidadeUtilizada = 0;
			recolherRecursosCanvas.SetActive (false);
			StartCoroutine (generate () );
		}

	}

}
