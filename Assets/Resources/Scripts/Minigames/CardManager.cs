using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class CardManager : MonoBehaviour {
	
	public Sprite cardBack;
	public Sprite cardFace;
	public Card[] CardList;
	private int Match_counter;
	private Sprite[] SpriteList,SpriteList2;
	public Card[] FlippedCards;
	public int FlipCardCounter;
	public bool isPaused = false;

	// Use this for initialization
	void Awake () {
		string folderN = PlayerPrefs.GetString ("Folder");
		print ("Folder Name - " + folderN);
		FlippedCards = new Card[2];
		FlipCardCounter = 0;
		Insert_images (folderN);
		DeactivateItems ();
	}



	void WinCondition(){
		if (Match_counter == 5) {
			//Activa uma janela de parabéns e pontos de experiência com botão para voltar para a casa
		}
	}

	public Image GetItem(Card CardItem){
		Image[] cardItem = CardItem.GetComponentsInChildren<Image> (true);
		Image Item = cardItem [1];
		return Item;

	}

	void DeactivateItems(){
		
		foreach(Card CurrentCard in CardList) {
			Image Item = GetItem (CurrentCard);
			Item.gameObject.SetActive (false);
		}
	}

	void Insert_images(string folder_name){																	//Vai buscar as imagens para o minijogo ao banco de imagens
		string directory = null;
		if(Application.platform == RuntimePlatform.Android)
		{
			directory = "ImageBank\\" + folder_name + "\\";
		}
		if(Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsEditor){
			directory = "ImageBank/" + folder_name + "/";
		}
		Image ItemImage;
		SpriteList = Resources.LoadAll <Sprite> (directory);
		List<int> ImagePlace = new List<int>(){0,1,2,3,4,5,6,7,8,9};
		foreach (Card cardtemp in CardList) {																//Ciclo que percorre as cartas (neste caso 10) e atribui uma imagem aleatória à carta
			ItemImage = GetItem(cardtemp);
			int Image_index = Randomizer (ImagePlace);
			switch (Image_index) {
				case 0:
				case 5:
					ItemImage.sprite = SpriteList [0];
					break;
				case 1:
				case 6:
					ItemImage.sprite = SpriteList [1];
					break;
				case 2:
				case 7:
					ItemImage.sprite = SpriteList [2];
					break;
				case 3:
				case 8:
					ItemImage.sprite = SpriteList [3];
					break;
				case 4:
				case 9:
					ItemImage.sprite = SpriteList [4];
					break;
			}
				
		}
	
	}

	int Randomizer(List<int> listRandom)
	{
		int index = Random.Range (0, listRandom.Count);
		int random_value = listRandom [index];
		listRandom.RemoveAt (index);
		return random_value;
	}
		
	public void ShowImage(Card FlippedCard)
	{
		
		Image tempItem = GetItem (FlippedCard);
		tempItem.gameObject.SetActive (true);

	}

	public void HideImage(Card FlippedCard){
		Image tempItem = GetItem (FlippedCard);
		tempItem.gameObject.SetActive (false);
	}

	public void CheckFlippedCards()
	{
		Image FirstCard = GetItem (FlippedCards [0]);
		Image SecondCard = GetItem (FlippedCards [1]);
		//print ("Nome primeira carta: " + FirstCard.sprite.name + "Nome segunda carta: " + SecondCard.sprite.name);
		if (FirstCard.sprite == SecondCard.sprite) {
			print ("entrou if certo");
			FlippedCards [0].isMatched = true;
			FlippedCards [1].isMatched = true;
			FlippedCards [0] = null;
			FlippedCards [1] = null;
			Match_counter++;
		} else {
			print ("entrou if errado");
			FlippedCards [0].FlipBack ();
			FlippedCards [1].FlipBack ();
			FlippedCards [0] = null;
			FlippedCards [1] = null;
		}
		FlipCardCounter = 0;
	}

	public IEnumerator DelayCheck()
	{
		
		isPaused = true;
		yield return new WaitForSeconds (1.5f);
		CheckFlippedCards ();

		isPaused = false;
	}

//-----------------------------LEGACY FUNCTIONS-------------------------------
	void CheckCardEqual(){
		foreach (Card co in CardList) {
			if (co.isFlipped) {
				foreach(Card co_other in CardList)
				{
					Sprite first_image = co.GetComponentInChildren<Image> ().sprite;
					Sprite second_image = co_other.GetComponentInChildren<Image> ().sprite;
					if (co.name == co_other.name) {
						continue;
					} else if(first_image==second_image){
						co.isMatched = true;
						co_other.isMatched = true;
						Match_counter++;
					}
				}
			}
		}
	}


}
