using UnityEngine;
using System.Collections;

public class START : MonoBehaviour {
    public Texture2D buttonPlay;
    public Texture2D buttonCredits;

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

			if (GUI.Button(new Rect(Screen.width*.5f, Screen.height*.8f, Screen.width*.1f, Screen.height*.1f), buttonCredits, GUIStyle.none))
			{
					Application.LoadLevel("credits");
			}

	}

}
