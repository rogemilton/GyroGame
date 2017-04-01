using UnityEngine;
using System.Collections;

public class START : MonoBehaviour {
    public Texture2D icon;
    public Texture2D icon2;

	void Start()
	{

	}

	void OnGUI()
	{
			GUI.skin.label.fontSize = GUI.skin.box.fontSize = GUI.skin.button.fontSize = GUI.skin.textField.fontSize = 70;

			/*
			if(GUI.Button(new Rect(Screen.width*.1f, Screen.height*.6f, Screen.width * .8f,Screen.height*.3f), "S T A R T"))
			{
					Application.LoadLevel(1);
			}
			*/
			if(GUI.Button(new Rect(Screen.width*.1f, Screen.height*.6f, Screen.width * .8f,Screen.height*.3f), icon, GUIStyle.none))
			{
					Application.LoadLevel(1);
			}

			if (GUI.Button(new Rect(Screen.width * .8f, Screen.height * .8f, Screen.width * .8f, Screen.height * .8f), icon2, GUIStyle.none))
			{
					Application.LoadLevel("credits");
			}

	}

}
