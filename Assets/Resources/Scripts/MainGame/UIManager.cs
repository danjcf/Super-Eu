using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour {

    public GameObject Window;

	public void Activate_window()
    {
        if (!Window.activeSelf)
        {
            Window.SetActive(true);
            Time.timeScale = 0.0f;
            
        }
    }

    public void Deactivate_window()
    {
        if (Window.activeSelf)
        {
            Window.SetActive(false);
            Time.timeScale = 1.0f;
        }
    }
}
