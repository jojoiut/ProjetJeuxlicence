using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;

[System.Serializable]
public class CPlayer_Camera : NetworkBehaviour {

	/* Caméra à la première personne, elle doit venir
	 * d'un objet fille*/
	[SerializeField]
	public Camera cameraPremierePersonne;
	/* Caméra à la troisièe personne, elle doit venir
	 * d'un objet fille*/
	[SerializeField]
	public Camera cameraTroisiemePersonne;

	/* Le nom de l'axe qui permet de changer de vue.
	 * Dans Edit/Project Setting/Input, vous pouvez
	 * créer/modifier un axe pour lui assigner un bouton.
	 * Cet axe qui contient ce bouton à un nom, 
	 * mettez ce nom ici.*/
	[SerializeField]
	public string NomAxeBouton = "Changer Vue";

	//Sensibilité de la pression de la touche
	[SerializeField]
	public float sensibilite = 0.1f;

	//Liste des caméras enfants
	private List<Camera> cameraInChildren;
	/*La caméra en cours
	 * -2 pour la première personne
	 * -1 pour la troisième personne*/
	private int m_iWhatCameraIs;
	//Nombre de caméra dans la liste (Sans compter les caméras principales)
	private int m_iNbCameras;

	/*Gestion touche*/
	//Temps à 0
	private float tStart;
	//Valeur à aller
	private float tGo;
	//Peut-on presser le bouton ?
	private bool canPress;

	// Use this for initialization
	void Start () {
		m_iWhatCameraIs = -2; //Caméra par défaut
        //Gestion des caméras enfants
        cameraInChildren = new List<Camera>();
        cameraInChildren.InsertRange(cameraInChildren.Count,GetComponentsInChildren<Camera>());
        SeparerLesCameras();
		m_iNbCameras = cameraInChildren.Count;
		ActiveCamera (cameraPremierePersonne);
        //gestion du temps
		tStart = 0;
		tGo = sensibilite;
		canPress = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (!isLocalPlayer)
			return;

		if (Input.GetAxis (NomAxeBouton) > 0 && canPress) {
			canPress = false;
			m_iWhatCameraIs += 1;
			if (m_iWhatCameraIs > m_iNbCameras-1 || (m_iNbCameras == 0 && m_iWhatCameraIs == 0)) //Si la caméra n'éxiste pas
				m_iWhatCameraIs = -2; //On revient au début
			switch (m_iWhatCameraIs) {
			case -2:
				ActiveCamera (cameraPremierePersonne);
				break;
			case -1: 
				ActiveCamera (cameraTroisiemePersonne);
				break;
			default:
				ActiveCamera (cameraInChildren[m_iWhatCameraIs]);
				break;
			}
			
		}

		if (!canPress) {
			tStart += Time.deltaTime;
			if (tStart >= tGo) {
				canPress = true;
				tStart = 0;
			}
		}
		
	}

	/*ActiveCamera
	 * arg : Caméra -> La caméra à activer
	 * Active une caméra et désactive les autres. */
	void ActiveCamera(Camera cam)
	{
		//Si il n'y a pas de caméras "extra"
		if (m_iNbCameras == 0) {
			if (cam.name == cameraPremierePersonne.name) {
				cam.enabled = true;
				cameraTroisiemePersonne.enabled = false;
			} else {
				cam.enabled = true;
				cameraPremierePersonne.enabled = false;
			}
		} else { //Si il y a plus de 2 caméras
			if (cam.name == cameraPremierePersonne.name) {
				cam.enabled = true;
				cameraTroisiemePersonne.enabled = false;
				DisableAllCameraList ();
			} else if (cam.name == cameraTroisiemePersonne.name) {
				cam.enabled = true;
				cameraPremierePersonne.enabled = false;
				DisableAllCameraList ();
			} else {
				DisableAllCameraList ();
				cameraPremierePersonne.enabled = false;
				cameraTroisiemePersonne.enabled = false;
				cam.enabled = true;
			}
		}
	}

	/*DisableAllCameraList
	 * Désactive toute les caméras qui ne sont pas les caméras principales*/
	void DisableAllCameraList()
	{
		for (int i = 0; i < m_iNbCameras; ++i) {
            cameraInChildren[i].enabled = false;
		}
	}

    void SeparerLesCameras()
    {
        if (cameraInChildren.Count == 2)
        {
            cameraInChildren = new List<Camera>();
            return;
        }
        bool okay = true;
        okay = cameraInChildren.Remove(cameraPremierePersonne);
        if (!okay)
        {
            Debug.LogError("La caméra première personne n'est pas enfant du galeObject !");
            AppHelper.Quit();
            return;
        }
        okay = cameraInChildren.Remove(cameraTroisiemePersonne);
        if (!okay)
        {
            Debug.LogError("La caméra troisième personne n'est pas enfant du galeObject !");
            AppHelper.Quit();
            return;
        }
    }

	/*Retourner des informations*/
	/*getCameraEnCours
	* retourne la caméra en cours du'tilisation
	* return : Camera*/
	public Camera getCameraEnCours(){
		switch (m_iWhatCameraIs) {
		case -2:
			return cameraPremierePersonne;
			break;
		case -1: 
			return cameraTroisiemePersonne;
			break;
		default:
			return cameraInChildren[m_iWhatCameraIs];
			break;
		}
	}


	//AppHelper
	//Une fonction d'aide, en utilisant AppHelper.Quit(), permet de quitter l'application proprement.
	public static class AppHelper
	{
		#if UNITY_WEBPLAYER
		public static string webplayerQuitURL = "http://google.com";
		#endif
		public static void Quit()
		{
			#if UNITY_EDITOR
			UnityEditor.EditorApplication.isPlaying = false;
			#elif UNITY_WEBPLAYER
			Application.OpenURL(webplayerQuitURL);
			#else
			Application.Quit();
			#endif
		}
	}



}


