using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.Networking;
public class AfficheTimer : NetworkBehaviour
{


    public Text TxtTimer;
    private  Timer timer;
    public string nomTimer;

    void Start()
    {
        timer = GameObject.Find(nomTimer).GetComponent<Timer>();
    }
	
	// Update is called once per frame
	void Update () {

        TxtTimer.text = timer.StringTimer;
    }
}
