using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Text;
using System.IO;

public class InteractScript : MonoBehaviour {

	// Use this for initialization

	Collider2D otherObj;
	GameObject canvas, P, PC;
	Animator animD, animC1, animC2, animP;
	Text dialogue;
	string text;
	string[] lines;
	StreamReader reader;
	bool fight, escape;
	Vector2 source, target;
	float startTime;
	bool cinematiqueDone;

	void Start () {
		canvas = GameObject.Find("BoxDialogue");
		dialogue = canvas.GetComponentInChildren<Text>();
		canvas.SetActive (false);
		animD = GameObject.Find ("Door").GetComponent<Animator>();
		animC1 = GameObject.Find ("Cyborg1").GetComponent<Animator>();
		animC2 = GameObject.Find ("Cyborg2").GetComponent<Animator>();
		animP = GameObject.Find ("PlayerCinematic").GetComponent<Animator>();
		P = GameObject.Find ("Player");
		PC = GameObject.Find ("PlayerCinematic");
		PC.SetActive (false);
		fight = escape = false;
		source = PC.transform.position;
		cinematiqueDone = false;
	}

	void LoadFile(){
		reader = new StreamReader ("dialogue.txt");
		text = reader.ReadToEnd ();
		lines = text.Split('\r');
		
	}
	// Update is called once per frame
	void Update () {
		nextDialogue ();		
		if (!cinematiqueDone) {
			if (PC.transform.position.x == 116.0f && PC.transform.position.y == 38.0f) {
				P.transform.position = PC.transform.position;
				PC.SetActive (false);
				P.GetComponent<MoveScript> ().Mode = 2;
				P.GetComponent<Animator>().CrossFade("IdleGunRight", 0f);
				GameObject.Find ("Gun").SetActive (false);
				cinematiqueDone = true;
			}
			if (PC.transform.position.x == 112.0f && PC.transform.position.y == 240.0f) {
				Debug.Log ("Fin de la fuite");
				GameObject.Find("Image").GetComponent<Animator>().CrossFade("FinDeScene", 0f);
			}
		}
	}

	void OnTriggerStay2D(Collider2D otherObj)
	{
		if (Input.GetKeyUp (KeyCode.JoystickButton0) || Input.GetKeyDown(KeyCode.E))
		{

			if (otherObj.gameObject.name == "Gun") 
			{
				//canvas.SetActive (true);
				animD.SetTrigger("OpenDoor");
				animC1.SetTrigger("Begin");
				animC2.SetTrigger("Begin");

			}
		}

	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.name == "Cyborg1" || other.gameObject.name == "Cyborg2") {
			Debug.Log ("Captured");
			GameObject.Find("Image").GetComponent<Animator>().CrossFade("FinDeScene", 0f);
		}
	}

	void OnCollisionStay2D(Collision2D otherObj){
		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			if(otherObj.gameObject.name == "Phone")
			{
				//P.SetActive(false);
				P.GetComponent<Animator>().CrossFade("Disapear", 0f);
				P.GetComponent<MoveScript>().Mode = 1;
				PC.SetActive(true);
				escape = true;
				animP.SetTrigger("Escape");
				animD.SetTrigger("OpenDoor");
				animC1.SetTrigger("Begin");
				animC2.SetTrigger("Begin");
			}
		} else if (Input.GetKeyDown (KeyCode.Alpha2)) {
			if(otherObj.gameObject.name == "Phone")
			{
				//P.SetActive(false);
				P.GetComponent<Animator>().CrossFade("Disapear", 0f);
				P.GetComponent<MoveScript>().Mode = 1;
				PC.SetActive(true);
				fight = true;
				startTime = Time.time;
				target = new Vector2(116.0f, 38.0f);
				animP.SetTrigger("Fight");
				animD.SetTrigger("OpenDoor");
				animC1.SetTrigger("Begin");
				animC2.SetTrigger("Begin");
			}
		}
		if (Input.GetKeyUp (KeyCode.JoystickButton0) || Input.GetKeyDown(KeyCode.E)) 
		{
			LoadFile ();
			if (otherObj.gameObject.name == "Couch")
			{
				canvas.SetActive (true);
				foreach(string line in lines)
				{
					if(line.Contains("Couch"))
						dialogue.text = line;	
				}
			}
			else if (otherObj.gameObject.name == "Desk" )
			{
				canvas.SetActive (true);
				foreach(string line in lines)
				{
					if(line.Contains("Desk"))
						dialogue.text = line;	
				}
			}
			else if (otherObj.gameObject.name == "Phone")
			{
				canvas.SetActive (true);
				foreach(string line in lines)
				{
					if(line.Contains("Phone"))
						dialogue.text = line;	
				}
			}
			else if (otherObj.gameObject.name == "Picture" )
			{
				canvas.SetActive (true);
				foreach(string line in lines)
				{
					if(line.Contains("Picture"))
						dialogue.text = line;	
				}
			}
		} 

	}
	void nextDialogue(){
		if (Input.GetKeyUp (KeyCode.JoystickButton1) || Input.GetKeyUp(KeyCode.A)) {
			canvas.SetActive (false);
		} 
		/*else if (Input.GetKeyUp (KeyCode.JoystickButton0) && canvas.activeSelf)
			canvas.SetActive (false);*/
	}


}

