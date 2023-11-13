using System.Collections.Generic;

/**
 * 易：离火
 * 效果：双方攻击型骰子 +5
 */
public class LiHuoCard : Card
{
    public LiHuoCard(string _Name, string _Description, string _MP) : base(_Name, _Description, _MP)
    {
        m_EffectiveBlocks = new List<EffectiveBlock>() { EffectiveBlock.PlayerAttackBlock, EffectiveBlock.DropBlock };
    }
    

    public override Card Clone()
    {
        return new LiHuoCard(m_Name,m_Description,m_MP.ToString());
    }
    

    public override void CalculateCardEffects(EffectiveBlock effectiveBlock)
    {
        m_BattleController.setDice(DicePhase.PlayerAttack,m_BattleController.getDice(DicePhase.PlayerAttack)+5);
        m_BattleController.setDice(DicePhase.EnemyAttack,m_BattleController.getDice(DicePhase.EnemyAttack)+5);
    }
    
    public override bool GainJudgment(EffectiveBlock effectiveBlock) { return true; }
}
