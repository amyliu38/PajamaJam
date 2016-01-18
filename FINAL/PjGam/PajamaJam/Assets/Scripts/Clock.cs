using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Clock : MonoBehaviour {
	public GameObject BGM;
	public AudioClip Vict;
	public AudioClip Def;
	float timer = 180f;
	public Canvas ggScreen;
	public Canvas clock;
	public GameObject portal;

	Text wins;
	Text[] timers;
	string[] winners = {"Blackhole Wins!", "Hunter Wins!", "Runner Wins!"};
	// Use this for initialization
	void Start () {
		wins = ggScreen.GetComponentInChildren<Text> ();
		timers = clock.GetComponentsInChildren<Text> ();
		ggScreen.enabled = false;
		portal.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;

		timers [0].text = ""+Mathf.Round(timer);
		timers [1].text = ""+Mathf.Round(timer);

		if (timer < 60) {
			portal.SetActive (true);
		}
		if (timer <= 0) {
			GameOver(0);
		}
	}

	public void GameOver(int winner){
		ggScreen.enabled = true;
		//wins.enabled = true;
		wins.text = winners [winner];
		BGM.GetComponent<AudioSource>().Stop ();
		if (winner == 0) {
			BGM.GetComponent<AudioSource> ().clip = Def;
		} else {
			BGM.GetComponent<AudioSource>().clip = Vict;
		}
		BGM.GetComponent<AudioSource> ().loop = false;
		BGM.GetComponent<AudioSource>().Play ();
		//Destroy (this.gameObject);
		this.enabled = false;
	}

	public void Restart(){
		Application.LoadLevel ("MainMenu");
	}
}
