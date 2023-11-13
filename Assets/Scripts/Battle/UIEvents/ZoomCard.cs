using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ZoomCard : MonoBehaviour, IPointerExitHandler, IPointerEnterHandler
{

    public float zoomSize;
    [SerializeField] private GameObject m_TipGO;


    public void OnPointerEnter(PointerEventData eventData) //当鼠标进入UI后执行的事件执行的
    {
        if (!m_TipGO.transform.parent.GetComponent<CardController>().isDraging)
        {
            transform.localScale = new Vector3(zoomSize, zoomSize, 1.0f);
            m_TipGO.SetActive(true);
        }
        else
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
            m_TipGO.SetActive(false);
        }
    }

    public void OnPointerExit(PointerEventData eventData) //当鼠标离开UI后执行的事件执行的
    {
        transform.localScale = new Vector3(1f, 1f, 1f);
        m_TipGO.SetActive(false);
    }
}
