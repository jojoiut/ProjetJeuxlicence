using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModifierVie : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void appliquerEffet (GameObject go){
		//instancier effet
	}
	void infligerDegats (Joueur j, int pointsVie){
		j.setVieJoueur(j.getVieJoueur() - pointsVie);
	}

	//inflige dégats en continu  dans le temps: ex: posion
	//@param tempsMax : le poison est effectif pendant tempsMax de temps
	//@param intervalDeDegatsEnSecondes : le poison inflige des dégats toutes les intervalDeDegatsEnSecondes secondes
	void infligerDegatsEnContinue (Joueur j, int pointsVie,float tempsMax, float intervalDeDegatsEnSecondes){
		
	}
		
	void augmenterVie(Joueur j, int pointsVie){
		j.setVieJoueur(j.getVieJoueur() + pointsVie);
	}




}
