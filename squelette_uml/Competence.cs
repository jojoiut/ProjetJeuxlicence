using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Competence : MonoBehaviour {
	public float tempsRecharge;
	public string name;
	public Text description;
	public float tempsRestantRecharge;
	private bool activable;
	private Effet[] effets;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	//active les effets d'une compétence. 
	// prend en paramètre un tableau d'effet
	 public void ActiverEffets(Effet[] effets){
		foreach(Effet e in effets){
			
		}
	}
	public	void addEffets(Effet[] effets){
		foreach (Effet e in effets) {
			addEffet (e);
		}
	}

	public void addEffet(Effet e){
			this.effets[effets.Length +1]= e;
	}

	public Competence(string nom,float tempsR, Text desc, Effet[] effets){
		this.name = nom;
		this.tempsRecharge = tempsR;
		this.description = desc;
		addEffets(effets);
	}
	public Effet[] getEffets(){
		return this.effets;
	}
}
