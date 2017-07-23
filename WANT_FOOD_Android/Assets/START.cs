using UnityEngine;
using System.Collections;

public class START : MonoBehaviour {
    public Texture2D buttonPlay;
    public Texture2D buttonCredits;
    public Texture2D buttonHowTo;
    public Texture2D buttonLeaderBoard;
    public AudioClip pop;

    private AudioSource source;

    void Start()
	{
        source = GetComponent<AudioSource>();
    }

	void OnGUI()
	{
        if (GUI.Button(new Rect(Screen.width*.35f, Screen.height*.5f, Screen.width*.4f, Screen.height*.1f), buttonPlay, GUIStyle.none))
	    {
            source.PlayOneShot(pop);
            Invoke("LoadPlay", 0.03f);
        }

	    if (GUI.Button(new Rect(Screen.width * .45f, Screen.height * .90f, Screen.width * .1f, Screen.height * .1f), buttonLeaderBoard, GUIStyle.none))
        {
            source.PlayOneShot(pop);
            Invoke("LoadLeaderBoard", 0.03f);
        }

        if (GUI.Button(new Rect(Screen.width * .15f, Screen.height * .90f, Screen.width * .1f, Screen.height * .1f), buttonHowTo, GUIStyle.none))
        {
            source.PlayOneShot(pop);
            Invoke("LoadHowTo", 0.03f);
        }

        if (GUI.Button(new Rect(Screen.width * .75f, Screen.height * .90f, Screen.width * .1f, Screen.height * .1f), buttonCredits, GUIStyle.none))
        {
            source.PlayOneShot(pop);
            Invoke("LoadCredits", 0.03f);
        }

    }

    //Dumb way to get the sound working
    void LoadPlay()
    {
        Application.LoadLevel(1);
    }

    void LoadLeaderBoard()
    {
        Application.LoadLevel(4);
    }

    void LoadHowTo()
    {
        Application.LoadLevel(5);
    }

    void LoadCredits()
    {
        Application.LoadLevel(3);
    }

}
