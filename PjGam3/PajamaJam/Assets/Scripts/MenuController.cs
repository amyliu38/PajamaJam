using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuController : MonoBehaviour {

	public Image instructions;
	public Button back;

	// Use this for initialization
	void Start () {
		instructions.enabled = false;
		back.interactable = false;
		back.image.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Play(){
		print ("play");
		Application.LoadLevel ("MoveTest");

	}

	public void Instructions(){
		print ("instruction");
		instructions.enabled = true;
		back.interactable = true;
		back.image.enabled = true;
	}

	public void Back(){
		instructions.enabled = false;
		back.interactable = false;
		back.image.enabled = false;
	}
}
