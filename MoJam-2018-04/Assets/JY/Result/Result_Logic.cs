using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Result_Logic : MonoBehaviour {

	public string ResultType;

	// Use this for initialization
	void Start () {
		LoadTIMER = Time.time + 1f;
	}

	float LoadTIMER;
	int state;
	// Update is called once per frame
	void Update () {
		if(Time.time < LoadTIMER){return;}
		switch(ResultType){
		case "win":
			Update_Win();
			break;
		case "lose":
			Update_Lose();
			break;
		}
	}

	void Update_Win(){
		switch(state){
		case 0:
			Player.Get_currentPlayer_PlusLevel();
			state++;
			break;
		case 1:
			if(Input.anyKeyDown){
				GameLogic.Scene_Result_Continue();
			}
			break;
		}
	}
	void Update_Lose(){
		switch(state){
		case 0:
			state++;
			break;
		case 1:
			if(Input.anyKeyDown){
				GameLogic.Scene_Result_Continue();
			}
			break;
		}
	}
}
