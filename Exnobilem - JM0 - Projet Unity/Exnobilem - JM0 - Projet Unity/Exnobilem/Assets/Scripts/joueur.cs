using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class joueur : NetworkBehaviour {
	public GameObject projectile;
	public float tempsRecharge;
    public float vitesseDeplacement;
    public float puissanceTir;
	private bool activable;
	public Camera cam;
    public Transform spawn;
    public GameObject sight;
    public float puissanceSaut;
    [Range(1.0f, 10.0f)] public float SensibilityX;
    private bool m_cursorIsLocked = true;
    private bool peutSauter = false;
    private float distanceDuSol;
    private Rigidbody rgbd;
    private hpPlayer vieJoueur;
    public CoolDown cooldown;
    [HideInInspector] public bool enVie;


    // Use this for initialization
    void Start () {
		activable = true;
        sight.SetActive(false);
        distanceDuSol = GetComponent<Collider>().bounds.extents.y;
        rgbd = GetComponent<Rigidbody>();
        vieJoueur = GetComponent<hpPlayer>();
        enVie = true;
        if (!isLocalPlayer)
        {
            Image[] im = GetComponentsInChildren<Image>();
            foreach (Image ima in im)
            {
                ima.gameObject.SetActive(false);
            }
        }
    }

	void setActivable(bool b){
		activable = b;
	}

    [Command]
    void CmdFire()
    {
        // This [Command] code is run on the server!
        
        // create the bullet object locally
        GameObject proj = Instantiate(projectile, spawn.transform.position, transform.rotation);

        proj.GetComponent<Rigidbody>().velocity = transform.forward * puissanceTir; // Use the ray direction going from camera through a screen point.

        // spawn the bullet on the clients
        NetworkServer.Spawn(proj);

        // when the bullet is destroyed on the server it will automaticaly be destroyed on clients
        Destroy(proj, 2.0f);
    }

    // Update is called once per frame
    void Update () {
		if (!isLocalPlayer) {
			cam.enabled = false;
			return;
		}

        if (enVie==true)
        {
            var x = Input.GetAxis("Horizontal") * 0.1f * vitesseDeplacement;
            var z = Input.GetAxis("Vertical") * 0.1f * vitesseDeplacement;
            transform.Translate(x, 0, z);

            //bouton gauche de la souris
            if (Input.GetButtonDown("Fire1"))
            {
                //cherche si un projectile est déjà projeté
                if (activable)
                {
                    //aucun projectile en cours : on lance le nouveau projectile
                    CmdFire();  //créer et gérer par le serveur
                    setActivable(false);
                    Invoke("activer", tempsRecharge);
                }
            }
            if (Input.GetKey(KeyCode.Space))
            {
                peutSauter = true;
            }

            if (Input.GetKeyUp(KeyCode.Escape))
            {
                m_cursorIsLocked = false;
            }
            else if (Input.GetMouseButtonUp(0))
            {
                m_cursorIsLocked = true;
            }

            if (m_cursorIsLocked)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                sight.SetActive(true);
            }
            else if (!m_cursorIsLocked)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                sight.SetActive(false);
            }

            float mouseX = Input.GetAxis("Mouse X") * SensibilityX;
            transform.Rotate(0, mouseX, 0);
        }
    }

    private void FixedUpdate()
    {
        if(peutSauter==true)
        {
            if(IsGrounded()==true)
            {
                rgbd.AddForce(0, puissanceSaut,0);
            }
            peutSauter = false;
        }
    }

    void activer()
    {
        activable = true;
    }

    bool IsGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, distanceDuSol + 0.1f);
    }

    public void revive()
    {
        vieJoueur.fullHeal();
        cooldown.reinAll();
        enVie = true;
    }
}
