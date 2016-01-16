using UnityEngine;
using System.Collections;

public class WarpProj : MonoBehaviour {
	public const int ASIZE = 100;
	Vector3 vel;
	void Start () {
		vel = this.gameObject.GetComponent<Rigidbody>().velocity;
	}
	
	// Update is called once per frame
	void Update () {
		this.gameObject.GetComponent<Rigidbody> ().velocity = vel * PlayerPrefs.GetFloat ("Speed");
	}
	void OnCollisionEnter(Collision hunter){
		//if(hunter.CompareTag("Hunter")){
		print ("asd");
			hunter.gameObject.transform.position = new Vector3 (Random.Range(- ASIZE, ASIZE), Random.Range(- ASIZE, ASIZE), Random.Range(- ASIZE, ASIZE));
		//}
		Destroy (this.gameObject);
	}
}
