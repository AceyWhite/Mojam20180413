using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Player{
	public static int Get_SelectedPlayer(){
		return PlayerData.Manager.selectedPlayer;
	}
	public static int Get_VictoryPlayer(){
		return PlayerData.Manager.playerWin;
	}
	public static int Get_Player_Level(int playerID){
		return PlayerData.Manager.Player[playerID].level;
	}
	public static string Get_Player_Name(int playerID){
		return PlayerData.Manager.Player[playerID].name;
	}
	public static int Get_currentPlayer_Level(){
		return PlayerData.Manager.Player[PlayerData.Manager.selectedPlayer].level;
	}
	public static string Get_currentPlayer_Name(){
		return PlayerData.Manager.Player[PlayerData.Manager.selectedPlayer].name;
	}
	public static int Get_currentPlayer_PlusLevel(){
		return PlayerData.Manager.Player[PlayerData.Manager.selectedPlayer].level++;
	}
}

public class PlayerData : MonoBehaviour {

	public static PlayerData Manager;
	void Awake(){
		Manager = GetComponent<PlayerData>();
		playerWin = -1;
	}

	[System.Serializable]
	public class _Player{
		public string name;
		public int level;
	}
	public _Player[] Player = new _Player[4];
	public int selectedPlayer = -1;
	public int playerWin = -1;
	public int previousSelectedPlayer = -1;

	// Use this for initialization
	void Start () {
		
	}
		
	public void Check_IfWin(){
		if(playerWin != -1){return;}
		for(int  i = 0; i < Player.Length; i++){
			if(Player[i].name != string.Empty){
				if(Player[i].level >= GameLogic.Get_LevelLength()){
					playerWin = i;
					break;
				}
			}
		}
	}

	// Update is called once per frame
	void LateUpdate () {
		Check_IfWin();
	}
}
