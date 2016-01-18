using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuController : MonoBehaviour {

	public Image instructions;
	public Image instru;
	public Image instru2;
	public Text[] names;
	public Button back;
	public Image credit;
	// Use this for initialization
	void Start () {
		instructions.enabled = false;
		instru.enabled = false;
		instru2.enabled = false;
		credit.enabled = false;
		back.interactable = false;
		back.image.enabled = false;
		for (int i = 0; i < names.Length; ++i) {
			names[i].enabled = false;
		}
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
		instru.enabled = true;
		instru2.enabled = true;
	}

	public void Back(){
		instructions.enabled = false;
		for (int i = 0; i < names.Length; ++i) {
			names[i].enabled = false;
		}
		instru.enabled = false;
		instru2.enabled = false;
		credit.enabled = false;
		back.interactable = false;
		back.image.enabled = false;
	}

	public void Credits(){
		credit.enabled = true;
		back.interactable = true;
		back.image.enabled = true;

		for (int i = 0; i < names.Length; ++i) {
			names[i].enabled = true;
		}
	}
}
