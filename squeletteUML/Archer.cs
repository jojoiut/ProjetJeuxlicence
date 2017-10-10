using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer : Specialisation {

	// Use this for initialization
	void Start () {
		name = "Archer";
		vieMax = 30;
		vitATQMax = 15;
		addCompetence (new Competence(nom, tempsR, desc,effets)); // A COMPLETER
		addCompetence (new Competence(nom, tempsR, desc,effets));
		addCompetence (new Competence(nom, tempsR, desc,effets));
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
