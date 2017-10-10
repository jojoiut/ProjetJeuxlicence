using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SpawnManager : NetworkBehaviour {

    public Spawn[] pointsSpawn;
    private joueur[] joueurs;

    // Use this for initialization
    void Start () {
        pointsSpawn = FindObjectsOfType<Spawn>();
        joueurs = FindObjectsOfType<joueur>();
        foreach(joueur j in joueurs)
        {
            spawn(j);
        }
	}

    public void spawn(joueur j)
    {
        int spawnRandom;
        joueur joueurDuSpawn;
        do
        {
            spawnRandom = Random.Range(0, pointsSpawn.Length);
            joueurDuSpawn = pointsSpawn[spawnRandom].getJoueur();
        } while (joueurDuSpawn != null);
        j.revive();
        pointsSpawn[spawnRandom].setJoueur(j);
        j.gameObject.transform.position=pointsSpawn[spawnRandom].transform.position;
        j.gameObject.transform.rotation = pointsSpawn[spawnRandom].transform.rotation;
    }
}
