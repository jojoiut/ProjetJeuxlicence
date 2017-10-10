using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
public class BarreDeVie : NetworkBehaviour
{
   
    
    public Image healthbar;
    public hpPlayer scriptHP;
    

    void Start()
    {
        healthbar = GetComponent<Image>();//recuperer l'ui barre de vie 
        scriptHP = GetComponentInParent<hpPlayer>();
    }


    // Actualise les points de vie pour rester entre 0 et hpmax
    public void UpdateHealth()
    {
        Debug.Log("MAJ");
        scriptHP.hp = Mathf.Clamp(scriptHP.hp, 0, scriptHP.hpMaxPlayer);//mathf.clamp sert a metre des limite a la variable Clamp(vriable,min, max)
        float amount = (float)scriptHP.hp / scriptHP.hpMaxPlayer;// recupere le % de nombre de vie
        Debug.Log("Avant : " + healthbar.fillAmount);
        healthbar.fillAmount = amount;// l'aplique a la barre de vie
        Debug.Log("Après : " + healthbar.fillAmount);
        if (healthbar.fillAmount < 0.5) {// regarde ma barre de vie 
            healthbar.color = Color.red;//la change de couleur
       }else
            healthbar.color = Color.green;

    }
    
}


    


	

