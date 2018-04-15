using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Victory_Logic : MonoBehaviour {

	public int playerVictory;

	// Use this for initialization
	void Start () {
		
	}

	int state;
	// Update is called once per frame
	void Update () {
		switch(state){
		case 0:
			state++;
			break;
		case 1:

			break;
		}
	}
}
