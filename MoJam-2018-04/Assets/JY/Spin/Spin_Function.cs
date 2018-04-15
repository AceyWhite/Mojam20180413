using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin_Function : MonoBehaviour {

	public BottleManagerN myBottleManager;

	// Use this for initialization
	void Start () {
		
	}
	int state;
	float TIMER;
	// Update is called once per frame
	void LateUpdate () {
		switch(state){
		case 0:
			if(myBottleManager.playerIdentificator != -1){
				TIMER = Time.time + 1f;
				state++;
			}
			break;
		case 1:
			if(Time.time >= TIMER){
				state++;
			}
			break;
		case 2:
			GameLogic.Scene_Spin_SelectPlayer(myBottleManager.playerIdentificator);
			break;
		}

	}
}
