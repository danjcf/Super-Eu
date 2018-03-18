using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activate_button : MonoBehaviour {

	public BoxCollider2D object_collider;
	private CapsuleCollider2D player_collider;
	public GameObject button;

	void Start()
	{
		player_collider = GameObject.Find ("Player").GetComponent<CapsuleCollider2D>();
	}

	void Update ()
	{
		if (player_collider.IsTouching (object_collider)) {
			if (!button.activeSelf) {
				button.SetActive (true);
			}
		} else {
			if (button.activeSelf) {
				button.SetActive (false);
			}
		}
	}


	// Use this for initialization
	/*	
	void OnTriggerEnter2D(Collider2D other)
	{

		if (other.gameObject.name == "Player") {
			if (!button.activeSelf) {
				print ("Entrou");
				button.SetActive (true);
				Time.timeScale = 0.0f;

			}

		}
	}

	void OnTriggerExit2D(Collider2D other){
		if(other.gameObject.name == "Player") {
			if (button.activeSelf) {
				button.SetActive (false);
				Time.timeScale = 0.0f;

			}
		}

	}*/
}
