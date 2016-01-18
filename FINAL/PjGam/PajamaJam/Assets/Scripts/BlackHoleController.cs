using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BlackHoleController : MonoBehaviour {

	Image screen;
	Color fade;
	float fadespeed = 1.5f;
	// Use this for initialization
	void Start () {
		screen = this.GetComponent<Image> ();
	}
	
	// Update is called once per frame
	void Update () {
		fade = screen.color;
		fade.a += Time.deltaTime/fadespeed;
		screen.color = fade;
	}
}
