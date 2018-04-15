using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Choice_Function : MonoBehaviour {

	public int state; int state_TOGGLE;
	public string selectedChoice;
	// Use this for initialization
	void Start () {
		
	}

	public void Call_Path(string i){
		selectedChoice = i;
	}
	// Update is called once per frame
	void Update () {
		switch(state){
		case -1:
			switch(selectedChoice){
			case "question":
				GameLogic.Scene_Choice_Selection(0);
				state--;
				break;
			case "labyrinth":
				GameLogic.Scene_Choice_Selection(1);
				state--;
				break;
			}
			break;
		case 0:
			switch(selectedChoice){
			case "question":
				state--;
				break;
			case "labyrinth":
				state--;
				break;
			}
			break;
		case 1:
			if(state_TOGGLE != state){
				switch(selectedChoice){
				case "question":

					break;
				case "labyrinth":
					
					break;
				}
				state_TOGGLE = state;
			}
			switch(selectedChoice){
			case "question":

				break;
			case "labyrinth":

				break;
			}
			break;
		}
	}
}
