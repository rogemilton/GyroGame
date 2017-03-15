using UnityEngine;
using System.Collections;

public class NOM_NOM : MonoBehaviour {

	public GameObject badFood;
    public float rotator;

	void OnCollisionEnter2D(Collision2D yum)
	{

		if(yum.gameObject.name == "person" )
		{
			GUY.score += 10;
			Destroy (gameObject);
		}
		if (yum.gameObject.name == "floorcollider")
		{
			Instantiate(badFood, this.transform.position,Quaternion.identity);
			Destroy(gameObject);

			Application.LoadLevel (2);
		}

	}

}
