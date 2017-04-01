using UnityEngine;
using System.Collections;

public class GUY : MonoBehaviour 
{
    public int rogerSelector = 5;
    public GameObject[] rogers;
	public GameObject roger;
	Random generator = new Random ();
	public static int score = 0;
	public Vector3 dir = Vector3.zero;
	public float speed = 0.05f;
	public GameObject grass;
	public int frameCount = 0;

	void Start()
	{
		Screen.orientation = ScreenOrientation.Portrait;
	}
	
	void Update () 
	{
		frameCount++;

		AnimateGrass ();
		TiltPhone ();
		FOOOD ();

	}

	void OnGUI()
	{
		string stats = score + "";
		GUI.Box (new Rect (Screen.width * .7f, 0, Screen.width * .3f, Screen.height * .2f), stats);
	}

	void TiltPhone()
	{
		dir.x = Input.acceleration.x * speed;

		transform.Translate (dir.x, 0, 0);

	}

	void FOOOD()
	{
		if(frameCount % 75 == 0)
		{
            roger = rogers[Random.Range(0, 5)];
            Vector3 stuffPosition = new Vector3 (Random.Range(-4,1),5,-3);
			GameObject spawnedFood = Instantiate(roger, stuffPosition,Quaternion.identity) as GameObject;
			spawnedFood.GetComponent<Rigidbody2D>().gravityScale = 1.0f + (.005f * score);
			//Debug.Log(spawnedFood.rigidbody2D.gravityScale);
		}


	}

	void AnimateGrass()
	{
		if((frameCount/10)%2 == 0) 
		{ 
			grass.transform.Translate(0.0075f,0,0); 
		}
		else 
		{ 
			grass.transform.Translate(-0.0075f,0,0); 
		}
	}


}
