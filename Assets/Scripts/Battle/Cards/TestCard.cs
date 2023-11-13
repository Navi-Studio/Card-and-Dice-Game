
using System.Collections.Generic;

public class TestCard : Card
{
    public TestCard(string _Name, string _Description, string _MP) : base(_Name, _Description, _MP)
    {
        m_EffectiveBlocks = new List<EffectiveBlock>() { EffectiveBlock.PlayerAttackBlock, EffectiveBlock.PlayerDefenseBlock, EffectiveBlock.Player ,EffectiveBlock.DropBlock};
    }

    public override Card Clone()
    {
        return new TestCard(m_Name,m_Description,m_MP.ToString());
    }

    public override void CalculateCardEffects(EffectiveBlock effectiveBlock)
    {
        
    }

    public override bool GainJudgment(EffectiveBlock effectiveBlock) { return true; }

    // public override string SerializeObject()
    // {
    //     return $"{m_Name},{m_Description},{m_MP}";
    // }
}
