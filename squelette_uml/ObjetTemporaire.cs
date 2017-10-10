using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetTemporaire : Objet {

	public float delaiDeReaparition; // apparait toutes les delaiDeReaparition secondes
	private float tempsEcoule; // temps (quand l'objet n'est pas visible) qui s'écoule

	 public ObjetTemporaire(float delaiReaparition, Effet[] effets){
		this.delaiDeReaparition = delaiReaparition;
		addEffets (effets);
	}
	// Use this for initialization
	void Start () {
		initialiserTempsEcoule ();
	}
	
	// Update is called once per frame
	void Update () {
		if (tempsEcoule == 0) {
			//apparait
			initialiserTempsEcoule ();
		} else {
		
		}
			//decrémente
	}
	
	//lorsque l'objet est en contact avec quelque chose
	void OnCollisionEnter(Collision collision){

	}

	void initialiserTempsEcoule(){
		this.tempsEcoule = delaiDeReaparition;
	}


}
