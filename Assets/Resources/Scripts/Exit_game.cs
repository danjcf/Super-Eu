using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit_game : MonoBehaviour {

	// Use this for initialization
	public GameObject Exit_window;
	
	public void Activate_exit_window(){
		if (!Exit_window.activeSelf) {
			Exit_window.SetActive (true);
            Time.timeScale = 0.0f;
			print ("Entrou activate window");
		}
	}

	public void Quit_game (){
        //If we are running in a standalone build of the game
    #if UNITY_STANDALONE
        //Quit the application
        Application.Quit();
    #endif

        //If we are running in the editor
    #if UNITY_EDITOR
        //Stop playing the scene
        UnityEditor.EditorApplication.isPlaying = false;
    #endif
    }

    public void Deactivate_exit_window(){
		if (Exit_window.activeSelf) {
			Exit_window.SetActive (false);
            Time.timeScale = 1.0f;
        }
	}
}
