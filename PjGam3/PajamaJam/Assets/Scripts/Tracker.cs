using UnityEngine;
using System.Collections;

public class Tracker : MonoBehaviour {
	public GameObject Runner;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.forward = Runner.transform.right - this.transform.position;
	}
}
