using UnityEngine;
using System.Collections;

public class NOM_NOM : MonoBehaviour {

    public float rotator;
    public GameObject eat;
    public GameObject splat;
    public GameObject chompPart;
    public GameObject splatPart;

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
            GameObject newEatSfx = (GameObject)Instantiate(eat, yum.transform.position, yum.transform.rotation);
            Destroy(newEatSfx, 0.5f);
            GameObject newChomp = (GameObject)Instantiate(chompPart, yum.transform.position, yum.transform.rotation);
            Destroy(newChomp, 0.5f);
            Destroy(gameObject);
		}
		if (yum.gameObject.name == "floorcollider")
		{
            GameObject newSplatSfx = (GameObject)Instantiate(splat, yum.transform.position, yum.transform.rotation);
            Destroy(newSplatSfx, 0.5f);
            GameObject newSplat = (GameObject)Instantiate(splatPart, yum.transform.position, yum.transform.rotation);
            Destroy(newSplat, 0.5f);
            Destroy(gameObject);
            Application.LoadLevel(2);
		}

	}

}
