using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleManagerN : MonoBehaviour {

    public GameObject m_Bottle;
    private float bottleRotation;
    private float initBottleRotation = 2;
    private bool spinFlag;

    public int playerIdentificator = -1;
    
    void Start () {
		switch(PlayerData.Manager.previousSelectedPlayer){
		default:
			bottleRotation = 0;
			break;
		case 0:
			bottleRotation = -45f;
			break;
		case 1:
			bottleRotation = 45f;
			break;
		case 2:
			bottleRotation = 220f;
			break;
		case 3:
			bottleRotation = 135f;
			break;
		}
        spinFlag = false;
    }

	int state;
	float TIMER;
	float _friction_plus;
	void Update ()
    {
        Vector3 vect = new Vector3(0, bottleRotation, 0);
        m_Bottle.transform.Rotate(vect);

		switch(state){
		case 0:
			if(Input.anyKeyDown){
				SpinTheBottle();
			}
			if(TIMER != 0){
				if(Time.time >= TIMER){
					state++;
				}
			}
			break;
		}
        if (spinFlag && bottleRotation > 0)
        {
			float _friction = 0.06f;
			if(bottleRotation > 20){
				_friction = _friction_plus * 0.01f;
			}
			bottleRotation = bottleRotation - _friction;
        }
        else
        {
            bottleRotation = 0;
            //spinFlag = false;
        }
        if(bottleRotation == 0 && spinFlag == true)
        {
            playerIdentificator = -1;

            //Debug.LogWarning("Bottle has stopped! angle is" + m_Bottle.transform.forward.x + ", " + m_Bottle.transform.forward.y + ", " + m_Bottle.transform.forward.z );

            float x = m_Bottle.transform.forward.x;
            float y = m_Bottle.transform.forward.y;
            float z = m_Bottle.transform.forward.z;

            if (x > 0 && z > 0)
            {
                //Debug.LogWarning("++");
                Debug.LogWarning(" > Player 2!");
                playerIdentificator = 1;
            }

            if (x < 0 && z > 0)
            {
                //Debug.LogWarning("-+");
				Debug.LogWarning(" > Player 1!");
                playerIdentificator = 0;
            }

            if (x > 0 && z < 0)
            {
                //Debug.LogWarning("+-");
				Debug.LogWarning(" > Player 4!");
                playerIdentificator = 3;
            }

            if (x < 0 && z < 0)
            {
                //Debug.LogWarning("--");
				Debug.LogWarning(" > Player 3!");
                playerIdentificator = 2;
            }
            spinFlag = false;
        }
    }

    /*
        Returns [0,1,2,3] For players (1,2,3,4):
    */
	void SpinTheBottle()
    {
        //int chosenPlayer = -1;
		if(TIMER == 0){
			_friction_plus = Random.Range(8,14);
			TIMER = Time.time + 2f;
		}
        Debug.LogWarning("SPIN!");
        bottleRotation += Random.Range(5, 10);
		if(bottleRotation > 40){
			bottleRotation = 40;
		}
        spinFlag = true;
    }
}
