using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu_switch : MonoBehaviour {
	
	string player_name,player_age;
	InputField Input_name, Input_age;
	Toggle Toggle_rapaz, Toggle_rapariga;

	//public GameObject New_player_menu,Customisation_menu;

	// Use this for initialization
	void Start () {
		
			Input_name = GameObject.Find ("Input_nome").GetComponent<InputField> ();
			Input_age = GameObject.Find ("AgeField").GetComponent<InputField> ();
			Toggle_rapaz = GameObject.Find ("Rapaz").GetComponent<Toggle> ();
			Toggle_rapariga = GameObject.Find ("Rapariga").GetComponent<Toggle> ();


	}


	public void Save_player_name (){
		player_name = Input_name.text;
		PlayerPrefs.SetString ("Nome", player_name);
		print(PlayerPrefs.GetString ("Nome"));

	}

	public void Save_sex (){
		if (Toggle_rapaz.isOn) {
			PlayerPrefs.SetString ("Sexo","M");
		} 
		else if (Toggle_rapariga.isOn) {
			PlayerPrefs.SetString ("Sexo","F");
		}
		print(PlayerPrefs.GetString("Sexo"));
	}

	public void Save_age () {
		player_age = Input_age.text;
		PlayerPrefs.SetString ("Idade", player_age);
		print(PlayerPrefs.GetString ("Idade"));

	}

}
