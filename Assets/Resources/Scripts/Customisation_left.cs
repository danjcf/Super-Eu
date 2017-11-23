using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Customisation_left : MonoBehaviour {
	
	public int currentColorID;
	Image Character;
	public Color[] colors_palette;

	// Use this for initialization
	void Start () {
		Character = GameObject.Find ("Char_hair").GetComponent<Image>();
		currentColorID = 0;

	}

	public void ChangeColor_left (){
		print ("Current Color ID :" + currentColorID);
		Character.color = colors_palette [currentColorID];
		if (currentColorID == 0) {
			currentColorID = 0;
		} else if (currentColorID > 0) {
			currentColorID--;
		}
	}

}
