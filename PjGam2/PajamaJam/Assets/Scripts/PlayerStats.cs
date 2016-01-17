using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerStats : MonoBehaviour {

	//public float Health = 1f;
	public Slider Health;
	public Slider WarpCD;
	public Slider TimeCD;
	public Rigidbody WarpProj;
	PlayerMovement mv;
	float Wspeed;
	float Bdamage = 0.3f;
	float Rdamage = 0.5f;
	float Ldamage = 1.0f;
	float Adamage = 0.1f;
	// Use this for initialization
	void Start () {

		WarpCD.value = 0f;
		TimeCD.value = 0f;
		Wspeed = 20f;
	}
	
	// Update is called once per frame
	void Update () {
		if (WarpCD.value > 0f) {
			WarpCD.value -= (Time.deltaTime/3f);
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
			Health.value -= Rdamage;
			break;
		default:
			Health.value -= Adamage;
			break;
		}

		if(Health.value <= 0){
			print ("gg");
			//trigger Game Over
		}
		//print (Health.value*100);
	}

	public void SlowProj(){
		if (TimeCD.value <= 0) {
			PlayerPrefs.SetFloat ("Speed", 0.1f);
			Invoke ("SpeedUp", 3f);
		}
	}
	
	void SpeedUp(){
		TimeCD.value = 1f;
		PlayerPrefs.SetFloat("Speed", 1f);
	}

	public void Warp(){
		if (WarpCD.value <= 0) {
			Rigidbody proj = (Rigidbody)Instantiate (WarpProj, this.transform.TransformPoint (Vector3.right * 5), WarpProj.gameObject.transform.rotation);
			proj.velocity = this.transform.TransformDirection (Vector3.right * Wspeed* PlayerPrefs.GetFloat ("Speed"));
			WarpCD.value = 1f;
		}
	}
}
