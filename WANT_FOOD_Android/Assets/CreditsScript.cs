using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsScript : MonoBehaviour {
    public Texture2D icon;

    void Start () {
		
	}

    void OnGUI()
    {
        if (GUI.Button(new Rect(Screen.width * .1f, Screen.height * .6f, Screen.width * .8f, Screen.height * .3f), icon, GUIStyle.none))
        {
            Application.LoadLevel("starter");
        }

    }
}
