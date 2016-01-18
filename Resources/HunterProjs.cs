using UnityEngine;
using System.Collections;

public class HunterProjs : MonoBehaviour {


	public Rigidbody Bullets;
	public GameObject Rockets;
	public GameObject Lassers;

	private float Bcooldown = 1f;
	private float Rcooldown = 3f;
	private float Lcooldown = 10f;

	private float Bspeed = 20f;
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

	void Bullet(){
		if (Bcooldown <= 0) {
			Rigidbody proj = (Rigidbody) Instantiate(Bullets, this.transform.TransformPoint(Vector3.fwd * 20), this.transform.rotation);
			proj.velocity = this.transform.TransformDirection(Vector3.forward * Bspeed);
			Bcooldown = 1f;
		}
	}

	void Rocket(){
		if (Rcooldown <= 0) {
			Rigidbody proj = (Rigidbody) Instantiate(Rockets, this.transform.TransformPoint(Vector3.fwd * 20), this.transform.rotation);
			proj.velocity = this.transform.TransformDirection(Vector3.forward * Rspeed);
			Rcooldown = 3f;
		}
	}

	void Laser(){
		if (Lcooldown <= 0) {
			Rigidbody proj = (Rigidbody) Instantiate(Laser, this.transform.TransformPoint(Vector3.fwd * 20), this.transform.rotation);
			//proj.velocity = this.transform.TransformDirection(Vector3.forward * Bspeed);
			Lcooldown = 10f;
		}
	}
}
