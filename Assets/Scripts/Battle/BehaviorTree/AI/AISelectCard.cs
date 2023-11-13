using System;
using Battle;
using BehaviorDesigner.Runtime.Tasks;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Action = BehaviorDesigner.Runtime.Tasks.Action;
using Random = UnityEngine.Random;


[TaskCategory("AIBattleAction")]
public class AISelectCard : Action
{
    private BattleController m_BattleController;
    [SerializeField] private GameObject m_Transform;
	
    public override void OnAwake()
    {
        base.OnAwake();
        m_BattleController = BattleController.Instance;
    }

    public override void OnStart()
    {

    }
    
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
    
    private bool DropCard()
    {
        Card card = m_BattleController.enemyCardPool.DrawCardRandomly();
        if (card == null)
        {
            // TODO cardpool has none card
            Debug.Log("none card!");
        }
        bool hasGain = false;
        EffectiveBlock effectiveBlock = card.effectiveBlocks[0];
        int[] randomSequence = GenerateShuffledSequence(card.effectiveBlocks.Count);
        
        // to find a positive gain card
        for (int i = 0; i < randomSequence.Length; i++)
        {
            if (card.GainJudgment(card.effectiveBlocks[randomSequence[i]]))
            {
                hasGain = true;
                effectiveBlock = card.effectiveBlocks[randomSequence[i]];
                break;
            }
        }
        
        
        if (hasGain ? RandomSuccess(0.7f) : RandomSuccess(0.01f))
        {
            if (!hasGain)
            {
                // Debug.Log("无收益 ->");
            }

            // m_Transform.position = new Vector3(960, 720, 0);
            GameObject newCard = GameObject.Instantiate(m_BattleController.cardPrefab,m_Transform.transform);
            newCard.GetComponent<CardController>().card = card;
            Sprite sprite = Resources.Load<Sprite>($"Card/{card.GetType().Name}");
            if (sprite != null)
            {
                newCard.GetComponentsInChildren<Image>()[0].sprite = sprite;
            }
            newCard.GetComponentsInChildren<TMP_Text>()[0].text = card.name;
            newCard.GetComponentsInChildren<TMP_Text>()[1].text = card.mp.ToString();


            Transform cardBlock = m_BattleController.cardBlocks[(int)effectiveBlock].transform;
            newCard.transform.DOMove(cardBlock.position,1) .OnComplete(() => {
                m_BattleController.PlayCard(newCard,effectiveBlock);
                // Debug.Log(card.name + "  " + card.description);
            });
            
            return true;
        }
        else
        {
            m_BattleController.enemyCardPool.PutBackInCardPool(card);
            return false;
        }
    }
    
    private bool RandomSuccess(float p)
    {
        float random = Random.Range(0f, 1f);
        return (random <= p);
    }
    
    public override TaskStatus OnUpdate()
    {
        return DropCard() ? TaskStatus.Success : TaskStatus.Failure;
    }
}
