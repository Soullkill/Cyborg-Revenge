using UnityEngine;
using System.Collections;

public class LevelEditor : MonoBehaviour {

	public int posX = 450;
	public int posY = 450;
	public int width =  450;
	public int height = 200;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnGUI(){
		GUI.Box (new Rect (posX, posY, width, height), "Mr Smith");

	}
}
