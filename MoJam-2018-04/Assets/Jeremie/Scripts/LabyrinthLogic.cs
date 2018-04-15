using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    0: nothing (yet)
    1: Timeout!
    2: Labyrinth successfully completed
*/
public class LabyrinthLogic : MonoBehaviour {

    public int m_LabyrinthStatus;
    [HideInInspector]
    public Transform m_Spawn;
    public static LabyrinthLogic m_Manager;

    void Awake()
    {
        m_Manager = GetComponent<LabyrinthLogic>();
        GameObject spawnObj = GameObject.Find("Spawn");
        m_Spawn = spawnObj.transform;
    }

    void Start () {
        m_LabyrinthStatus = 0;
    }

    /* Call this funciton when Timer is to 0:00 */
    public void SetTimeout()
    {
        Debug.Log("<<< Logic:: TIME OUT! >>>");
        m_LabyrinthStatus = 1;
    }

    /* When user reach the end of the labyrinth: */
    public void SetSuccess()
    {
        Debug.Log("<<< Logic:: SUCCESS! >>>");
        m_LabyrinthStatus = 2;
    }

}
