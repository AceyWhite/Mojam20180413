using UnityEngine;

public class ExitScript : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        string layerName = LayerMask.LayerToName(other.gameObject.layer);
        if (layerName == "Player")
        {
            LabyrinthLogic.m_Manager.SetSuccess();
        }
    }
}
