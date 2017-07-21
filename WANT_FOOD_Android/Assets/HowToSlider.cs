using UnityEngine;
using System.Collections;

public class HowToSlider : MonoBehaviour 
{
	public Vector3 dir = Vector3.zero;
	public float speed = 0.05f;

    private Quaternion qTo;

	void Start()
	{
		Screen.orientation = ScreenOrientation.Portrait;
        qTo = Quaternion.identity;
    }

    void Update () 
	{
		TiltPhone ();
	}

	void TiltPhone()
	{
		dir.x = Input.acceleration.x * speed;

		transform.Translate (dir.x, 0, 0);
        qTo = Quaternion.Euler(15.0f, 0.0f, 0.0f);

    }
}