using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HunterProjs : MonoBehaviour {

	public Slider BulletCD;
	public Slider RocketCD;
	public Slider RadarCD;
	public Image radar;
	public Rigidbody Bullets;
	public Rigidbody Rockets;
	//public Rigidbody Lasers;

	//private float Bcooldown = 1f;
	//private float Rcooldown = 3f;
	private float Lcooldown = 10f;
	AudControl aud;
	private float Bspeed = 70f;
	private float Rspeed = 50f;
	// Use this for initialization
	void Start () {
		BulletCD.value = 0f;
		RocketCD.value = 0f;
		RadarCD.value = 0f;
		aud = this.gameObject.GetComponent<AudControl>();
		radar.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (BulletCD.value > 0) {
			BulletCD.value -= Time.deltaTime * 2;
		}
		if (RocketCD.value > 0) {
			RocketCD.value -= Time.deltaTime / 2f;
		}
		if (RadarCD.value > 0) {
			RadarCD.value -= Time.deltaTime/5f;
		}

	}

	public void Bullet(){
		if (BulletCD.value <= 0) {
			Rigidbody proj = (Rigidbody) Instantiate(Bullets, this.transform.TransformPoint(Vector3.right * 4) + Vector3.forward*2, this.transform.rotation);
			proj.velocity = this.transform.TransformDirection(Vector3.right * Bspeed) * 
				this.GetComponent<PlayerMovement>().MSpeed / 2 * ((this.GetComponent<PlayerMovement>().Boost)?3:1);
			Rigidbody proj2 = (Rigidbody) Instantiate(Bullets, this.transform.TransformPoint(Vector3.right * 4) + Vector3.forward*-2, this.transform.rotation);
			proj2.velocity = this.transform.TransformDirection(Vector3.right * Bspeed) * 
				this.GetComponent<PlayerMovement>().MSpeed / 2 * ((this.GetComponent<PlayerMovement>().Boost)?3:1);
			aud.Play(1, false);
			BulletCD.value = 1f;
		}
	}

	public void Rocket(){
		if (RocketCD.value <= 0) {
			Rigidbody proj = (Rigidbody) Instantiate(Rockets, this.transform.TransformPoint(Vector3.right * 7), this.transform.rotation);
			//Physics.IgnoreCollision (proj.GetComponent<Collider>(), GetComponent<Collider>());
			proj.velocity = this.transform.TransformDirection(Vector3.right * Rspeed) * 
				this.GetComponent<PlayerMovement>().MSpeed / 2 * ((this.GetComponent<PlayerMovement>().Boost)?3:1);
			aud.Play(2, false);
			RocketCD.value = 1f;
		}
	}

	public void Radar(){
		if (RadarCD.value <= 0) {
			RadarCD.value=1f;
			radar.enabled = true;
			Invoke ("RadarDisable", 10f);
		}
	}

	void RadarDisable(){
		radar.enabled = false;
	}
}
