using UnityEngine;
using System.Collections;

public class ProjController : MonoBehaviour {
	public float Damage;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision other){
		if (other.gameObject.tag != "Border") {
			if(other.gameObject.CompareTag("Runner")){
				Destroy (this);
			}
			else{
				Destroy (other.gameObject);
				Destroy (this);
			}
		}
	}
}
