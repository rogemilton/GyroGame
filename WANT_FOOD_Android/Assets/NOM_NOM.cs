using UnityEngine;
using System.Collections;

public class NOM_NOM : MonoBehaviour {

    public float rotator;

    void Start()
    {
        rotator = Random.Range(-10.0f, 10.0f);
    }

    void Update()
    {
        transform.Rotate(Vector3.forward * rotator);
    }

	void OnCollisionEnter2D(Collision2D yum)
	{

		if(yum.gameObject.name == "person" )
		{
			GUY.score += 10;
			Destroy (gameObject);
		}
		if (yum.gameObject.name == "floorcollider")
		{
			Destroy(gameObject);
			Application.LoadLevel (2);
		}

	}

}
