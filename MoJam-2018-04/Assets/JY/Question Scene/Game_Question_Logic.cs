using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game_Question_Logic : MonoBehaviour {

	public int state;
	public int gameLevel;
	public float gameDuration; float gameDuration_TIMER; float gameDuration_TIMERTIMER;
	public Question_Manager myQuestionManager;
	public Question selectedQuestion;

	[System.Serializable]
	public class _Question{
		public Question[] myQuestion = new Question[50];
		public int _Length = -1;
	}
	[HideInInspector] public _Question[] Question = new _Question[5]; 

	[System.Serializable]
	public class _Display{
		public Text timer_text;
		public Image timer_image;
		public Text question_text;
		public Text[] answer_text;
	}
	public _Display Display;

	// Use this for initialization
	void Start () {
		gameLevel = Player.Get_currentPlayer_Level();
	}
		
	void Setup(){
		for(int i = 0; i < 4; i++){
			Display.answer_text[i].text = string.Empty;
		}
		for(int i = 0; i < myQuestionManager.questions.Length; i++){
			if(myQuestionManager.questions[i] != null){
				if(myQuestionManager.questions[i].level1 == true){
					Add_Slot(0,myQuestionManager.questions[i]);
				}
				if(myQuestionManager.questions[i].level2 == true){
					Add_Slot(1,myQuestionManager.questions[i]);
				}
				if(myQuestionManager.questions[i].level3 == true){
					Add_Slot(2,myQuestionManager.questions[i]);
				}
				if(myQuestionManager.questions[i].level4 == true){
					Add_Slot(3,myQuestionManager.questions[i]);
				}
				if(myQuestionManager.questions[i].level5 == true){
					Add_Slot(4,myQuestionManager.questions[i]);
				}
			}
		}
	}
	void Add_Slot(int level, Question thisQuestion){
		for(int x = 0; x < Question[level].myQuestion.Length; x++){
			if(Question[level].myQuestion[x] == null){
				Question[level].myQuestion[x] = thisQuestion;
				Question[level]._Length = x + 1;
				return;
			}
		}
	}
	int Select_Random_ANSWERBOX;
	void Select_Random(){
		if(Question[gameLevel]._Length == -1){return;}
		selectedQuestion = Question[gameLevel].myQuestion[Random.Range(0,Question[gameLevel]._Length)];
		gameDuration = ((GameLogic.Get_LevelLength() - gameLevel) * 5) + Random.Range(5,10) + 4;
		gameDuration_TIMER = Time.time + gameDuration;
		stocktime_TIMER = Time.time;
		Display.question_text.text = selectedQuestion.question;
		for(int i = 0; i < 4; i++){
			int _boxID = -1;
			while(_boxID == -1){
				_boxID = Random.Range(0,4);
				if(Display.answer_text[_boxID].text != string.Empty){
					_boxID = -1;
				}
			}
			Setup_AnswerBox(i,_boxID);
		}
		Display.timer_text.text = ""+gameDuration;
		Display.timer_image.fillAmount = 1;
	}
	void Setup_AnswerBox(int answerID, int boxID){
		string _answer = string.Empty;
		switch(answerID){
		case 0:
			Function_Question_CORRECTANSWERID = boxID;
			_answer = selectedQuestion.answers_correct;
			break;
		case 1:
			_answer = selectedQuestion.answers_a;
			break;
		case 2:
			_answer = selectedQuestion.answers_b;
			break;
		case 3:
			_answer = selectedQuestion.answers_c;
			break;
		}
		Display.answer_text[boxID].text = _answer;
	}
	// Update is called once per frame
	void Update () {
		Function_BG();
		switch(state){
		case 0:
			Setup();
			state++;
			break;
		case 1:
			Select_Random();
			state++;
			break;
		case 2:
			Function_Question();
			break;
		case 3:
			Lose();
			break;
		case 4:
			Win();
			break;
		}
	}
	[System.Serializable]
	public class _BG{
		public Transform[] sparkEffect_Transform = new Transform[3]; 
	}
	public _BG BG;
	void Function_BG(){
		BG.sparkEffect_Transform[0].Rotate(0,0,0.01f);
		BG.sparkEffect_Transform[1].Rotate(0,0,0.04f);
		BG.sparkEffect_Transform[2].Rotate(0,0,-0.04f);
	}
	public void Call_ButtonSelection(int selectionID){
		Function_Question_SELECTEDANSWERID = selectionID;
	}
	public int Function_Question_CORRECTANSWERID = -1;
	public int Function_Question_SELECTEDANSWERID = -1;
	void Function_Question(){
		if(Time.time >= gameDuration_TIMER){
			Display.timer_text.text = ""+0;
			Display.timer_image.fillAmount = 0;
			state = 3;
		}
		else{
			string _timer_s = ""+Mathf.CeilToInt(stocktime());
			if(Display.timer_text.text != _timer_s){
				Display.timer_text.text = _timer_s;
			}
			Display.timer_image.fillAmount = bar(stocktime(), gameDuration_TIMER - stocktime_TIMER, 1);
		}
		if(Function_Question_SELECTEDANSWERID != -1){
			if(Function_Question_SELECTEDANSWERID == Function_Question_CORRECTANSWERID){
				state = 4;
			}
			else{
				state = 3;
			}
		}
	}

	void Win(){
		GameLogic.Scene_Question_Result(1);
	}
	void Lose(){
		GameLogic.Scene_Question_Result(0);
	}

	float stocktime_TIMER;
	float stocktime(){
		return (gameDuration_TIMER - stocktime_TIMER) - (Time.time - stocktime_TIMER);
	}
	float bar(float current, float amount, float length){
		float result = 0;
		if(current < amount){
			if(amount != 1){
				result =  length * (current / ((float)amount));
			}
			else if(amount == 1){
				result =  length * (current);
			}
		}
		else if(current >= amount){
			result = length;
		}
		return result;
	}
}
