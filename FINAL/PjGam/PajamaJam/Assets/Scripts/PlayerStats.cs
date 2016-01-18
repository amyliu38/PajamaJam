using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerStats : MonoBehaviour {
	AudControl aud;
	//public float Health = 1f;
	public Slider Health;
	public Slider WarpCD;
	public Slider TimeCD;
	public Rigidbody WarpProj;
	public Canvas GameOverScreen;

	PlayerMovement mv;
	Clock finished;
	float Wspeed;
	float Bdamage = 0.22f;
	float Rdamage = .75f;
	float Adamage = 0.05f;
	// Use this for initialization
	void Start () {
		finished = GameOverScreen.GetComponent<Clock> ();
		WarpCD.value = 0f;
		TimeCD.value = 0f;
		Wspeed = 50f;
		aud = this.gameObject.GetComponent<AudControl> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (WarpCD.value > 0f) {
			WarpCD.value -= (Time.deltaTime/1f);
		}
		if (TimeCD.value > 0f) {
			TimeCD.value -= (Time.deltaTime/10f);
		}
	}

	void OnCollisionEnter(Collision coll){
		mv = coll.gameObject.GetComponent<PlayerMovement> ();
		//print ("hit");
		switch (coll.gameObject.tag) {
		case "Bullet": 
			Health.value -= Bdamage;
			break;
		case "Rocket":
			print (Health.value);
			Health.value -= Rdamage;
			break;
		case "Portal":
			finished.GameOver (2);
			break;
		default:
			Health.value -= Adamage;
			break;
		}

		if(Health.value <= 0){
			print ("gg");
			finished.GameOver(1);
		}
		//print (Health.value*100);
	}

	public void SlowProj(){
		if (TimeCD.value <= 0) {
			if(PlayerPrefs.GetFloat ("Speed") != 0.1f){
				aud.Play(1,false);
			}
			PlayerPrefs.SetFloat ("Speed", 0.1f);
			Invoke ("SpeedUp", 3f);
		}
	}
	
	void SpeedUp(){
		TimeCD.value = 1f;
		//aud.Play(2,false);
		PlayerPrefs.SetFloat("Speed", 1f);
	}

	public void Warp(){
		if (WarpCD.value <= 0) {
			Rigidbody proj = (Rigidbody)Instantiate (WarpProj, this.transform.TransformPoint (Vector3.right * 5), WarpProj.gameObject.transform.rotation);
			proj.velocity = PlayerPrefs.GetFloat ("Speed") * (this.transform.TransformDirection (Vector3.right * Wspeed) * 
			             this.GetComponent<PlayerMovement>().MSpeed / 2 * ((this.GetComponent<PlayerMovement>().Boost)?3:1));
			WarpCD.value = 1f;
		}
	}
}
