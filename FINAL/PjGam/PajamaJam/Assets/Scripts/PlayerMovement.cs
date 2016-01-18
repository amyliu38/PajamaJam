using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	public float slowFactor = 5f;
	public int slowDel = 5;
	int slowCounter = 0;
	public float MSpeed = 5;
	public float RotSpeed = 3;
	public bool Warped = false, Boost = false;
	HunterProjs hunt;
	Vector3 disp = new Vector3 (0, 0, 0);
	Vector3 rot = new Vector3 (0, 0, 0);
	PlayerStats stats;
	AudControl aud;
	string pnum;
	Camera cam;
	// Use this for initialization
	void Start () {
		hunt = this.gameObject.GetComponent<HunterProjs>();
		PlayerPrefs.SetFloat ("Speed", 1.0f);
		//print (Input.GetJoystickNames().GetValue());
		pnum = (this.tag == "Hunter") ? "" : "P2";
		if (pnum == "P2") {
			stats = this.gameObject.GetComponent<PlayerStats>();
		}
		cam = GameObject.FindGameObjectWithTag ((pnum == "P2") ? "RunnerCam" : "MainCamera").GetComponent<Camera>();
		aud = this.gameObject.GetComponent<AudControl>();
	}
	
	// Update is called once per frame
	void Update () {

		if (Warped) {
			cam.fieldOfView += 3;
			if(cam.fieldOfView >= 170){Warped=false;}
		}
		else if(!Warped && cam.fieldOfView > 60){
			cam.fieldOfView -= 3;				
		}


		if (Input.GetButton ("Fire2") && pnum != "P2") {
			hunt.Radar();
		}


		if (Input.GetAxis ("Fire" + pnum) < 0 || Input.GetButton("Fire1")) {
			if(pnum != "P2"){
				hunt.Bullet();
			}else{
				stats.Warp();
			}

		}
		else if (Input.GetAxis ("Fire" + pnum) > 0) {
			if(pnum != "P2"){
				hunt.Rocket();

			}else{
				stats.SlowProj();

			}
		}
		slowSpeed ();
		Boost = Input.GetButton ("Boost" + pnum);
		if (Boost) {
			aud.Play(0, true);
		} else if(aud != null) {
			aud.Stop(0);
		}
		if (!Input.GetButton ("Boost" + pnum) || pnum == "P2") {
			//print ("init: " + pnum);

			disp.z += -Input.GetAxisRaw ("Horizontal" + pnum);
			disp.x += Input.GetAxisRaw ("Vertical" + pnum);
			if(pnum != "P2"){
				disp *= PlayerPrefs.GetFloat("Speed");
			}

			this.transform.Translate (disp * Time.deltaTime * MSpeed); 

			rot.y += Input.GetAxisRaw ("Mouse X" + pnum);
			rot.z += -Input.GetAxisRaw ("Mouse Y" + pnum);
			if(pnum != "P2"){
				rot *= PlayerPrefs.GetFloat("Speed");
			}

			this.transform.Rotate(rot * RotSpeed);
		} 
		else{
			//print ("boost: " + pnum);
			disp.x += 1;
			rot.z += -Input.GetAxisRaw ("Mouse Y" + pnum);
			Vector3 turn = new Vector3(0,20, 0);
			if(pnum != "P2"){
				turn *= PlayerPrefs.GetFloat("Speed");
			}
			if(Input.GetAxisRaw ("Mouse X" + pnum) < 0){
				//if(Mathf.Rad2Deg*transform.rotation.z < 15){
				this.transform.Rotate (-turn * Time.deltaTime * RotSpeed);
				//}

				disp.z += -0.1f;
			}
			else if(Input.GetAxisRaw ("Mouse X" + pnum) > 0){
				//if(Mathf.Rad2Deg*transform.rotation.z >- 15){
					this.transform.Rotate (turn * Time.deltaTime * RotSpeed);
				//}

				disp.z += 0.1f;
			}
			/*
			else{
				if(Mathf.Rad2Deg*transform.rotation.y > 5){
					this.transform.Rotate (new Vector3(0,-10, 0) * Time.deltaTime * RotSpeed);
				}
				else if(Mathf.Rad2Deg*transform.rotation.y < 5){
					this.transform.Rotate (new Vector3(0,10, 0) * Time.deltaTime * RotSpeed);
				}
				disp.z = 0;
			}
*/
			if(pnum != "P2"){
				rot *= PlayerPrefs.GetFloat("Speed");
			}

			this.transform.Rotate (rot * RotSpeed);
			if(pnum != "P2"){
				disp *= PlayerPrefs.GetFloat("Speed");
			}
			this.transform.Translate(disp * Time.deltaTime * MSpeed * 2);
		}
	}

	void slowSpeed(){
		slowCounter++;
		if(slowCounter > slowDel){
			disp /= slowFactor;
			rot /= slowFactor;
			slowCounter = 0;
		}
		
		
	}
}