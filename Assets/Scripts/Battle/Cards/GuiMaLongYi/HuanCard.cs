using System.Collections.Generic;
using UnityEngine;

/**
 * 效果：在对调状态下，若防御骰子点数大于攻击型骰子点数则再次对调
 */
public class HuanCard : Card
{
    public HuanCard(string _Name, string _Description, string _MP) : base(_Name, _Description, _MP)
    {
        m_EffectiveBlocks = new List<EffectiveBlock>() { EffectiveBlock.Enemy };
    }

    public override Card Clone()
    {
        return new HuanCard(m_Name,m_Description,m_MP.ToString());
    }

    public override void CalculateCardEffects(EffectiveBlock effectiveBlock)
    {
        int attackDice = m_BattleController.getDice(DicePhase.EnemyAttack);
        int defenseDice = m_BattleController.getDice(DicePhase.EnemyDefense);
        if (defenseDice > attackDice)
        {
            m_BattleController.setDice(DicePhase.EnemyAttack,defenseDice);
            m_BattleController.setDice(DicePhase.EnemyDefense,attackDice);
        }
    }

    public override bool GainJudgment(EffectiveBlock effectiveBlock)
    {
        int attackDice = m_BattleController.getDice(DicePhase.EnemyAttack);
        int defenseDice = m_BattleController.getDice(DicePhase.EnemyDefense);
        return (defenseDice > attackDice && defenseDice > m_BattleController.getDice(DicePhase.PlayerDefense));
    }
}