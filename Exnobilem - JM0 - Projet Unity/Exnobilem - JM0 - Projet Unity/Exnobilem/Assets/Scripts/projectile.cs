﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class projectile : NetworkBehaviour
{
    public int domageHit=20;
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag=="Player")
        {
            collision.gameObject.GetComponent<MeshRenderer>().material.color = Color.green; // change la couleur du personnage touché
            collision.gameObject.GetComponent<hpPlayer>().TakeDamage(domageHit);
            Destroy(gameObject); // détruit le projectile
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
