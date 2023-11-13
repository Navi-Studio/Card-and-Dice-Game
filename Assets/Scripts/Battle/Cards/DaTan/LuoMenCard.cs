using System;
using System.Collections.Generic;

[BuffAttribute("无天","若在此状态下打出回能牌，额外回复一点能量",2,PlayerOrEnemy.Enemy)]
public class LuoMenCard : Card, BuffInterface
{
    public LuoMenCard(string _Name, string _Description, string _MP) : base(_Name, _Description, _MP)
    {
        m_EffectiveBlocks = new List<EffectiveBlock>() { EffectiveBlock.Enemy };
    }

    public override Card Clone()
    {
        return new LuoMenCard(m_Name,m_Description,m_MP.ToString());
    }

    public override void CalculateCardEffects(EffectiveBlock effectiveBlock)
    {
        m_BattleController.setDice(DicePhase.EnemyAttack,(int)(m_BattleController.getDice(DicePhase.EnemyAttack) * 1.5f));
        m_BattleController.setDice(DicePhase.EnemyDefense,(int)(m_BattleController.getDice(DicePhase.EnemyDefense) * 1.5f));
    }

    public override bool GainJudgment(EffectiveBlock effectiveBlock) { return true; }
    
    public void OnBuffStart()
    {
    }

    public void OnBuffEnd()
    {
    }

    public void OnBuffPerTurn()
    {
    }

    public void TriggerBuff()
    {
        m_BattleController.enemyMP += 1;
        // todo how to trigger
    }
}
