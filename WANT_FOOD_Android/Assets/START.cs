﻿using UnityEngine;
using System.Collections;

public class START : MonoBehaviour {
    public Texture2D buttonPlay;
    public Texture2D buttonCredits;
    public Texture2D buttonSettings;
    public Texture2D buttonHowTo;
    public Texture2D buttonLeaderBoard;

    void Start()
	{

	}

	void OnGUI()
	{
	    GUI.skin.label.fontSize = GUI.skin.box.fontSize = GUI.skin.button.fontSize = GUI.skin.textField.fontSize = 70;

	    if(GUI.Button(new Rect(Screen.width*.35f, Screen.height*.4f, Screen.width*.4f, Screen.height*.4f), buttonPlay, GUIStyle.none))
	    {
		    Application.LoadLevel(1);
	    }

	    if (GUI.Button(new Rect(Screen.width*.45f, Screen.height*.7f, Screen.width*.1f, Screen.height*.1f), buttonLeaderBoard, GUIStyle.none))
	    {
		    //Application.LoadLevel("leaderboard");
	    }

        if (GUI.Button(new Rect(Screen.width * .15f, Screen.height * .85f, Screen.width * .1f, Screen.height * .1f), buttonHowTo, GUIStyle.none))
        {
            //Application.LoadLevel("howto");
        }

        if (GUI.Button(new Rect(Screen.width * .45f, Screen.height * .85f, Screen.width * .1f, Screen.height * .1f), buttonSettings, GUIStyle.none))
        {
            //Application.LoadLevel("settings");
        }

        if (GUI.Button(new Rect(Screen.width * .75f, Screen.height * .85f, Screen.width * .1f, Screen.height * .1f), buttonCredits, GUIStyle.none))
        {
            Application.LoadLevel("credits");
        }

    }

}
