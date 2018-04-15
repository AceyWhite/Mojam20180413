using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map_Function : MonoBehaviour {

	[System.Serializable]
	public class _player{
		public Transform myTransform;
		public Transform myShine;
		public bool isTop;
	}
	public _player[] player = new _player[4];

	[System.Serializable]
	public class _mapPosition{
		public Transform[] myPlayerPos = new Transform[4];
	}
	public _mapPosition[] mapPosition = new _mapPosition[6];

	// Use this for initialization
	void Start () {
		
	}

	public int state;
	public int topPlayer;
	float TIMER;
	// Update is called once per frame
	void Update () {
		switch(state){
		case 0:
			topPlayer = -1;
			for(int i = 0; i < player.Length; i++){
				player[i].isTop = false;
				player[i].myTransform.position = mapPosition[Player.Get_Player_Level(i)].myPlayerPos[i].position;
				if(topPlayer == -1){
					topPlayer = i;
					player[i].isTop = true;
				}
				else{
					if(Player.Get_Player_Level(i) > Player.Get_Player_Level(topPlayer)){
						player[topPlayer].isTop = false;
						player[i].isTop = true;
						topPlayer = i;
					}
				}
			}
			for(int i = 0; i < player.Length; i++){
				if(topPlayer != -1){
					if(topPlayer != i && Player.Get_Player_Level(topPlayer) == Player.Get_Player_Level(i)){
						player[topPlayer].isTop = false;
						player[i].isTop = false;
						topPlayer = -1;
					}
				}
			}
			if(topPlayer != -1){
				player[topPlayer].myShine.gameObject.SetActive(true);
			}
			TIMER = Time.time + 5f;
			state++;
			break;
		case 1:
			if(Input.anyKeyDown){
				state++;
			}
			if(Time.time >= TIMER){
				state++;
			}
			break;
		case 2:
			if(Player.Get_VictoryPlayer() != -1){
				GameLogic.Scene_Map_Victory_Complete();
			}
			else{
				GameLogic.Scene_Map_Complete();
			}
			break;
		}
		if(state != 0){
			if(topPlayer != -1){
				player[topPlayer].myShine.Rotate(0,0,0.4f);
			}
		}
	}
}
