using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetDestructible : Objet {


	public ObjetDestructible(Effet[] effets){
		addEffets (effets);
	}
	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {

	}
	//lorsque l'objet est en contact avec quelque chose
	void OnCollisionEnter(Collision collision){

	}

}
