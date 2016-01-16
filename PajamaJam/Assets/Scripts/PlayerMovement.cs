using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	public int PlayerNum = 1;
	public float MSpeed = 5;
	public float RotSpeed = 3;

	HunterProjs hunt;
	PlayerStats stats;
	string pnum;
	// Use this for initialization
	void Start () {
		hunt = this.gameObject.GetComponent<HunterProjs>();
		PlayerPrefs.SetFloat ("Speed", 1.0f);
		//print (Input.GetJoystickNames().GetValue());
		pnum = (this.tag == "Hunter") ? "" : "P2";
		if (pnum == "P2") {
			stats = this.gameObject.GetComponent<PlayerStats>();
		}
	}
	
	// Update is called once per frame
	void Update () {
	

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

		if (!Input.GetButton ("Boost" + pnum)) {
			//print ("init: " + pnum);
			Vector3 disp = new Vector3 (0, 0, 0);
			disp.z = -Input.GetAxisRaw ("Horizontal" + pnum);
			disp.x = Input.GetAxisRaw ("Vertical" + pnum);
			if(pnum != "P2"){
				disp *= PlayerPrefs.GetFloat("Speed");
			}
			this.transform.Translate (disp * Time.deltaTime * MSpeed); 
			Vector3 rot = new Vector3 (0, 0, 0);
			rot.y = Input.GetAxisRaw ("Mouse X" + pnum);
			rot.z = -Input.GetAxisRaw ("Mouse Y" + pnum);
			if(pnum != "P2"){
				rot *= PlayerPrefs.GetFloat("Speed");
			}
			this.transform.Rotate (rot * RotSpeed);
		} 
		else{
			//print ("boost: " + pnum);
			Vector3 disp = new Vector3(1, 0, 0);

			Vector3 rot = new Vector3 (0, 0, 0);
			rot.z = -Input.GetAxisRaw ("Mouse Y" + pnum);
			Vector3 turn = new Vector3(0,20, 0);
			if(pnum != "P2"){
				turn *= PlayerPrefs.GetFloat("Speed");
			}
			if(Input.GetAxisRaw ("Mouse X" + pnum) < 0){
				//if(Mathf.Rad2Deg*transform.rotation.z < 15){
				this.transform.Rotate (-turn * Time.deltaTime * RotSpeed);
				//}

				disp.z = -0.3f;
			}
			else if(Input.GetAxisRaw ("Mouse X" + pnum) > 0){
				//if(Mathf.Rad2Deg*transform.rotation.z >- 15){
					this.transform.Rotate (turn * Time.deltaTime * RotSpeed);
				//}

				disp.z = 0.3f;
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
			this.transform.Translate(disp * Time.deltaTime * MSpeed * 3);
		}
	}
}
