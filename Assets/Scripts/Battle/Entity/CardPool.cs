using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;


public class CardPool
{
    private Dictionary<Card, int> m_CardPool;
    
    public CardPool(Dictionary<Card, int> _mCardPool)
    {
        m_CardPool = _mCardPool;
    }
    
    public CardPool Clone()
    {
        Dictionary<Card, int> copy = m_CardPool.ToDictionary(entry => entry.Key, entry => entry.Value);
        CardPool cardPool = new CardPool(copy);
        return cardPool;
    }
    
    public Dictionary<Card, int> GetDictionary()
    {
        return m_CardPool;
    }
    
    public void AddDictionary(Card _card, int _count)
    {
        m_CardPool.Add(_card,_count);
    }
    
    
    public int GetKindCount()
    {
        return m_CardPool.Count;
    }

    public Card DrawCardRandomly()
    {
        if (m_CardPool.Count <= 0)
        {
            return null;
        }
        // TODO 按数量而不是按种类随机
        int randomNumber = Random.Range(0, m_CardPool.Count);
        Card card = m_CardPool.Keys.ElementAt(randomNumber);
        m_CardPool[card]--;
        if (m_CardPool[card] <= 0)
        {
            m_CardPool.Remove(card);
        }
        return card.Clone();
    }

    public void PutBackInCardPool(Card card)
    {
        if (m_CardPool.ContainsKey(card))
        {
            m_CardPool[card] += 1;
        }
        else
        {
            m_CardPool.Add(card, 1);
        }
    }



}
