using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class TurnEndEvent : MonoBehaviour
{
    public static event Action onPlayerTurnEnd;
    [SerializeField]private GameObject m_Coin;
    
    

    
    
    
    public void PlayerTurnEnd()
    {
        m_Coin.transform.DORotate(new Vector3(-90f, 0f, 0f), 0.5f).SetEase(Ease.Linear).OnComplete(() =>
        {
            this.GetComponent<Button>().interactable = false;
            onPlayerTurnEnd?.Invoke();
        });
    }
}
