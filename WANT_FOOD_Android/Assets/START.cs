using UnityEngine;
using System.Collections;

public class START : MonoBehaviour {

	public static string nameObject = "food";

	void Start()
	{
		Screen.orientation = ScreenOrientation.LandscapeLeft;
	}
	

	void OnGUI()
	{
		GUI.skin.label.fontSize = GUI.skin.box.fontSize = GUI.skin.button.fontSize = 16;
		
		GUI.Box(new Rect(Screen.width* .1f, Screen.height* .1f,Screen.width* .8f, Screen.height* .3f),
		              "Grab " + nameObject + " before it hits the ground by tilting your phone");

		if(GUI.Button(new Rect(Screen.width* .1f, Screen.height* .4f,Screen.width* .8f, Screen.height* .3f), "Start!"))
		{
			Application.LoadLevel(1);
		}
	}
}
