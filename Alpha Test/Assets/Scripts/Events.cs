using UnityEngine;
using System.Collections;

public class Events : MonoBehaviour {

	Animator animD, animC1, animC2;
	bool choice, fight, escape;
	GameObject player, C1, C2;
	IEnumerator Wait()
	{
		yield return new WaitForSeconds(2.0f);
	}

	// Use this for initialization
	void Start () {
		fight = escape = choice = false;
		animD = GameObject.Find ("Door").GetComponent<Animator>();
		animC1 = GameObject.Find ("Cyborg1").GetComponent<Animator>();
		animC2 = GameObject.Find ("Cyborg2").GetComponent<Animator>();
		player = GameObject.Find ("Player");
		C1 = GameObject.Find ("Cyborg1");
		C2 = GameObject.Find ("Cyborg2");
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Alpha4))
		{
			animD.SetTrigger("OpenDoor");
			Wait();
			animC1.SetTrigger("Begin");
			animC2.SetTrigger("Begin");
			choice = true;
		}
		if (choice) {
			if(fight || escape)
			{
				//Les cyborgs marchent vers le héros
				Vector2 VecC1, VecC2;
				VecC1 = C1.transform.position - player.transform.position;
				VecC2 = C2.transform.position - player.transform.position;
				if(VecC1.x>0)
				{
					Debug.Log("Fight");
					C1.GetComponent<Rigidbody2D>().velocity = new Vector2(0.1f, 0f);
				}
				else if(VecC1.x<0)
				{
					C1.GetComponent<Rigidbody2D>().velocity = new Vector2(-0.1f, 0f);
				}
			}
			if(fight)
			{

			}
			else if(escape)
			{
			}
			else
			{
				if(Input.GetKeyDown(KeyCode.Alpha1))
				{
					//Fight
					fight = true;

				}
				else if(Input.GetKeyDown(KeyCode.Alpha2))
				{
					//Escape
					escape = true;
				}
			}
		}
	}
}
