using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RadarController : MonoBehaviour {

	public Image enemy;
	public GameObject runner;
	public GameObject hunter;

	Color clear;
	Vector3 Runner;
	Vector3 Hunter;

	float bounds = 50f;
	float distance;
	float dx;
	float dz;
	float bx;
	float by;
	float deltay;
	float scale = 0.2f;

	// Use this for initialization
	void Start () {
		clear = enemy.color;
		clear.a = 0f;
		Blink();
	}
	
	// Update is called once per frame
	void Update () {

		Runner = runner.transform.position;
		Hunter = hunter.transform.position;
		distance = Mathf.Min(Vector3.Distance (Runner, Hunter), bounds);
		dx = Hunter.x - Runner.x;
		dz = Hunter.z - Runner.z;
		deltay = Mathf.Atan2 (dx, dz) * Mathf.Rad2Deg - 270 - hunter.transform.eulerAngles.y;
		bx = distance * Mathf.Cos (deltay * Mathf.Deg2Rad)*scale;
		by = distance * Mathf.Sin (deltay * Mathf.Deg2Rad)*scale;
		enemy.transform.localPosition = new Vector2 ( bx, by);

}

	void Blink(){
		enemy.color = clear;
		clear.a = 1f;
		Invoke ("UnBlink", .75f);
	}

	void UnBlink(){
		enemy.color = clear;
		clear.a = 0f;
		Invoke ("Blink", .75f);
	}
}
