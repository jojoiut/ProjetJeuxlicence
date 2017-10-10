using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System;

public class CoolDown : NetworkBehaviour
{

    [System.Serializable]
    public class SCCompetence
    {
        public RawImage imageDuSort;
        public float CoulDown;
        public Text txtDuTimer;
        public string axeDuSort;
        //A Initialiser
        private float actualCooldown;
        private string stringTimer;
        private bool ready;

        public float cooldown
        {
            get
            {
                return actualCooldown;
            }
            set
            {
                actualCooldown = value;
            }
        }

        public string strTimer
        {
            get { return stringTimer; }
            set { stringTimer = value; }
        }

        public bool isReady
        {
            get { return ready; }
            set { ready = value; }
        }
    }

    public SCCompetence[] competences;

    private uint m_iIndex;

    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < 0; ++i)
        {
            competences[i].isReady = true;
            competences[i].txtDuTimer.enabled = false;
            competences[i].cooldown = competences[i].CoulDown;
        }
        m_iIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        for (m_iIndex = 0; m_iIndex < 3; ++m_iIndex)
        {
            if (Input.GetButtonDown(competences[m_iIndex].axeDuSort) && competences[m_iIndex].isReady)
            {
                competences[m_iIndex].isReady = false;
            }
            SortCD();
        }
    }

    void SortCD()
    {
        if (!competences[m_iIndex].isReady)
        {
            competences[m_iIndex].cooldown -= Time.deltaTime;
            TimeSpan ts = TimeSpan.FromSeconds(competences[m_iIndex].cooldown);
            competences[m_iIndex].txtDuTimer.enabled = true;
            competences[m_iIndex].txtDuTimer.text = competences[m_iIndex].strTimer;
            competences[m_iIndex].imageDuSort.color = Color.black;

            if (competences[m_iIndex].cooldown <= 0)
            {
                competences[m_iIndex].txtDuTimer.enabled = false;
                competences[m_iIndex].cooldown = competences[m_iIndex].CoulDown;
                competences[m_iIndex].imageDuSort.color = Color.white;
                competences[m_iIndex].isReady = true;
            }
            else
                competences[m_iIndex].strTimer = new DateTime(ts.Ticks).ToString("ss");
        }
    }

    public void reinAll()
    {
        foreach(SCCompetence comp in competences)
        {
            comp.txtDuTimer.enabled = false;
            comp.cooldown = comp.CoulDown;
            comp.imageDuSort.color = Color.white;
            comp.isReady = true;
        }
    }

}

