using UnityEngine;
using System.Collections;
using System.Net;
using System.Collections.Generic;

public class GameOver : MonoBehaviour
{
    private int scoreThreshold = -1;
    public Font myFont;
    public Texture2D buttonSubmit;
    public Texture2D buttonMenu;
    public Texture2D buttonLeaderboard;
    public Texture2D buttonReset;
    public Texture2D buttonBack;

    private bool showLeaderBoard = false;

    public static int roger = 0;

    private string getScoresURL = "http://dreamlo.com/lb/pkuI15_XZ0CnBlMKJ0YyuwE4_Q_Y_iAEuKyfKCwcolwg/quotes";
    private string allScores = "";

    private string loseGame = "";

    private string name = "enter your name here";

    private WWW website;

    public static string tmpLeaderBoard = "";

    private string saveScoreURL = "";

    public static string outputURL = "";
    public static bool submitEnable = false;

    public static string scoresCol1;
    public static string scoresCol2;

    public AudioClip pop;

    private AudioSource source;

    void Start()
    {
        website = new WWW(getScoresURL);
        source = GetComponent<AudioSource>();
        while (!website.isDone)
        {
            //Debug.Log (website.bytesDownloaded);
        }
        tmpLeaderBoard = website.text;
    }

    void OnGUI()
    {
        GUI.skin.label.fontSize = GUI.skin.box.fontSize = GUI.skin.button.fontSize = GUI.skin.textField.fontSize = 48;
        GUI.skin.font = myFont;

        if (!showLeaderBoard)
        {
            GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "Game Over! Final score is:\n" + GUY.score);
            name = GUI.TextField(new Rect(Screen.width * .1f, Screen.height * .2f, Screen.width * .8f, Screen.height * .1f), name, 250);
            
            if (GUI.Button(new Rect(Screen.width * .3f, Screen.height * .32f, Screen.width * .4f, Screen.height * .2f), buttonSubmit, GUIStyle.none))
            {

                if (GUY.score > scoreThreshold)
                {
                    AddScore(name, GUY.score);
                }
                showLeaderBoard = true;
            }

            if (GUI.Button(new Rect(Screen.width * .15f, Screen.height * .90f, Screen.width * .1f, Screen.height * .1f), buttonMenu, GUIStyle.none))
            {
                source.PlayOneShot(pop);
                GUY.score = 0;
                Invoke("LoadStart", 0.03f);
            }

            if (GUI.Button(new Rect(Screen.width * .45f, Screen.height * .90f, Screen.width * .1f, Screen.height * .1f), buttonLeaderboard, GUIStyle.none))
            {
                source.PlayOneShot(pop);
                showLeaderBoard = true;
            }

            if (GUI.Button(new Rect(Screen.width * .75f, Screen.height * .90f, Screen.width * .1f, Screen.height * .1f), buttonReset, GUIStyle.none))
            {
                source.PlayOneShot(pop);
                GUY.score = 0;
                Invoke("LoadPlay", 0.03f);
            }
        }
        else
        {
            GUI.skin.label.fontSize = GUI.skin.box.fontSize = GUI.skin.button.fontSize = GUI.skin.textField.fontSize = 48;
            GUI.Box(new Rect(Screen.width * .1f, Screen.height * .2f, Screen.width * .8f, Screen.height * .6f), "High Scores\n" + GetHighScores());
            if (GUI.Button(new Rect(Screen.width * .15f, Screen.height * .90f, Screen.width * .1f, Screen.height * .1f), buttonMenu, GUIStyle.none))
            {
                source.PlayOneShot(pop);
                GUY.score = 0;
                Invoke("LoadStart", 0.03f);
            }

            if (GUI.Button(new Rect(Screen.width * .45f, Screen.height * .90f, Screen.width * .1f, Screen.height * .1f), buttonBack, GUIStyle.none))
            {
                source.PlayOneShot(pop);
                showLeaderBoard = false;
            }

            if (GUI.Button(new Rect(Screen.width * .75f, Screen.height * .90f, Screen.width * .1f, Screen.height * .1f), buttonReset, GUIStyle.none))
            {
                source.PlayOneShot(pop);
                GUY.score = 0;
                Invoke("LoadPlay", 0.03f);
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
        string leaderBoard = "";
        
        if (isConnected())
        {
            allScores = tmpLeaderBoard;
            string[] stuff = allScores.Split('\n');
            
            for (int i = 0; i < 10; ++i)
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

    void LoadStart()
    {
        Application.LoadLevel("starter");
    }

    void LoadPlay()
    {
        Application.LoadLevel(1);
    }
}