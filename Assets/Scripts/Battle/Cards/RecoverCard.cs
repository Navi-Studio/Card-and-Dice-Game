using System;
using System.Collections.Generic;
using UnityEngine;

public class RecoverCard : Card
{
    private CardOperator m_Operatpor;
    private float m_Value;

    public RecoverCard(string _Name, string _Description, string _MP, string _Operatpor, string _Value) : base(_Name, _Description, _MP)
    {
        try
        {
            this.m_Operatpor = (CardOperator)CardOperator.Parse(typeof(CardOperator), _Operatpor);
            this.m_Value = float.Parse(_Value);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        m_EffectiveBlocks = new List<EffectiveBlock>() { EffectiveBlock.Enemy };
    }


    public override Card Clone()
    {
        return new RecoverCard(m_Name,m_Description,m_MP.ToString(),m_Operatpor.ToString(),m_Value.ToString());
    }

    public override void CalculateCardEffects(EffectiveBlock effectiveBlock)
    {
        if (m_Operatpor == CardOperator.Add)
        {
            m_BattleController.enemyHP += (int)m_Value;
        }
    }

    public override bool GainJudgment(EffectiveBlock effectiveBlock)
    {
        return (m_Value == 0 && m_BattleController.enemyMP - m_MP <= m_BattleController.maxEnemyMP)
               || (m_Value != 0 && m_BattleController.enemyHP + m_Value < m_BattleController.maxEnemyHP);
    }
}
