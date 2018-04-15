using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallScript : MonoBehaviour {

    private GameObject m_Spawn;
    void OnTriggerEnter(Collider other)
    {
        string layerName = LayerMask.LayerToName(other.gameObject.layer);
        if (layerName == "Player")
        {
            if (m_Spawn == null)
                m_Spawn = LabyrinthLogic.m_Manager.m_Spawn.gameObject;

            Transform tgo = m_Spawn.transform.Find("Sphere");

            if (tgo != null) {
                float x = tgo.position.x;
                float y = 0;
                float z = tgo.position.z;
                Debug.LogWarning(">>> init position: " + x + ", " + y + ", " + z);
                Vector3 tempVect = new Vector3(x,y,z);
                other.gameObject.transform.parent.position = tempVect;
                CharNavigator cn = other.transform.parent.GetComponent("CharNavigator") as CharNavigator;
                cn.DropCharacter();
            }
        
        }
    }
}
