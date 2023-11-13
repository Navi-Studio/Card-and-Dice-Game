
using System.Collections.Generic;

[BuffAttribute("流血","每回合损失5血量，持续3回合",3,PlayerOrEnemy.Player)]
public class QianShouCard : Card, BuffInterface
{
    public QianShouCard(string _Name, string _Description, string _MP) : base(_Name, _Description, _MP)
    {
        m_EffectiveBlocks = new List<EffectiveBlock>() { EffectiveBlock.Player };
    }

    public override Card Clone()
    {
        return new QianShouCard(m_Name,m_Description,m_MP.ToString());
    }

    public override void CalculateCardEffects(EffectiveBlock effectiveBlock)
    {
        m_BattleController.playerHP -= 15;
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
        m_BattleController.playerHP -= 5;
    }

    public void TriggerBuff()
    {
    }
}
