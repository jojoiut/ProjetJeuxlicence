using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objet : MonoBehaviour {

	public Effet[] effets;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//active les effets d'un objet. 
	// prend en paramètre un tableau d'effet
	public void ActiverEffets(Effet[] effets){
		foreach(Effet e in effets){

		}
	}
	 public void addEffets(Effet[] effets){
		foreach (Effet e in effets) {
			addEffet (e);
		}
	}

	public void addEffet(Effet e){
		this.effets[effets.Length +1]= e;
	}

}
