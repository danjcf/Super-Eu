using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {
	int current_menu = 0;
	public GameObject [] Menus;
    public GameObject Character;


	private void Set_next_menu(GameObject [] Menu,int current)
    {
		Menu [current].SetActive (false);
		Menu [current+1].SetActive (true);
	}

    private void Set_previous_menu(GameObject [] Menu, int current)
    {
        Menu[current].SetActive(false);
        Menu[current - 1].SetActive(true);
    }


	public void Next_menu (){
		print ("Menu:" + current_menu);
		switch (current_menu) {
		case 0:
			current_menu++;
            
			Set_next_menu (Menus, 0); 
			break;
		case 1:
			current_menu++;
            Character.SetActive(true);
            Set_next_menu (Menus, 1);
			break;
		case 2:
            current_menu++;
			Set_next_menu (Menus, 2); 
            break;
		case 3:
			Character.SetActive(false);
			current_menu++;
			Set_next_menu (Menus, 3);
			break;
		case 4:
			current_menu++;
			Set_next_menu (Menus, 4);
			break;
		case 5:
			current_menu++;
			Set_next_menu (Menus, 5);
			break;
		default:
			break;
		}

	}

    public void Previous_menu()
    {
        print("Menu:" + current_menu);
        switch (current_menu)
        {
            case 0:
                current_menu=0;
                
                break;
            case 2:
                current_menu--;
                Set_previous_menu(Menus, 2);
                Character.SetActive(false);
                break;
            case 3:
                current_menu--;
                Set_previous_menu(Menus, 3);
                break;
            default:
                break;
        }
    }

}
