﻿using UnityEngine;
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
	}

	void LoadFile(){
		reader = new StreamReader ("dialogue.txt");
		text = reader.ReadToEnd ();
		lines = text.Split('\r');
		
	}
	// Update is called once per frame
	void Update () {
		nextDialogue ();
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
	void OnCollisionStay2D(Collision2D otherObj){
		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			if(otherObj.gameObject.name == "Phone")
			{
				P.SetActive(false);
				PC.SetActive(true);
				animP.SetTrigger("Escape");
				animD.SetTrigger("OpenDoor");
				animC1.SetTrigger("Begin");
				animC2.SetTrigger("Begin");
			}
		} else if (Input.GetKeyDown (KeyCode.Alpha2)) {
			if(otherObj.gameObject.name == "Phone")
			{
				P.SetActive(false);
				PC.SetActive(true);
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
		if (Input.GetKeyUp (KeyCode.JoystickButton1)) {
			canvas.SetActive (false);
		} 
		/*else if (Input.GetKeyUp (KeyCode.JoystickButton0) && canvas.activeSelf)
			canvas.SetActive (false);*/
	}


}

