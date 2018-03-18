using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Quest : MonoBehaviour {
	
	public int questNumber;
	public string questName;
	public string questDescription;
	public string questPeriod;
	public string questObject;
	public bool isCompleted;
	private QuestManager theQM;
	//private GameObject QuestWindow;

	void Start(){
		theQM = GameObject.Find ("Quest Box").GetComponent<QuestManager> ();
	}

	public void QuestTextButton()
	{
        theQM.QuestWindow.SetActive(true);
        theQM.QuestWindow.transform.TransformPoint(new Vector3((2*Screen.width) / 3, Screen.height / 2, 0));
        Text[] QuestTexts = theQM.QuestWindow.GetComponentsInChildren<Text>();
        foreach (Text to in QuestTexts)
        {
            if (to.name == "MissionText")
            {
                to.text = questName;
            }
            if(to.name == "DescriptionText")
            {
                to.text = questDescription;
            }
        }
        
	}

    public void QuestCompleted()
	{
		isCompleted = true;
	}
}
