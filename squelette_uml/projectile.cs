using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{
    public int domageHit=20;
    void OnTriggerEnter(Collider collision)
    {
        Debug.Log("Contact basique");
        if (collision.gameObject.GetComponent<Joueur>())
        {
            Debug.Log("Contact Joueur");
            collision.gameObject.GetComponent<MeshRenderer>().material.color = Color.green; // change la couleur du personnage touché
            collision.gameObject.GetComponent<HpPlayer>().TakeDamage(domageHit);
            Destroy(gameObject); // détruit le projectile
        }
        else
        {
            Destroy(gameObject);
        }


    }
}
