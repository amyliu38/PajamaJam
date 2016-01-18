using UnityEngine;
using System.Collections;

public class AudControl : MonoBehaviour {
	//public AudioClip [] clips;
	AudioSource[] source;
	// Use this for initialization
	void Start () {
		source = this.gameObject.GetComponents<AudioSource> ();
	}

	public void Play(int index,bool loop){
		if (!source[index].isPlaying || !loop) {
			source[index].Stop();
			source[index].Play();
			source[index].loop = loop;
		}
	}
	public void Stop(int index){
		if (source[index].isPlaying) {
			source[index].Stop();
		}
	}
	// Update is called once per frame
	void Update () {
	
	}
}
