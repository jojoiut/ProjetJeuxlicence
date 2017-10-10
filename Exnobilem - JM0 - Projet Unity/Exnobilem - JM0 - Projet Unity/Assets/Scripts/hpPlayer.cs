using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public class hpPlayer : NetworkBehaviour
{
    [HideInInspector]
    public BarreDeVie scriptBDV;
    public int hpMaxPlayer=100;
    private SpawnManager spawnManager;
    private joueur j;
    [SyncVar]
    //[HideInInspector]
    public int hp = 100;
    public float tempsAvantRez = 10;
	// Use this for initialization
	void Start () {
        hp = hpMaxPlayer;
        j = GetComponent<joueur>();
        spawnManager = FindObjectOfType<SpawnManager>();
        scriptBDV = GetComponentInChildren<BarreDeVie>();
    }
	
	// Update is called once per frame
	void Update () {
        testeDamageHeal();//methode de teste pour voire si sa marche
    }

    // Inflige des dégâts
    public void TakeDamage(int damages)//quand le personnage prend dégat
    {
        Debug.Log("AIE ! Jai pris des dommages lol");
        hp-= damages;
        if (hp <= 0)
        {
            // called on the Server, but invoked on the Clients
            j.enVie = false;
            Invoke("rez", tempsAvantRez);
        }
        scriptBDV.UpdateHealth();
    }
    // Soigne le joueur
    public void Heal(int heal)//quand le joueur reçoit un heal
    {
        hp += heal;
        scriptBDV.UpdateHealth();
    }



    public void testeDamageHeal()
    {
        if (Input.GetKeyDown(KeyCode.A)) // regarder dans les input si il y a sort3 sinon ca va pas marché
        {
            TakeDamage(65);
        }
        if (Input.GetKeyDown(KeyCode.V))
            Heal(10);
    }

    public void fullHeal()
    {
        hp = hpMaxPlayer;
        scriptBDV.UpdateHealth();
    }

    void rez()
    {
        spawnManager.spawn(j);
    }
}
