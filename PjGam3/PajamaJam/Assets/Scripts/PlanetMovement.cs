using UnityEngine;
using System.Collections;

public class PlanetMovement : MonoBehaviour {
	public float RotSpeed = 5;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.Rotate (new Vector3 (0, RotSpeed, 0) * Time.deltaTime);
	}
}
