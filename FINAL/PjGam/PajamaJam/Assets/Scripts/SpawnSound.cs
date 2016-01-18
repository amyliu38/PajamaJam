using UnityEngine;
using System.Collections;

public class SpawnSound : MonoBehaviour {
	AudioSource source;
	// Use this for initialization
	void Start () {
		source = this.gameObject.GetComponent<AudioSource> ();
		source.Play ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!source.isPlaying) {
			Destroy(this.gameObject);
		}
	}
}
