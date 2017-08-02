using UnityEngine;
using System.Collections;

public class HowToSlider : MonoBehaviour 
{
	public Vector3 dir = Vector3.zero;
	public float speed = 0.05f;

    private int rotate = 0;
    
	void Start()
	{
		Screen.orientation = ScreenOrientation.Portrait;
    }

    void Update () 
	{
		TiltPhone ();
	}

	void TiltPhone()
	{
		dir.x = Input.acceleration.x * speed;
        transform.Translate (dir.x, 0f, 0f);
        transform.position = new Vector3(transform.position.x, 0);

        if (dir.x != 0) {
            if ((dir.x > 0) && (rotate < 6))
            {
                transform.Rotate(0f, 0f, -rotate);
                rotate++;
            }
            else if ((dir.x < 0) && (rotate > -6))
            {
                transform.Rotate(0f, 0f, -rotate);
                rotate--;
            }
        }
    }
}