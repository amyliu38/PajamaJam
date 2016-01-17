using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HunterProjs : MonoBehaviour {

	public Slider BulletCD;
	public Slider RocketCD;

	public Rigidbody Bullets;
	public Rigidbody Rockets;
	//public Rigidbody Lasers;

	//private float Bcooldown = 1f;
	//private float Rcooldown = 3f;
	private float Lcooldown = 10f;

	private float Bspeed = 50f;
	private float Rspeed = 20f;
	// Use this for initialization
	void Start () {
		BulletCD.value = 0f;
		RocketCD.value = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		if (BulletCD.value > 0) {
			BulletCD.value -= Time.deltaTime * 2;
		}
		if (RocketCD.value > 0) {
			RocketCD.value -= Time.deltaTime / 2f;
		}
		Lcooldown -= Time.deltaTime;

	}

	public void Bullet(){
		if (BulletCD.value <= 0) {
			Rigidbody proj = (Rigidbody) Instantiate(Bullets, this.transform.TransformPoint(Vector3.right * 4), this.transform.rotation);
			proj.velocity = this.transform.TransformDirection(Vector3.right * Bspeed) * 
				this.GetComponent<PlayerMovement>().MSpeed / 5 * ((this.GetComponent<PlayerMovement>().Boost)?3:1);
			BulletCD.value = 1f;
		}
	}

	public void Rocket(){
		if (RocketCD.value <= 0) {
			Rigidbody proj = (Rigidbody) Instantiate(Rockets, this.transform.TransformPoint(Vector3.right * 7), this.transform.rotation);
			//Physics.IgnoreCollision (proj.GetComponent<Collider>(), GetComponent<Collider>());
			proj.velocity = this.transform.TransformDirection(Vector3.right * Rspeed) * 
				this.GetComponent<PlayerMovement>().MSpeed / 5 * ((this.GetComponent<PlayerMovement>().Boost)?3:1);
			RocketCD.value = 1f;
		}
	}

	/*public void Laser(){
		if (Lcooldown <= 0) {
			Rigidbody proj = (Rigidbody) Instantiate(Lasers, this.transform.TransformPoint(Vector3.right * 20), this.transform.rotation);
			//proj.velocity = this.transform.TransformDirection(Vector3.forward * Bspeed);
			Lcooldown = 10f;
		}
	}*/
}
