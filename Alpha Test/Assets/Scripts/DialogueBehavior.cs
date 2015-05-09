using UnityEngine;
using System.Collections;
using System.IO;

public class DialogueBehavior : MonoBehaviour {
	GUIText Dialogue;
	GameObject Canvas;
	TextReader text;
	// Use this for initialization
	void Start () {
		Canvas = GameObject.Find ("Canvas");
		Dialogue = Canvas.GetComponentInChildren<GUIText>();
		Canvas.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.Alpha1))
		{
			text = new StreamReader ("dialogues.txt");
			//Canvas.SetActive(true);
			Dialogue.text = text.ReadToEnd();
			text.Close();
		}
		else if(Input.GetKey(KeyCode.Alpha2))
		{
			//Canvas.SetActive(true);
			Dialogue.text = "Test";
		}
		else if(Input.GetKey(KeyCode.Alpha3))
		{
			Canvas.SetActive(false);
		}
	}
}
