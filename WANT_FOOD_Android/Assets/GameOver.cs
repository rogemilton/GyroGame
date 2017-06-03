using UnityEngine;
using System.Collections;
using System.Net;
using System.Collections.Generic;

public class GameOver : MonoBehaviour
{
    private int scoreThreshold = -1;

    private bool showLeaderBoard = false;

    public static int roger = 0;

    private string getScoresURL = "http://dreamlo.com/lb/pkuI15_XZ0CnBlMKJ0YyuwE4_Q_Y_iAEuKyfKCwcolwg/quotes";
    private string allScores = "";

    private string loseGame = "";

    private string name = "enter your name here :)";

    private WWW website;

    public static string tmpLeaderBoard = "";

    private string saveScoreURL = "";

    public static string outputURL = "";
    public static bool submitEnable = false;

    public static string scoresCol1;
    public static string scoresCol2;

    void Start()
    {
        //GUY.score = 10; //this is only for testing

        website = new WWW(getScoresURL);

        while (!website.isDone)
        {
            //Debug.Log (website.bytesDownloaded);
        }
        tmpLeaderBoard = website.text;
    }

    void OnGUI()
    {
        GUI.skin.label.fontSize = GUI.skin.box.fontSize = GUI.skin.button.fontSize = GUI.skin.textField.fontSize = 40;

        if (!showLeaderBoard)
        {
            GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "Game Over! Final score is: " + GUY.score);

            name = GUI.TextField(new Rect(Screen.width * .1f, Screen.height * .2f, Screen.width * .8f, Screen.height * .2f), name, 250);

            if (GUI.Button(new Rect(Screen.width * .1f, Screen.height * .4f, Screen.width * .4f, Screen.height * .2f), "Leaderboard"))
            {
                showLeaderBoard = true;
            }

            if (GUI.Button(new Rect(Screen.width * .5f, Screen.height * .4f, Screen.width * .4f, Screen.height * .2f), "Submit Score"))
            {

                if (GUY.score > scoreThreshold)
                {
                    AddScore(name, GUY.score);

                    //AddScore(name, GUY.score);
                }
                else
                {
                    //Debug.Log("no");
                }
                showLeaderBoard = true;
            }

            if (GUI.Button(new Rect(Screen.width * .1f, Screen.height * .6f, Screen.width * .8f, Screen.height * .3f), "R E S T A R T"))
            {
                GUY.score = 0;
                Application.LoadLevel(1);
            }
        }
        else
        {
            GUI.skin.label.fontSize = GUI.skin.box.fontSize = GUI.skin.button.fontSize = GUI.skin.textField.fontSize = 12;
            GUI.Box(new Rect(Screen.width * .1f, Screen.height * .2f, Screen.width * .8f, Screen.height * .6f), "High Scores\n" + GetHighScores());
            GUI.skin.label.fontSize = GUI.skin.box.fontSize = GUI.skin.button.fontSize = GUI.skin.textField.fontSize = 30;

            if (GUI.Button(new Rect(Screen.width * .1f, Screen.height * .8f, Screen.width * .4f, Screen.height * .2f), "MENU"))
            {
                GUY.score = 0;
                Application.LoadLevel(0);
            }
            if (GUI.Button(new Rect(Screen.width * .5f, Screen.height * .8f, Screen.width * .4f, Screen.height * .2f), "RESTART"))
            {
                GUY.score = 0;
                Application.LoadLevel(1);
            }
        }
    }


    void AddScore(string name, int score)
    {
        string loadit = ("http://dreamlo.com/lb/pkuI15_XZ0CnBlMKJ0YyuwE4_Q_Y_iAEuKyfKCwcolwg/add/" + name + "/" + score);
        testScript.outputURL = loadit;
        Camera.main.gameObject.GetComponent<testScript>().enabled = true;

        /*
		StartCoroutine (LoadSite (loadit));
		WWW saveScore = new WWW(loadit);
		while(!saveScore.isDone)
		{
			//Debug.Log(saveScore.bytesDownloaded);
		}
		*/
    }

    /// <summary>
    /// Gets the high scores.
    /// </summary>
    /// <returns>The high scores.</returns>
    /// <param name="firstCol">If set to <c>true</c> first col.</param>
    string GetHighScores()
    {
        List<string[]> listScores = new List<string[]>();
        string leaderBoard = "\nscore data \nnot available :(\ncheck internet\nconnection";
        
        if (isConnected())
        {
            allScores = tmpLeaderBoard;
            string[] stuff = allScores.Split('\n');
            
            for (int i = 0; i < 5; ++i)
            {
                string[] currentScore = stuff[i].Split('"');

                leaderBoard += ((i + 1) + "." + currentScore[1] + ":" + currentScore[3] + "\n");
            }
        }

        return leaderBoard;
    }

    /// <summary>
    /// Checks connected.
    /// </summary>
    /// <returns><c>true</c>, if connected, <c>false</c> otherwise.</returns>
    bool isConnected()
    {
        return true;
    }
}