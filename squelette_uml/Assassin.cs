using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assassin : Specialisation {
	

	// Use this for initialization
	void Start () {
		name = "Assassin";
		vieMax = 20;
		vitATQMax = 20;
		addCompetence (new Competence(nom, tempsR, desc,effets));
		addCompetence (new Competence(nom, tempsR, desc,effets));
		addCompetence (new Competence(nom, tempsR, desc,effets));

	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
