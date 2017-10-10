using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guerrier : Specialisation {

	// Use this for initialization
	void Start () {
		name = "Guerrier";
		vieMax = 30;
		vitATQMax = 10;
		addCompetence (new Competence(nom, tempsR, desc,effets));
		addCompetence (new Competence(nom, tempsR, desc,effets));
		addCompetence (new Competence(nom, tempsR, desc,effets));
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
