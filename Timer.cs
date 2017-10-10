using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System;

public class Timer : NetworkBehaviour { 

    [SyncVar]
    public float Tim;
   
    [HideInInspector] public string StringTimer;


	void Start () {
       
	}


 

    
	void Update () {
        Tim -= Time.deltaTime;
        if(Tim<0)
        {
            Application.Quit();
        }
        TimeSpan ts = TimeSpan.FromSeconds(Tim);
      
        StringTimer = new DateTime(ts.Ticks).ToString("mm:ss");
       
	}
}
