using UnityEngine;
using System.Collections;

public class MoveScript : MonoBehaviour {

	public float maxSpeed = 10f;

	private Vector2 movement;
	private float inputX;
	private float inputY;
	private int previousValue = 0;
	Animator anim;
	public int Mode;//0 -> Bouge normal, 1 -> Disappear, 2 -> Gun, 3 -> Masque, 4 -> Bras, 5 -> Masque+Bras, 6 -> Full Metal
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		Mode = 0;
	}
	
	// Update is called once per frame
	void Update () {


		inputX = Input.GetAxis ("Horizontal");
		inputY = Input.GetAxis ("Vertical");

		switch (Mode) {
		case 0:
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
			break;
		case 2:
			if(Input.GetKeyDown(KeyCode.Z))
			{
				Debug.Log("Fire");
				if (previousValue == 0)
					anim.SetBool ("FireDown", true);
				
				else if (previousValue == 1)
					anim.SetBool("FireUp", true);
				
				else if (previousValue == 2)
					anim.SetBool ("FireLeft", true);
				
				else if (previousValue == 3)
					anim.SetBool ("FireRight", true);
			}
			else if (inputX == 0 && inputY == 0) {
				if (previousValue == 0)
					anim.CrossFade ("IdleGunDown", 0f);
				
				else if (previousValue == 1)
					anim.CrossFade ("IdleGunUp", 0f);
				
				else if (previousValue == 2)
					anim.CrossFade ("IdleGunLeft", 0f);
				
				else if (previousValue == 3)
					anim.CrossFade ("IdleGunRight", 0f);
			} 
			else if (inputY < 0.01 && inputX == 0) {
				anim.CrossFade ("GunDown", 0f);
				previousValue = 0;
			}
			else if(inputY > 0.01 && inputX == 0 ){
				anim.CrossFade("GunUp", 0f);;
				previousValue = 1;
			}
			else if (inputX < 0.01 && inputY == 0) {
				anim.CrossFade ("GunLeft", 0f);
				previousValue = 2;
			}
			
			else if (inputX > 0.01 && inputY == 0) {
				anim.CrossFade ("GunRight", 0f);
				previousValue = 3;
			} 
			break;
		}





	}

	void FixedUpdate(){

		inputX = Input.GetAxis ("Horizontal");
		inputY = Input.GetAxis ("Vertical");
		
		movement = new Vector2 (
			maxSpeed * inputX,
			maxSpeed * inputY);
		GetComponent<Rigidbody2D> ().velocity = movement;

	}

}