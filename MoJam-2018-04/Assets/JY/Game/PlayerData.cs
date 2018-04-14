using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour {

	public static PlayerData Manager;
	void Awake(){
		if(Manager != null){Destroy(Manager.gameObject);}
		Manager = GetComponent<PlayerData>();
		playerNumberWin = -1;
	}

	[System.Serializable]
	public class _Player{
		public string name;
		public int level;
	}
	public _Player[] Player = new _Player[4];

	public int playerNumberWin = -1;

	// Use this for initialization
	void Start () {
		
	}

	public void Check_IfWin(){
		if(playerNumberWin != -1){return;}
		for(int  i = 0; i < Player.Length; i++){
			if(Player[i].name != string.Empty){
				if(Player[i].level >= 5){
					playerNumberWin = i;
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
