using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharNavigator : MonoBehaviour
{
    private Transform m_CurrentChar;
    private bool m_IsPlayerHit;
    private Vector3 previousCharPosition;

    void Start ()
    {
        previousCharPosition = new Vector3(0, 0, 0);
        m_IsPlayerHit = false;
        m_CurrentChar = transform;
    }
	
	void Update ()
    {    
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hitInfo;
            bool isCharHit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo, Mathf.Infinity, LayerMask.GetMask("Player"));
            if (isCharHit)
            {
                m_IsPlayerHit = true;
            }
        }    
        if (Input.GetMouseButton(0) && m_IsPlayerHit)
        {
            DragMe();
        }    
        if (Input.GetMouseButtonUp(0))
        {
            if (m_IsPlayerHit)
                DropCharacter();
        }
        previousCharPosition = new Vector3(this.transform.position.x, 0, this.transform.position.z);
    }

    private void DragMe()
    {
        RaycastHit hitInfo;
        bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo, Mathf.Infinity);
        if (hit)
        {
            m_IsPlayerHit = true;
            Vector3 wantedPosition = new Vector3(hitInfo.point.x,0, hitInfo.point.z); 
            m_CurrentChar.position = Vector3.Lerp(previousCharPosition, wantedPosition, 0.2f);
        }
    }

    public void DropCharacter()
    {
        m_IsPlayerHit = false;
    }

}
