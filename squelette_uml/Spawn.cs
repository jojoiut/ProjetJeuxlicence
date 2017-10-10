using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {

    public Joueur j;
    public float tempsSpawnLock; // temps d'attente avant de ressusciter
		
	// Use this for initialization
	void Start () {
        j = null;
	}

    void unLock()
    {
        j = null;
    }
}
