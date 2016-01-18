using UnityEngine;
using System.Collections;

public class ProjController : MonoBehaviour {
	//public float Damage;
	// Use this for initialization
	Vector3 vel;
	public GameObject SoundBlock;
	public GameObject explosion;

	void Start () {
		vel = this.gameObject.GetComponent<Rigidbody>().velocity;
	}
	
	// Update is called once per frame
	void Update () {
		this.gameObject.GetComponent<Rigidbody> ().velocity = vel * PlayerPrefs.GetFloat ("Speed");
	}

	void OnCollisionEnter(Collision other){
		//if (this.gameObject.tag == "Hunter") {
		//	return;
		//}
		if (other.gameObject.tag != "Border" && other.gameObject.tag != "Hunter" && other.gameObject.tag!="Runner"
		    && other.gameObject.tag!="Portal" && other.gameObject.tag!="Star") {
				Destroy (other.gameObject);
				Destroy (this.gameObject);
		}

		Instantiate (explosion,this.transform.position, Quaternion.identity);
		Instantiate (SoundBlock, this.transform.position, Quaternion.identity);
		Destroy (this.gameObject);

	}
}
