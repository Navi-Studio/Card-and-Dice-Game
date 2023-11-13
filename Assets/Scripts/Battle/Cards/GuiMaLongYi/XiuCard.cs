using System.Collections.Generic;
using UnityEngine;

/**
 * 效果：弃置对方一张手牌
 */
public class XiuCard : Card
{
    public XiuCard(string _Name, string _Description, string _MP) : base(_Name, _Description, _MP)
    {
        m_EffectiveBlocks = new List<EffectiveBlock>() { EffectiveBlock.Player };
    }

    public override Card Clone()
    {
        return new XiuCard(m_Name,m_Description,m_MP.ToString());
    }

    public override void CalculateCardEffects(EffectiveBlock effectiveBlock)
    {
        int childrenCount = m_BattleController.playerHandsGO.transform.childCount;
        if (childrenCount > 0)
        {
            int index = Random.Range(0, childrenCount);
            GameObject CardGO = m_BattleController.playerHandsGO.transform.GetChild(index).gameObject;
            m_BattleController.RemovePlayerHandsCard(CardGO.GetComponent<CardController>().card);
            m_BattleController.DropCard(CardGO);
        }
    }

    public override bool GainJudgment(EffectiveBlock effectiveBlock)
    {
        return (m_BattleController.playerHandsGO.transform.childCount > 0);
    }
}
