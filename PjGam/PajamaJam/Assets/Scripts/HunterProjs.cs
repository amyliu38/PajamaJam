using UnityEngine;
using System.Collections;

public class HunterProjs : MonoBehaviour {


	public Rigidbody Bullets;
	public Rigidbody Rockets;
	public Rigidbody Lasers;

	private float Bcooldown = 1f;
	private float Rcooldown = 3f;
	private float Lcooldown = 10f;

	private float Bspeed = 50f;
	private float Rspeed = 15f;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		Bcooldown -= Time.deltaTime;
		Rcooldown -= Time.deltaTime;
		Lcooldown -= Time.deltaTime;
		if(Input.GetKeyDown(KeyCode.A)){
			Bullet ();
		}
	}

	public void Bullet(){
		if (Bcooldown <= 0) {
			Rigidbody proj = (Rigidbody) Instantiate(Bullets, this.transform.TransformPoint(Vector3.right * 5), Bullets.gameObject.transform.rotation);
			proj.velocity = this.transform.TransformDirection(Vector3.right * Bspeed);
			Bcooldown = 1f;
		}
	}

	public void Rocket(){
		if (Rcooldown <= 0) {
			Rigidbody proj = (Rigidbody) Instantiate(Rockets, this.transform.TransformPoint(Vector3.right * 10), Rockets.transform.rotation);
			proj.velocity = this.transform.TransformDirection(Vector3.right * Rspeed);
			Rcooldown = 3f;
		}
	}

	public void Laser(){
		if (Lcooldown <= 0) {
			Rigidbody proj = (Rigidbody) Instantiate(Lasers, this.transform.TransformPoint(Vector3.right * 20), this.transform.rotation);
			//proj.velocity = this.transform.TransformDirection(Vector3.forward * Bspeed);
			Lcooldown = 10f;
		}
	}
}
