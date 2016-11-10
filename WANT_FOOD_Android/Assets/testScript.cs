using UnityEngine;
using System.Collections;

public class testScript : MonoBehaviour {
	private WWW website;
	
	private string tmpLeaderBoard = "";
	
	private string saveScoreURL = "";
	
	public static string outputURL = "";
	public static bool submitted = false;


	IEnumerator Start()
	{
		//Debug.Log ("THIS WORKS! " + outputURL);
		website = new WWW (outputURL);
		yield return website;
		tmpLeaderBoard = website.text;
		Debug.Log (tmpLeaderBoard);

		Camera.main.gameObject.GetComponent<loadScores> ().enabled = true;


		submitted = true;
	}

}
