using System;
using System.Collections.Generic;
using Battle;

public enum EffectiveBlock
{
    PlayerAttackBlock = 0,
    PlayerDefenseBlock = 1,
    EnemyAttackBlock = 2,
    EnemyDefenseBlock = 3,
    Player = 4,
    Enemy = 5,
    DropBlock = 6
}

public abstract class Card
{
    protected string m_Name;
    protected string m_Description;
    protected int m_MP;
    protected List<EffectiveBlock> m_EffectiveBlocks;
    protected BattleController m_BattleController = BattleController.Instance;
    
    public string name { get => m_Name; }
    public string description { get => m_Description; }
    public int mp { get => m_MP; }
    public List<EffectiveBlock> effectiveBlocks { get => m_EffectiveBlocks; }
    
    public Card(string _Name, string _Description, string _MP)
    {
        this.m_Name = _Name;
        this.m_Description = _Description;
        
        try
        {
            this.m_MP = int.Parse(_MP);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public abstract Card Clone();
    
    public abstract void CalculateCardEffects(EffectiveBlock effectiveBlock);
    
    /**
     * Determine if there is a positive gain for the enemy ?
     */
    public abstract bool GainJudgment(EffectiveBlock effectiveBlock);

    // public abstract string SerializeObject();
}