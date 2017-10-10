using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SpawnManager : NetworkBehaviour {

    public Spawn[] spawns;

    // Use this for initialization
    void Start () {
		spawns = FindObjectsOfType<Spawn>();
	}

  
	public void addSpawn(Spawn s){
		spawns [spawns.Length + 1] = s;
	}
}
