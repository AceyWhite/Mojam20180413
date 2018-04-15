using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game_Intro_Function : MonoBehaviour {

	public int currentPage = -1;
	public GameObject[] Pages;
	public string[] Page_Info;
	public Text Page_Text;
	// Use this for initialization
	void Start () {
		currentPage = -1;
		Call_Next();
	}

	int state;
	float TIMER;
	// Update is called once per frame
	void LateUpdate () {
		switch(state){
		case 0:
			if(Time.time < TIMER){return;}
			state++;
			break;
		case 1:
			if(Time.time < TIMER){return;}
			Function_Text();
			if(Input.GetMouseButtonDown(0)){
				Call_Next();
			}
			break;
		case 2:
			GameLogic.Scene_Intro_Complete();
			state++;
			break;
		}
	}

	float Function_Text_TIMER;
	int Function_Text_AMOUNT;
	void Function_Text(){
		if(currentPage >= Page_Info.Length || Page_Info[currentPage] == null){return;}
		if(Function_Text_AMOUNT >= Page_Info[currentPage].Length){return;}
		if(Function_Text_AMOUNT < Page_Info[currentPage].Length){
			if(Time.time >= Function_Text_TIMER){
				Page_Text.text += Page_Info[currentPage][Function_Text_AMOUNT];
				Function_Text_AMOUNT++;
				Function_Text_TIMER = Time.time + 0.1f;
			}
		}
	}

	void Call_Next(){
		Function_Text_AMOUNT = 0;
		Page_Text.text = string.Empty;
		Function_Text_TIMER = Time.time + 0.1f;

		currentPage++;
		if(currentPage >= Pages.Length){
			state = 2;
			return;
		}
		for(int i = 0; i < Pages.Length; i++){
			if(currentPage == i){
				Pages[i].SetActive(true);
			}
			else{
				Pages[i].SetActive(false);
			}
		}
	}
}
