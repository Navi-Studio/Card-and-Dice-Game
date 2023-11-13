using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ZengMingCard : Card
{
    public ZengMingCard(string _Name, string _Description, string _MP) : base(_Name, _Description, _MP)
    {
        m_EffectiveBlocks = new List<EffectiveBlock>() { EffectiveBlock.Player };
    }

    public override Card Clone()
    {
        return new ZengMingCard(m_Name,m_Description,m_MP.ToString());
    }

    private IEnumerator PlayCard(EffectiveBlock effectiveBlock)
    {

        yield return null;
    }

    public override void CalculateCardEffects(EffectiveBlock effectiveBlock)
    {
        if (m_BattleController.enemyName == "大摊")
        {
            m_BattleController.enemyHP += 5;
        }
        Transform parant = m_BattleController.m_EnemyDataGO.transform.parent.Find("EnemyHead");
        
        GameObject newCard = GameObject.Instantiate(m_BattleController.cardPrefab,parant);
        Card card = m_BattleController.enemyCardPool.DrawCardRandomly();;
        newCard.GetComponent<CardController>().card = card;
        Sprite sprite = Resources.Load<Sprite>($"Card/{card.GetType().Name}");
        if (sprite != null)
        {
            newCard.GetComponentsInChildren<Image>()[0].sprite = sprite;
        }
        newCard.GetComponentsInChildren<TMP_Text>()[0].text = card.name;
        newCard.GetComponentsInChildren<TMP_Text>()[1].text = card.mp.ToString();
        
        int[] randomSequence = GenerateShuffledSequence(card.effectiveBlocks.Count);
        Transform cardBlock = m_BattleController.cardBlocks[(int)card.effectiveBlocks[randomSequence[0]]].transform;
        newCard.transform.DOMove(cardBlock.position,1).OnComplete(() => {
            
            m_BattleController.PlayCardInDiceBlock(newCard,card.effectiveBlocks[randomSequence[0]]);
            // do it again
            Transform parant2 = m_BattleController.m_EnemyDataGO.transform.parent.Find("EnemyHead");

            GameObject newCard2 = GameObject.Instantiate(m_BattleController.cardPrefab,parant2);
            Card card2 = m_BattleController.enemyCardPool.DrawCardRandomly();;
            newCard2.GetComponent<CardController>().card = card2;
            Sprite sprite2 = Resources.Load<Sprite>($"Card/{card2.GetType().Name}");
            if (sprite2 != null)
            {
                newCard2.GetComponentsInChildren<Image>()[0].sprite = sprite2;
            }
            newCard2.GetComponentsInChildren<TMP_Text>()[0].text = card2.name;
            newCard2.GetComponentsInChildren<TMP_Text>()[1].text = card2.mp.ToString();
            int[] randomSequence2 = GenerateShuffledSequence(card2.effectiveBlocks.Count);
            Transform cardBlock2 = m_BattleController.cardBlocks[(int)card2.effectiveBlocks[randomSequence2[0]]].transform;
            newCard2.transform.DOMove(cardBlock2.position,1).OnComplete(() => {
                m_BattleController.PlayCardInDiceBlock(newCard2,card2.effectiveBlocks[randomSequence2[0]]);
            });
        });
    }

    public override bool GainJudgment(EffectiveBlock effectiveBlock) { return true; }
    
    // Fisher-Yates shuffling algorithm
    private int[] GenerateShuffledSequence(int length)
    {
        int[] sequence = new int[length];
        for (int i = 0; i < length; i++)
        {
            sequence[i] = i;
        }
        
        for (int i = 0; i < length - 1; i++)
        {
            int randomIndex = Random.Range(i, length);
            (sequence[i], sequence[randomIndex]) = (sequence[randomIndex], sequence[i]);
        }

        return sequence;
    }
}
