using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsScript : MonoBehaviour {
    public Texture2D icon;
    public AudioClip pop;

    private AudioSource source;

    void Start () {
        source = GetComponent<AudioSource>();
    }

    void OnGUI()
    {
        if (GUI.Button(new Rect(Screen.width * .35f, Screen.height * .8f, Screen.width * .4f, Screen.height * .4f), icon, GUIStyle.none))
        {
            source.PlayOneShot(pop);
            Application.LoadLevel("starter");
        }

    }
}
