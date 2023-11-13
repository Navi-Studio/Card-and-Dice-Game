
using System;
using System.Collections.Generic;
using Battle;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks.Unity.UnityGameObject;
using UnityEngine;

/**
 * 易：艮甲
 * 效果：下回合若对手打出2张以上加成卡牌则立即给对方造成3点伤害
 */
[BuffAttribute("艮甲","下回合若对手打出2张以上加成卡牌则立即给对方造成3点伤害",2,PlayerOrEnemy.Enemy)]
public class GenJiaCard : Card, BuffInterface
{
    public GenJiaCard(string _Name, string _Description, string _MP) : base(_Name, _Description, _MP)
    {
        m_EffectiveBlocks = new List<EffectiveBlock>() { EffectiveBlock.Enemy, EffectiveBlock.DropBlock };
    }

    public override Card Clone()
    {
        return new GenJiaCard(m_Name,m_Description,m_MP.ToString());
    }

    public override void CalculateCardEffects(EffectiveBlock effectiveBlock) { }

    public override bool GainJudgment(EffectiveBlock effectiveBlock) { return true; }


    public void OnBuffStart()
    {
        SharedBool value = true;
        GlobalVariables.Instance.SetVariable("k_GenJiaTrigger",value);
    }

    public void OnBuffEnd()
    {
        SharedBool value = false;
        GlobalVariables.Instance.SetVariable("k_GenJiaTrigger",value);
    }

    public void OnBuffPerTurn() { }

    public void TriggerBuff()
    {
        m_BattleController.enemyHP -= 3;
        m_BattleController.SettlementBuff("艮甲");
    }

}
