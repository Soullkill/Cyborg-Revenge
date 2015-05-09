using UnityEngine;
using System.Collections;

public class MoveScript : MonoBehaviour {

	public float maxSpeed = 10f;

	private Vector2 movement;
	private float inputX;
	private float inputY;
	private int previousValue = 0;
	Animator anim;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {


		inputX = Input.GetAxis ("Horizontal");
		inputY = Input.GetAxis ("Vertical");

		

		if (inputX == 0 && inputY == 0) {
			if (previousValue == 0)
				anim.CrossFade ("PlayerIdleDown", 0f);

			else if (previousValue == 1)
				anim.CrossFade ("PlayerIdleUp", 0f);

			else if (previousValue == 2)
				anim.CrossFade ("PlayerIdleLeft", 0f);

			else if (previousValue == 3)
				anim.CrossFade ("PlayerIdleRight", 0f);
		} 
		else if (inputY < 0.01 && inputX == 0) {
			anim.CrossFade ("PlayerDown", 0f);
			previousValue = 0;
		}
		else if(inputY > 0.01 && inputX == 0 ){
			anim.CrossFade("PlayerUp", 0f);;
			previousValue = 1;
		}
		else if (inputX < 0.01 && inputY == 0) {
			anim.CrossFade ("PlayerLeft", 0f);
			previousValue = 2;
		}

		else if (inputX > 0.01 && inputY == 0) {
			anim.CrossFade ("PlayerRight", 0f);
			previousValue = 3;
		} 

	

		//print("Valeur X :"  + inputX);
		//print ("Valeur Y :" +  inputY);


	}

	void FixedUpdate(){

		inputX = Input.GetAxis ("Horizontal");
		inputY = Input.GetAxis ("Vertical");
		
		movement = new Vector2 (
			maxSpeed * inputX,
			maxSpeed * inputY);

		GetComponent<Rigidbody2D> ().velocity = movement;
		//anim.SetFloat ("Speed", Mathf.Abs(inputX));
		//GetComponent<Rigidbody2D> ().velocity = new Vector2 (maxSpeed * inputX,
		//                                                     maxSpeed * inputY);


	}

}