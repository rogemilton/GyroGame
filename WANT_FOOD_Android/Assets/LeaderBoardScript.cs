using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderBoardScript : MonoBehaviour {
    public Texture2D icon;
    public AudioClip pop;
    public Font myFont;

    private AudioSource source;

    private int scoreThreshold = -1;

    public static int roger = 0;

    private string getScoresURL = "http://dreamlo.com/lb/pkuI15_XZ0CnBlMKJ0YyuwE4_Q_Y_iAEuKyfKCwcolwg/quotes";
    private string allScores = "";

    private string loseGame = "";

    private WWW website;

    public static string tmpLeaderBoard = "";

    private string saveScoreURL = "";

    public static string outputURL = "";
    public static bool submitEnable = false;

    void Start () {
        source = GetComponent<AudioSource>();

        website = new WWW(getScoresURL);

        while (!website.isDone)
        {
            //Debug.Log (website.bytesDownloaded);
        }
        tmpLeaderBoard = website.text;
    }

    void OnGUI()
    {
        GUI.skin.font = myFont;
        GUI.skin.label.fontSize = GUI.skin.box.fontSize = GUI.skin.button.fontSize = GUI.skin.textField.fontSize = 16;
        GUI.Box(new Rect(Screen.width * .1f, Screen.height * .2f, Screen.width * .8f, Screen.height * .6f), "High Scores\n" + GetHighScores());
        if (GUI.Button(new Rect(Screen.width * .35f, Screen.height * .8f, Screen.width * .4f, Screen.height * .4f), icon, GUIStyle.none))
        {
            source.PlayOneShot(pop);
            Application.LoadLevel("starter");
        }
    }

    void AddScore(string name, int score)
    {
        string loadit = ("http://dreamlo.com/lb/pkuI15_XZ0CnBlMKJ0YyuwE4_Q_Y_iAEuKyfKCwcolwg/add/" + name + "/" + score);
        testScript.outputURL = loadit;
        Camera.main.gameObject.GetComponent<testScript>().enabled = true;
    }

    /// <summary>
    /// Gets the high scores.
    /// </summary>
    /// <returns>The high scores.</returns>
    string GetHighScores()
    {
        List<string[]> listScores = new List<string[]>();

        string leaderBoard = "\nscore data \nnot available :(\ncheck internet\nconnection";
        allScores = tmpLeaderBoard;
        string[] stuff = allScores.Split('\n');

        leaderBoard = "";
        
        for (int i = 0; i < 10; ++i)
        {
            string[] currentScore = stuff[i].Split('"');
            leaderBoard += ((i + 1) + ". " + currentScore[1] + ": " + currentScore[3] + "\n");
        }
        return leaderBoard;
    }
}
