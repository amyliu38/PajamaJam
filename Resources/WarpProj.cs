using UnityEngine;
using System.Collections;

public class WarpProj : MonoBehaviour {
	public const int ASIZE = 50;

	void OnTriggerEnter(Collider hunter){
		if(hunter.CompareTag("Hunter")){
			hunter.transform.position = new Vector3 (Random.Range(- ASIZE, ASIZE), Random.Range(- ASIZE, ASIZE), Random.Range(- ASIZE, ASIZE));
		}
		Destroy (this);
	}

	void SlowProj(){
		canMove = false;
		print ("yeah");
		Invoke ("SpeedUp", 3f);
	}
	
	void SpeedUp(){
		print ("no");
		canMove = true;
	}
}
