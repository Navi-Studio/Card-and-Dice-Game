using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardBlockScript : MonoBehaviour
{

    [SerializeField]private GameObject m_HighLight;

    
    public void ShowHighLight()
    {
        transform.localScale = new Vector3(1.2f, 1.2f, 1.0f);
        m_HighLight.transform.localScale = new Vector3(1.2f, 1.2f, 1.0f);
        m_HighLight.SetActive(true);
    }
    
    public void CloseHighLight()
    {
        transform.localScale = new Vector3(1f, 1f, 1f);
        m_HighLight.transform.localScale = new Vector3(1f, 1f, 1f);
        m_HighLight.SetActive(false);
    }

}
