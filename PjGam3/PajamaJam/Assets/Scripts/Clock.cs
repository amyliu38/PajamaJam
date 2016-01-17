using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Clock : MonoBehaviour {

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
		//timers [0].text = (timer / 60).ToString ("F2");
		//timers [1].text =  (timer / 60).ToString ("F2");
		timers [0].text = Mathf.Round (timer / 60) + ":" + Mathf.Round (timer % 60);
		timers [1].text = Mathf.Round (timer / 60) + ":" + Mathf.Round (timer % 60);

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
		//Destroy (this.gameObject);

	}

	public void Restart(){
		Application.LoadLevel ("MoveTest");
	}
}
