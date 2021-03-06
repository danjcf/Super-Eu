using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Customisation : MonoBehaviour {
	Sprite [] spritesheet_hair,spritesheet_clothes,spritesheet_eyes,spritesheet_skin;
	public int currentColorID, currentHairID,currentEyeID,currentShirtID,currentPantsID,currentShoesID,currentSkinID;
	Image Character_hair,Character_eyes,Character_shirt,Character_pants,Character_shoes,Character_skin;
	

	// Use this for initialization
	void Start () {
        
        Character_hair = GameObject.Find("Char_hair").GetComponent<Image>();
        Character_eyes = GameObject.Find("Char_eyes").GetComponent<Image>();
        Character_shirt = GameObject.Find("Char_shirt").GetComponent<Image>();
        Character_pants = GameObject.Find("Char_pants").GetComponent<Image>();
        Character_shoes = GameObject.Find("Char_shoes").GetComponent<Image>();
        Character_skin = GameObject.Find("Char_skin").GetComponent<Image>();
        
		currentColorID = 0; currentHairID = 0; currentEyeID = 0; currentShirtID = 0; currentPantsID = 0; currentShoesID = 0; currentSkinID = 0;

        spritesheet_hair = Resources.LoadAll<Sprite> ("Sprites/Characters/Boy_hair_and_colors_spritesheet");
		spritesheet_clothes = Resources.LoadAll<Sprite> ("Sprites/Characters/Boy_clothes_spritesheet");
		spritesheet_eyes = Resources.LoadAll<Sprite> ("Sprites/Characters/Eye_color_spritesheet");
        spritesheet_skin = Resources.LoadAll<Sprite>("Sprites/Characters/Skin_color_spritesheet");
	}
    

	public void changeHair_right (){
		//The columns of the matrix are hair types
		//The lines of the matrix are hair colors
		if (currentHairID < 3) {
			currentHairID++;
		}else if(currentHairID == 3)
		{
			currentHairID = 3;
		}
		foreach(Sprite hair_style in spritesheet_hair){
			if (hair_style.name.Equals ("Boy_hair_" + currentHairID + currentColorID )) {
				Character_hair.sprite = hair_style;               
				adjust_char (currentHairID, currentColorID);
			}
		}
	}

	public void changeHair_left (){
		//The columns of the matrix are hair types
		//The lines of the matrix are hair colors
		if (currentHairID > 0) {
			currentHairID--;
		}else if(currentHairID == 0)
		{
			currentHairID = 0;
		}
		foreach(Sprite hair_style in spritesheet_hair){
			if (hair_style.name.Equals ("Boy_hair_" + currentHairID + currentColorID )) {
				Character_hair.sprite = hair_style;
                adjust_char(currentHairID, currentColorID);
            }
		}
	}

    public void Change_skin_color_right()
    {
        if (currentSkinID < 7)
        {
            currentSkinID++;
        }
        else if (currentSkinID == 7)
        {
            currentSkinID = 7;
        }
        foreach (Sprite skin_color in spritesheet_skin)
        {
            if (skin_color.name.Equals("Skin_color_" + currentSkinID))
            {
                Character_skin.sprite = skin_color;
            }
        }
    }

    public void Change_skin_color_left()
    {
        if (currentSkinID > 0)
        {
            currentSkinID--;
        }
        else if (currentSkinID == 0)
        {
            currentSkinID = 0;
        }
        foreach (Sprite skin_color in spritesheet_skin)
        {
            if (skin_color.name.Equals("Skin_color_" + currentSkinID))
            {
                Character_skin.sprite = skin_color;
            }
        }
    }

    public void change_hair_color_right()
    {
        //The columns of the matrix are hair types
        //The lines of the matrix are hair colors
        if (currentColorID < 3)
        {
            currentColorID++;
        }
        else if (currentColorID == 3)
        {
            currentColorID = 3;
        }
        foreach (Sprite hair_style in spritesheet_hair)
        {
            if (hair_style.name.Equals("Boy_hair_" + currentHairID + currentColorID))
            {
                Character_hair.sprite = hair_style;
                
            }
        }
    }

    public void change_hair_color_left()
    {
        //The columns of the matrix are hair types
        //The lines of the matrix are hair colors
        if (currentColorID > 0)
        {
            currentColorID--;
        }
        else if (currentColorID == 0)
        {
            currentColorID = 0;
        }
        foreach (Sprite hair_style in spritesheet_hair)
        {
            if (hair_style.name.Equals("Boy_hair_" + currentHairID + currentColorID))
            {
                Character_hair.sprite = hair_style;

            }
        }
    }

    public void Change_eye_color_right(){
		if (currentEyeID < 3) {
			currentEyeID++;
		}else if(currentEyeID == 3)
		{
			currentEyeID = 3;
		}
		foreach (Sprite eye_color in spritesheet_eyes) {
			if (eye_color.name.Equals ("Eye_color_spritesheet_" + currentEyeID)) {
				Character_eyes.sprite = eye_color;
			}
		}
	}

	public void Change_eye_color_left(){
		if (currentEyeID > 0) {
			currentEyeID--;
		}else if(currentEyeID == 0)
		{
			currentEyeID = 0;
		}
		foreach (Sprite eye_color in spritesheet_eyes) {
			if (eye_color.name.Equals ("Eye_color_spritesheet_" + currentEyeID)) {
				Character_eyes.sprite = eye_color;
			}
		}
	}

	public void Change_shirt_color_right(){
		if (currentShirtID < 3) {
			currentShirtID++;
		}else if(currentShirtID == 3)
		{
			currentShirtID = 3;
		}
		foreach (Sprite shirt_color in spritesheet_clothes) {
			if (shirt_color.name.Equals ("Boy_shirt_" + currentShirtID)) {
				Character_shirt.sprite = shirt_color;
			}
		}
	}

	public void Change_shirt_color_left(){
		if (currentShirtID > 0) {
			currentShirtID--;
		}else if(currentShirtID == 0)
		{
			currentShirtID = 0;
		}
		foreach (Sprite shirt_color in spritesheet_clothes) {
			if (shirt_color.name.Equals ("Boy_shirt_" + currentShirtID)) {
				Character_shirt.sprite = shirt_color;
			}
		}
	}

	public void Change_pants_color_right(){
		if (currentPantsID < 3) {
			currentPantsID++;
		}else if(currentPantsID == 3)
		{
			currentPantsID = 3;
		}
		foreach (Sprite pants_color in spritesheet_clothes) {
			if (pants_color.name.Equals ("Boy_pants_" + currentPantsID)) {
				Character_pants.sprite = pants_color;
			}
		}
	}

	public void Change_pants_color_left(){
		if (currentPantsID > 0) {
			currentPantsID--;
		}else if(currentPantsID == 0)
		{
			currentPantsID = 0;
		}
		foreach (Sprite pants_color in spritesheet_clothes) {
			if (pants_color.name.Equals ("Boy_pants_" + currentPantsID)) {
				Character_pants.sprite = pants_color;
			}
		}
	}

	public void Change_shoes_color_right(){
		if (currentShoesID < 3) {
			currentShoesID++;
		}else if(currentShoesID == 3)
		{
			currentShoesID = 3;
		}
		foreach (Sprite shoes_color in spritesheet_clothes) {
			if (shoes_color.name.Equals ("Boy_shoes_" + currentShoesID)) {
				Character_shoes.sprite = shoes_color;
			}
		}
	}

	public void Change_shoes_color_left(){
		if (currentShoesID > 0) {
			currentShoesID--;
		}else if(currentShoesID == 0)
		{
			currentShoesID = 0;
		}
		foreach (Sprite shoes_color in spritesheet_clothes) {
			if (shoes_color.name.Equals ("Boy_shoes_" + currentShoesID)) {
				Character_shoes.sprite = shoes_color;
			}
		}
	}


	public void Save_choices (){
		
	
	}
    //----------------Functions------------------------------------
    
	private void adjust_char(int HairID, int ColorID){
		switch ("Boy_hair_" + HairID + ColorID) {
		case "Boy_hair_00":
			Setpositions.setYposition (Character_hair.transform, 517.2f);
			Setpositions.setRectHeight (Character_hair.rectTransform, 120);
			Setpositions.setRectWidth (Character_hair.rectTransform, 240);
			break;
		case "Boy_hair_10":
            Setpositions.setYposition (Character_hair.transform, 495);
			Setpositions.setRectHeight (Character_hair.rectTransform, 200);
            Setpositions.setRectWidth(Character_hair.rectTransform, 240);
            break;
		case "Boy_hair_20":
			//Setpositions.setYposition (Character_hair.transform, 5);
			Setpositions.setRectWidth (Character_hair.rectTransform, 200);
			Setpositions.setRectHeight (Character_hair.rectTransform, 120);
			break;

		case "Boy_hair_30":
			Setpositions.setRectHeight (Character_hair.rectTransform, 80);
			Setpositions.setRectWidth (Character_hair.rectTransform, 200);
			Setpositions.setYposition (Character_hair.transform, 517.2f);

			break;
		}
	
	}
    
}

public static class Setpositions 
{
	public static void setYposition(this Transform t, float val){Vector3 temp = t.position;temp.y = val;t.position = temp;}
	public static void setXposition(this Transform t, float val){Vector3 temp = t.position;temp.x = val;t.position = temp;}
	public static void setRectWidth(this RectTransform rt, float val){Vector2 temp = rt.sizeDelta;temp.x = val;rt.sizeDelta = temp;}
	public static void setRectHeight(this RectTransform rt, float val){Vector2 temp = rt.sizeDelta;temp.y = val;rt.sizeDelta = temp;}
}