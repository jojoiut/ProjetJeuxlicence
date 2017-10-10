using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Specialisation : MonoBehaviour {

	public string name; // nom de la classe
	public int vieMax; // vie max de la classe
	public int vitATQMax; // vitesse d'attaque de la classe
	public Competence[] competences;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	/* public void addCompetence(CoolDown c){
		this.competences [competences.Length + 1] = c;
	}*/

	 public void addCompetence(Competence c){
		this.competences [competences.Length + 1] = c;
	}

	public Competence[] getCompetences(){
		return this.competences;
	}
	public Competence getCompetence(int indexCompetence){
		return this.competences[indexCompetence-1];
	}
}
