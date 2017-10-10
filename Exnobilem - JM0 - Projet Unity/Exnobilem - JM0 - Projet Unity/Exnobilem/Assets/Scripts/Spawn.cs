using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {

    private joueur j;
    public float tempsSpawnLock;
	// Use this for initialization
	void Start () {
        j = null;
	}
	
    public joueur getJoueur()
    {
        return j;
    }

    public void setJoueur(joueur player)
    {
        j = player;
        Invoke("unlock", tempsSpawnLock);
    }

    void unlock()
    {
        j = null;
    }
}
