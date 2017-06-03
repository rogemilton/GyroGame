using UnityEngine;
using System.Collections;

public class loadScores : MonoBehaviour {
	private WWW website;
	
	private string tmpLeaderBoard = "";
	
	private string saveScoreURL = "";
	
	public static string outputURL = "http://dreamlo.com/lb/pkuI15_XZ0CnBlMKJ0YyuwE4_Q_Y_iAEuKyfKCwcolwg/quotes";
	public static bool submitted = false;

	IEnumerator Start()
	{
		//Debug.Log ("THIS WwwwwwwwORKS! " + outputURL);
		website = new WWW (outputURL);
		yield return website;
		GameOver.tmpLeaderBoard = website.text;
		Debug.Log (GameOver.tmpLeaderBoard);
		submitted = true;
	}

}
