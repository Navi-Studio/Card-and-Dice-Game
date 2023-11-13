using System;
using UnityEngine;
using Random = UnityEngine.Random;

public enum DiceType
{
    D6 = 6,
    D12 = 12
}

public class Dice
{
    private int m_Value;
    private DiceType m_DiceType;

    public int value { get => m_Value; set => m_Value = value; }
    public DiceType diceType { get => m_DiceType; set => m_DiceType = value; }

    public Dice()
    {
    }

    public Dice(DiceType mDiceType)
    {
        m_DiceType = mDiceType;
    }

    // public void RollDiceOnce()
    // {
    //     m_Value = Random.Range(1, (int)m_DiceType + 1);
    // }
    //
    // public void RollDiceOnce(DiceType diceType)
    // {
    //     m_Value = Random.Range(1, (int)diceType + 1);
    // }
}
