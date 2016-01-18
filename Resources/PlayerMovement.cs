using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	public int PlayerNum = 1;
	public float MSpeed = 5;
	public float RotSpeed = 3;
	public bool canMove = true;
	 
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (!canMove) {
			return;
		}
		if (!Input.GetButton ("Boost")) {
			Vector3 disp = new Vector3 (0, 0, 0);
			disp.z = -Input.GetAxis ("Horizontal");
			disp.x = Input.GetAxis ("Vertical");
			this.transform.Translate (disp * Time.deltaTime * MSpeed); 
			Vector3 rot = new Vector3 (0, 0, 0);
			rot.y = Input.GetAxis ("Mouse X");
			rot.z = -Input.GetAxis ("Mouse Y");
			this.transform.Rotate (rot * RotSpeed);
		} else {
			Vector3 disp = new Vector3(1, 0, 0);

			Vector3 rot = new Vector3 (0, 0, 0);
			rot.z = -Input.GetAxis ("Mouse Y");
			if(Input.GetAxis ("Mouse X") < 0){
				//if(Mathf.Rad2Deg*transform.rotation.z < 15){
				this.transform.Rotate (new Vector3(0,-20, 0) * Time.deltaTime * RotSpeed);
				//}
				print (Mathf.Rad2Deg*transform.rotation.y);
				disp.z = -0.3f;
			}
			else if(Input.GetAxis ("Mouse X") > 0){
				//if(Mathf.Rad2Deg*transform.rotation.z >- 15){
					this.transform.Rotate (new Vector3(0,20, 0) * Time.deltaTime * RotSpeed);
				//}
				print (Mathf.Rad2Deg*transform.rotation.y);
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
			this.transform.Rotate (rot * RotSpeed);
			this.transform.Translate(disp * Time.deltaTime * MSpeed * 3);
		}
	}
}
