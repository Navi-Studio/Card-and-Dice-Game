using System;
using System.Collections.Generic;

public enum CardOperator
{
    Add,
    Subtract,
    Multiply,
    Divide
}

public class CommonCard : Card
{
    private CardOperator m_Operatpor;
    private float m_Value;
    
    
    public CommonCard(string _Name, string _Description, string _MP, string _Operatpor, string _Value) : base(_Name, _Description, _MP)
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

        m_EffectiveBlocks = new List<EffectiveBlock>() { EffectiveBlock.PlayerAttackBlock, EffectiveBlock.PlayerDefenseBlock, EffectiveBlock.EnemyAttackBlock, EffectiveBlock.EnemyDefenseBlock, EffectiveBlock.DropBlock };
    }


    public override Card Clone()
    {
        return new CommonCard(m_Name,m_Description,m_MP.ToString(),m_Operatpor.ToString(),m_Value.ToString());
    }
    
    public override void CalculateCardEffects(EffectiveBlock effectiveBlock)
    {
        int dick = m_BattleController.getDice((DicePhase)effectiveBlock);
        int ans = CalculateOperatpor(dick);
        m_BattleController.setDice((DicePhase)effectiveBlock,ans);
    }

    public override bool GainJudgment(EffectiveBlock effectiveBlock)
    {
        if (m_Operatpor == CardOperator.Add || m_Operatpor == CardOperator.Multiply)
        {
            if (effectiveBlock == EffectiveBlock.EnemyAttackBlock)
            {
                int dick = m_BattleController.getDice(DicePhase.EnemyAttack);
                return (CalculateOperatpor(dick) >= m_BattleController.getDice(DicePhase.PlayerDefense) - 1);   // 1 is to encourage enemy to attack more
            }
            else if(effectiveBlock == EffectiveBlock.EnemyDefenseBlock)
            {
                int dick = m_BattleController.getDice(DicePhase.EnemyDefense);
                int playerDick = m_BattleController.getDice(DicePhase.PlayerAttack);
                return (dick < playerDick && CalculateOperatpor(dick) >= playerDick);
            }
        }
        else if(m_Operatpor == CardOperator.Subtract || m_Operatpor == CardOperator.Divide)
        {
            if (effectiveBlock == EffectiveBlock.PlayerAttackBlock || effectiveBlock == EffectiveBlock.PlayerDefenseBlock)
            {
                return true;
            }
        }

        return false;
    }

    private int CalculateOperatpor(int dick)
    {
        int ans = 0;
        switch (m_Operatpor)
        {
            case CardOperator.Add : ans = (int)((float)dick + m_Value); break;
            case CardOperator.Subtract : ans = (int)((float)dick - m_Value); break;
            case CardOperator.Multiply : ans = (int)((float)dick * m_Value); break;
            case CardOperator.Divide : ans = (int)((float)dick / m_Value); break;
        }

        return ans;
    }


    // public override string SerializeObject()
    // {
    //     return $"{m_Name},{m_Description},{m_MP},{m_Operatpor},{m_Value}";
    // }
}
