using UnityEngine;
using System.Collections;

public class NOM_NOM : MonoBehaviour {

    public float rotator;
    public AudioClip eat;
    public AudioClip splat;

    private AudioSource source;

    void Start()
    {
        rotator = Random.Range(-10.0f, 10.0f);
        source = GetComponent<AudioSource>();
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
            source.enabled = true;
            source.clip = eat;
            source.Play();
            Destroy (gameObject);
		}
		if (yum.gameObject.name == "floorcollider")
		{
            source.enabled = true;
            source.clip = splat;
            source.Play();
            Destroy(gameObject);
            Application.LoadLevel(2);
		}

	}

}
