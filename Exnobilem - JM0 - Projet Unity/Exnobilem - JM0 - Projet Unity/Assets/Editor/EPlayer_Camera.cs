using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(CPlayer_Camera))]
[CanEditMultipleObjects]
public class EPlayer_Camera : Editor {

	/*Liste des fields de la classe CPlayer_Camera*/
	SerializedProperty cameraPremierePersonne;
    SerializedProperty cameraTroisiemePersonne;
    SerializedProperty NomAxeBouton;
    SerializedProperty sensibilite;
	/*Style pour le texte*/
    GUIStyle title;
	/*Autres trucs*/
    bool hiddenChildCamera;
    bool infos;

	// Use this for initialization
	void OnEnable () {
		/*On recherche les "Champs" de chaque variables publiques,
		 * avec serializedObject.FindProperty(""), on met entre guilllemet
		 * le nom de la variable*/
		cameraPremierePersonne = serializedObject.FindProperty ("cameraPremierePersonne");
        cameraTroisiemePersonne = serializedObject.FindProperty("cameraTroisiemePersonne");
        NomAxeBouton = serializedObject.FindProperty("NomAxeBouton");
        sensibilite = serializedObject.FindProperty("sensibilite");
        hiddenChildCamera = false;
        initializeTitleFormText();
    }
	
	public override void OnInspectorGUI()
	{
		/*Petite maj*/
			/*Si on veut cacher ou afficher des choses, il faute faire de simple conditions.
			* infos = EditorGUILayout.ToggleLeft permet de creer une check box avec un texte à côté.
			* EditorGUILayout.HelpBox permet d'afficher du texte avec une icone Information/Erreur/Bon.
			* EditorGUILayout.LabelField permet d'afficher simplement du texte. En deuxième argument, vous pouvez mettre un Style.
			* EditorGUILayout.PropertyField permet d'afficher une propriété récupéré d'une SerializedPropriety
			* GUILayout.Space(n); permet de faire un espacement de n à la verticale.
			* Après y'a plein d'autre trucs sur la doc ;-)
			*/
		serializedObject.Update ();
        infos = EditorGUILayout.ToggleLeft("Informations sur le script ?", infos);
		if (infos) {
			EditorGUILayout.HelpBox ("Ce script permet de switcher entre plusieurs caméras.\nUne fois le joueur créer avec tout ce qu'il faut pour le network, rajoutez ce script.\nDans un premier temps, vous devez spécifier les deux caméras principales :\n-La Caméra Première personne\n-La Caméra troisième personne\nSi il existe d'autres caméras filles, elles seront prise automatiquement en charge par le script.\nVoilà, l'implémentation ne devrait pas être trop dure,\nGutes Glück !", MessageType.None);
			EditorGUILayout.HelpBox("Toujours mettre les caméras principales en fille du GameObject.", MessageType.Warning);
		}
        EditorGUILayout.LabelField ("Caméras principales", title);
        GUILayout.Space(10);
        if ((cameraPremierePersonne.objectReferenceValue as Camera) == null || (cameraTroisiemePersonne.objectReferenceValue as Camera) == null)
            EditorGUILayout.HelpBox("Toujours les spécifier !", MessageType.Warning);
        EditorGUILayout.PropertyField (cameraPremierePersonne);
        if ((cameraPremierePersonne.objectReferenceValue as Camera) == null)
		    EditorGUILayout.HelpBox ("Il s'agit de la caméra à la première personne, elle peut venir d'un objet fille ou non.", MessageType.Info);
        EditorGUILayout.PropertyField(cameraTroisiemePersonne);
        if ((cameraTroisiemePersonne.objectReferenceValue as Camera) == null)
            EditorGUILayout.HelpBox("Il s'agit de la caméra à la troisième personne, elle peut venir d'un objet fille ou non.", MessageType.Info);
        if ((cameraTroisiemePersonne.objectReferenceValue as Camera) == (cameraPremierePersonne.objectReferenceValue as Camera) && !((cameraPremierePersonne.objectReferenceValue as Camera) == null && (cameraTroisiemePersonne.objectReferenceValue as Camera) == null))
            EditorGUILayout.HelpBox("Les caméras sont identiques !", MessageType.Error);
        GUILayout.Space(20);
        EditorGUILayout.LabelField("Touche", title);
        GUILayout.Space(10);
        EditorGUILayout.PropertyField(NomAxeBouton);
        EditorGUILayout.HelpBox("Le nom de l'axe qui permet de changer de vue.\nDans Edit / Project Setting / Input, vous pouvez créer / modifier un axe pour lui assigner un bouton.\nCet axe qui contient ce bouton à un nom, mettez ce nom ici.", MessageType.Info);
        if (NomAxeBouton.stringValue == "")
            EditorGUILayout.HelpBox("Aucun axe est spécifié !", MessageType.Error);
        EditorGUILayout.PropertyField(sensibilite);
        EditorGUILayout.HelpBox("Sensibilité de la touche.", MessageType.Info);
        serializedObject.ApplyModifiedProperties ();
	}

    void initializeTitleFormText()
    {
        title = new GUIStyle();
        title.fontSize = 16;
        title.alignment = TextAnchor.MiddleCenter;
        title.fontStyle = FontStyle.BoldAndItalic;
        title.normal.textColor = new Color(255, 0, 0);
    }
}
		