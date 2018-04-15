using UnityEngine;

public class BottleManager : MonoBehaviour {

    public GameObject m_Bottle;
    private float bottleRotation;
    private float initBottleRotation = 2;
    private bool spinFlag;

    public int playerIdentificator = -1;
    
    void Start () {
        bottleRotation = 0;
        spinFlag = false;
    }
	
	void Update ()
    {
        Vector3 vect = new Vector3(0, bottleRotation, 0);
        m_Bottle.transform.Rotate(vect);
        /*if (Input.GetKeyDown("space"))
        {
            Debug.LogWarning("SPIN!");
            bottleRotation = Random.Range(5,20);
            spinFlag = true;
        }*/
        if (Input.GetKeyDown("space"))
        {
            SpinTheBottle();
        }
            if (spinFlag && bottleRotation > 0)
        {
            bottleRotation = bottleRotation - 0.06f;
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
                Debug.LogWarning(" > Elfe!");
                playerIdentificator = 0;
            }

            if (x < 0 && z > 0)
            {
                //Debug.LogWarning("-+");
                Debug.LogWarning(" > Naine!");
                playerIdentificator = 1;
            }

            if (x > 0 && z < 0)
            {
                //Debug.LogWarning("+-");
                Debug.LogWarning(" > Guerrière!");
                playerIdentificator = 2;
            }

            if (x < 0 && z < 0)
            {
                //Debug.LogWarning("--");
                Debug.LogWarning(" > Nain!");
                playerIdentificator = 3;
            }
            spinFlag = false;
        }
    }

    /*
        Returns [0,1,2,3] For players (1,2,3,4):
    */
    public int SpinTheBottle()
    {
        //int chosenPlayer = -1;
        Debug.LogWarning("SPIN!");
        bottleRotation += Random.Range(5, 20);
        spinFlag = true;
        return -1;
    }
}
