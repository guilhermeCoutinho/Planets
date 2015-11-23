using UnityEngine;
using System.Collections;

/*
 * guilherme que fez, briguem com ele
 * Essa classe statica armazena valores do player, como resources
*/

public static class PlanetStats {

	// enum publico para referencias staticas dos recursos
	public enum recursos {
		MADEIRA, 
		COMBUSTIVEL ,
		FERRO ,
		PEDRA
	}

	public static float resorceTick = 1f ;  // intervalo entre cada incremento dos recursos;

	// recursos propriamente ditos
	public static int combustivel ;
	public static int madeira ;
	public static int ferro ;
	public static int pedra ;
	public static int cristal ;
	public static int dilmas ; // dinheiro hehe
	//energia
	public static int energiaMaxima ;
	public static int energiaUsada = 0;

	// incrementa algum recurso quando player 'recolher' ou quando ganhar de alguma outra forma
	public static void incrementaRecursos (recursos rIncrementar , int quantidade) {
		switch (rIncrementar){
		case recursos.COMBUSTIVEL:
			combustivel += quantidade;
			break;
		case recursos.FERRO:
			ferro += quantidade;
			break;
		case recursos.MADEIRA:
			madeira += quantidade;
			break;
		case recursos.PEDRA:
			pedra += quantidade;
			break;
		}
	}


}
