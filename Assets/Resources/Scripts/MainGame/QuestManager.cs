using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class QuestManager : MonoBehaviour {

    
	public Quest prefab;

    public bool[] questCompleted;
	private Quest[] questsList;
	private Text QuestBox;
	public Button[] InactiveButtons;
	public GameObject QuestWindow;

	// Use this for initialization
	void Awake () {
		QuestWindow.SetActive(false);
		QuestBox = GameObject.Find ("Quest Box").GetComponentInChildren<Text>();
		CreateListOfQuests ();
        
	}
	
	// Update is called once per frame
	void Update () {
		SetButtonCurrentQuest ();
	}

	void CreateListOfQuests(){ 																				//função que lê o ficheiro com a lista de tarefas e transforma em quests (usando o prefab da quest)
		List<string> quests_name = AlternativeReadFile("Lista de Tarefas");
		if (quests_name.Find (x => x.Contains ("Manhã")) != null) 											//Formato do ficheiro txt: Nome da quest - Descrição da quest - Duração da quest - Objecto onde vai estar a quest 
		{
			int morning_index = quests_name.FindIndex (x => x.Contains ("Manhã"));							//Index da palavra Manhã no txt, que representa a divisão das tarefas da manhã
			int lastIndex = quests_name.Count;
			int afternoon_index = quests_name.FindIndex (x => x.Contains ("Tarde"));
			string[] tasks = new string[lastIndex];
			quests_name.CopyTo (morning_index+1,tasks,0,lastIndex-1);			//Retira só as tarefas do periodo da manhã
			int tasks_afternoonIndex = afternoon_index-1;
			int counter = 0;
			int morningcounter = 1;
			int afternooncounter = 1;
			string[] foo = new string[4];
			questsList = new Quest[tasks.Length];
			char[] charsToTrim = {'\r'};
			while(counter<(tasks.Length-1))														//Ciclo para criar as quests, retira-se 1 ao tasks.length por causa da string "Tarde" a meio do ficheiro
			{
				
				if (counter < tasks_afternoonIndex && tasks [counter].Split ('\t').Length == 4) {
					Quest quest = (Instantiate (prefab) as Quest);												//Cria as várias quests
					quest.transform.SetParent (GameObject.Find ("Quest Box").transform);						//Define as quests como children do questmanager
					quest.questNumber = counter + 1;
					foo = tasks [counter].Split ('\t');													//Divide o txt através dos tabs e separa com o formato dito em cima
					foo[3] = foo [3].Trim (charsToTrim);
					quest.questName = foo [0];
					quest.questDescription = foo [1];
					quest.questPeriod = foo [2];
					quest.questObject = foo [3];
					quest.gameObject.name = "QuestMorning" + morningcounter;
					quest.isCompleted = false;
					quest.gameObject.SetActive (false);
					questsList [counter] = quest;
					foreach (Button bo in InactiveButtons) {
						if (bo.name == (foo [3] + "_Button")) {                  
							bo.onClick.AddListener (quest.QuestTextButton);
						}
                        bo.gameObject.SetActive (false);
					}
					morningcounter++;								
				}

				if(counter > tasks_afternoonIndex && tasks [counter].Split ('\t').Length == 1){					//ALTERAR PARA 4 QUANDO  O TXT TIVER COMPLETO
					Quest quest = (Instantiate (prefab) as Quest);												//Cria as várias quests
					quest.transform.SetParent (GameObject.Find ("Quest Box").transform);						//Define as quests como children do questmanager
					quest.questNumber = counter + 1;
					quest.questName = tasks [counter];

					quest.gameObject.name = "QuestAfternoon" + afternooncounter;
					quest.gameObject.SetActive (false);															//Desativa o objecto, só a primeira quest da lista fica activa
					quest.isCompleted = false;	
					questsList [counter] = quest;
					afternooncounter++;
				}

				counter++;
			}


		}

	}

	void SetButtonCurrentQuest(){
		Quest Current = CheckCurrentQuest ();

		//Quest currentQuest = GameObject.Find ("Quest1").GetComponent<Quest>();
		print(Current.questObject);
		switch (Current.questObject) {																//Switch que verifica qual o objecto a que o jogador se deve deslocar e activa a tarefa.
			case "Fridge":
				print ("entoru botao fridge");
				GameObject.Find ("Fridge").GetComponent<Activate_button> ().enabled = true;
				break;
			case "Kitchen table":
				GameObject.Find ("Kitchen table").GetComponent<Activate_button> ().enabled = true;
				break;
			case "Shower":
				GameObject.Find ("Shower").GetComponent<Activate_button> ().enabled = true;
				break;
			case "Bathroom Sink":
				break;
			case "Kid Bedside Table":
				break;
			case "Desk with laptop":
				break;
		}
	
	}

	Quest CheckCurrentQuest()																			//Função que diz qual é a quest atual (quest a ser apresentada na GUI)
	{																									//Experimentar ver primeira quest da lista de quests que tenha isCompleted=false
		int quest_length = questsList.Length;
		int cycle_counter = 0;

		while(cycle_counter<quest_length)
		{
			if (!questsList [cycle_counter].isCompleted) {												//Verifica a primeira quest que não foi completada. Ativa essa quest, apresenta na GUI e sai do ciclo
				Quest CurrentQuest = questsList [cycle_counter];
				questsList [cycle_counter].gameObject.SetActive (true);
				QuestBox.text = "Próxima Missão:\n" + questsList[cycle_counter].questName;

				return CurrentQuest;
			}

		}
		return null;
	}

	public void StartButton()                                                       					//Iniciar o minijogo (Match 2 images)
	{
		
		//Aqui provavelmente poe-se um change scene
		//Por nos playerPrefs a info da tarefa
		//Fazer scene load
		//Quest quest_started = CheckCurrentQuest();
		PlayerPrefs.SetString("Folder", /*quest_started.questName*/"TestImages");										//Tipo da Tarefa
		SceneManager.LoadScene ("Match_minigame",LoadSceneMode.Additive);
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

	List<string> AlternativeReadFile(string File_name){
		string directory = null;

		if(Application.platform == RuntimePlatform.Android)
		{
			print ("entrou Android");
			directory = "Lists\\" + File_name;
		}
		if(Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsEditor){
			print ("entrou windows");
			directory = "Lists/" + File_name;
		}
		print ("Pasta a aceder:" + directory);
		TextAsset reader = Resources.Load<TextAsset>(directory); 

		List<string> arrayoflines = new List<string> ();
		print (reader.text.Length);
		string[] linesFromfile = reader.text.Split('\n');
		foreach (string line in linesFromfile)
		{
			//Debug.Log(line);
			arrayoflines.Add (line);
		}
		return arrayoflines;
	}
}
