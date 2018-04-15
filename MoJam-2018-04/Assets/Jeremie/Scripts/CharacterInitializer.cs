using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInitializer : MonoBehaviour {
    public GameObject m_CharacterPrefab;
    private GameObject m_StartingSpot;
    
	void Start () {
        InitCharacter();
    }

    public void InitCharacter()
    {

        m_StartingSpot = GameObject.Find("Spawn");
        if (m_StartingSpot != null)
        {
            Transform exactSpot = m_StartingSpot.gameObject.transform.Find("Sphere");
            float x = exactSpot.position.x;
            float z = exactSpot.position.z;
            //Debug.LogWarning("Start point found! X:[" + x + ", " + z + "]");
            Vector3 CharPos = new Vector3(x, 0, z);
            Instantiate(m_CharacterPrefab, CharPos, Quaternion.identity);
        }
        else
        {
            Debug.LogWarning("Start point NOT found!");
        }
    }
}
