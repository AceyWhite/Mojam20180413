using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class GameLogic{
	public static int Get_LevelLength(){ return 5; }

	public static void ReturnToMenu(){
		Game_Logic.Manager.state = -1;
	}

	public static void Scene_Intro_Complete(){
		Game_Logic.Manager.state = 2;
	}
	public static void Scene_Map_Complete(){
		Game_Logic.Manager.state = 3;
	}
	public static void Scene_Map_Victory_Complete(){
		Game_Logic.Manager.state = 11;
	}
	public static void Scene_Spin_SelectPlayer(int i){
		PlayerData.Manager.selectedPlayer = i;
		PlayerData.Manager.previousSelectedPlayer = i;
		Game_Logic.Manager.state = 4;
	}
	public static void Scene_Choice_Selection(int i){
		switch(i){
		case 0:
			Game_Logic.Manager.stateStatus = "question";
			break;
		case 1:
			Game_Logic.Manager.stateStatus = "labyrinth";
			break;
		}
	}
	public static void Scene_Question_Result(int i){
		Game_Logic.Manager.stateStatus = "question";
		switch(i){
		case 0:
			Game_Logic.Manager.state = 7;
			break;
		case 1:
			Game_Logic.Manager.state = 8;
			break;
		}
	}
	public static void Scene_labyrinth_Result(int i){
		Game_Logic.Manager.stateStatus = "labyrinth";
		switch(i){
		case 0:
			Game_Logic.Manager.state = 7;
			break;
		case 1:
			Game_Logic.Manager.state = 8;
			break;
		}
	}
	public static void Scene_Result_Continue(){
		Game_Logic.Manager.state = 2;
	}
}

public class Game_Logic : MonoBehaviour {
	public static Game_Logic Manager;
	void Awake(){
		Manager = GetComponent<Game_Logic>();
		DontDestroyOnLoad(gameObject);
	}

	public int state; int state_TOGGLE;
	public string stateStatus;
	PlayerData myPlayerData;

	// Use this for initialization
	void Start () {
		myPlayerData = GetComponent<PlayerData>();
	}
		
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Escape)){
			GameLogic.ReturnToMenu();
		}
		switch(state){
		case -1:
			if(state_TOGGLE != state){
				Scene_Manager.Manager.Load("menu");
				Destroy(this.gameObject);
				state_TOGGLE = state;
			}
			break;
		case 0://Game
			SceneManager.LoadScene("intro");
			state++;
			break;
		case 1://intro
			if(state_TOGGLE != state){
				state_TOGGLE = state;
			}
			break;
		case 2://reset + map
			if(state_TOGGLE != state){
				Scene_Manager.Manager.Load("map");
				//SceneManager.LoadScene("map");
				myPlayerData.selectedPlayer = -1;
				myPlayerData.playerWin = -1;
				state_TOGGLE = state;
			}
			break;
		case 3://spin
			if(state_TOGGLE != state){
				Scene_Manager.Manager.Load("spin");
				state_TOGGLE = state;
			}
			break;
		case 4://choice
			if(state_TOGGLE != state){
				Scene_Manager.Manager.Load("choice");
				stateStatus = string.Empty;
				state_TOGGLE = state;
			}
			switch(stateStatus){
			case "question":
				state = 5;
				break;
			case "labyrinth":
				state = 6;
				break;
			}
			break;
		case 5://game question
			if(state_TOGGLE != state){
				Scene_Manager.Manager.Load("question");
				state_TOGGLE = state;
			}
			break;
		case 6://game labyrinth
			if(state_TOGGLE != state){
				Scene_Manager.Manager.Load("labyrinth");
				state_TOGGLE = state;
			}
			break;
		case 7://lose
			if(state_TOGGLE != state){
				Scene_Manager.Manager.Load("lose");
				state_TOGGLE = state;
			}
			break;
		case 8://win
			if(state_TOGGLE != state){
				Scene_Manager.Manager.Load("win");
				state_TOGGLE = state;
			}
			break;
		case 9://check
			if(state_TOGGLE != state){

				state_TOGGLE = state;
			}
			if(Player.Get_VictoryPlayer() == -1){
				state = 2;
			}
			else{
				state++;
			}
			break;
		case 10://map
			if(state_TOGGLE != state){
				Scene_Manager.Manager.Load("map");
				state_TOGGLE = state;
			}
			break;
		case 11://winner
			if(state_TOGGLE != state){
				Scene_Manager.Manager.Load("victory");
				state_TOGGLE = state;
			}
			break;
		}
	}
}
