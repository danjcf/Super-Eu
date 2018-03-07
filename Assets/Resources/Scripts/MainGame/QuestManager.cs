using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class QuestManager : MonoBehaviour {

    //public QuestObject[] quests;
	public Quest prefab;
	//public GameObject Quest;
    public bool[] questCompleted;


	// Use this for initialization
	void Start () {
		
		CreateListOfQuests ();
        
	}
	
	// Update is called once per frame
	void Update () {
		SetButtonCurrentQuest ();
	}

	void CreateListOfQuests(){ 																				//função que lê o ficheiro com a lista de tarefas e transforma em quests (usando o prefab da quest)
		List<string> quests_name = ReadTextfile("Lista de Tarefas");
		if (quests_name.Find (x => x.Contains ("Manhã")) != null) 
		{
			int morning_index = quests_name.FindIndex (x => x.Contains ("Manhã"));							//Index da palavra Manhã no txt, que representa a divisão das tarefas da manhã

			int afternoon_index = quests_name.FindIndex (x => x.Contains ("Tarde"));
			string[] morning_tasks = new string[afternoon_index-(morning_index+1)];
			quests_name.CopyTo (morning_index+1,morning_tasks,0,afternoon_index-(morning_index+1));			//Retira só as tarefas do periodo da manhã
			Text QuestBox = GameObject.Find ("Quest Box").GetComponentInChildren<Text>();
			int counter = 0;
			while(counter<morning_tasks.Length)																//Ciclo para criar as quests
			{
				Quest quest = (Instantiate (prefab) as Quest);												//Cria as várias quests
				quest.transform.SetParent (GameObject.Find ("Quest Box").transform);						//Define as quests como children do questmanager
				quest.name = "Quest"+(counter+1);															//Insere a info do array nas quests
				quest.questName = morning_tasks [counter];
				quest.questNumber = counter + 1;
				print (quest.questName + "Num.Quest:" + quest.questNumber);
				if (quest.questNumber == 1) 
				{
					quest.gameObject.SetActive (true);
					QuestBox.text = "Próxima Missão:\n" + quest.questName;
				} 
				else {
					quest.gameObject.SetActive (false);
				}
				counter++;
			}


		}

	}

	void SetButtonCurrentQuest(){
		Quest currentQuest = GameObject.Find ("Quest1").GetComponent<Quest>();
		switch (currentQuest.questObject) {																//Switch que verifica qual o objecto a que o jogador se deve deslocar e activa a tarefa.
			case "Fridge":
				GameObject.Find ("Fridge").GetComponent<Activate_button> ().enabled = true;
				break;
			case "Kitchen table":
				GameObject.Find ("Kitchen table").GetComponent<Activate_button> ().enabled = true;
				break;	
		}
	
	}
		
	List<string> ReadTextfile(string File_name)
	{
		string path = "Assets/Resources/Lists/" + File_name + ".txt";

		//Read the text directly from the txt file
		StreamReader reader = new StreamReader(path,System.Text.Encoding.GetEncoding("iso-8859-1")); 
		string line;
		List<string> arrayoflines = new List<string> ();
		while((line = reader.ReadLine ())!= null ) {
			arrayoflines.Add (line);
		}
		reader.Close ();
		return arrayoflines;
	}
}
