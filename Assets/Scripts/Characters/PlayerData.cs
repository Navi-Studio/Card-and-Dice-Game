using System.IO;
using Newtonsoft.Json;
using UnityEngine;

public class PlayerData : SerializeSingleton<PlayerData>
{
    private int m_HP;
    private int m_MP;
    private int m_ATK;
    private int m_DEF;

    private int m_HPMax;
    private int m_Golden;
    
    public int HP { get => m_HP; set => m_HP = value > m_HPMax?m_HPMax:value; }
    public int MaxHP { get => m_HPMax; set => m_HPMax = value; }
    public int MP { get => m_MP; set => m_MP = value; }
    public int ATK { get => m_ATK; set => m_ATK = value; }
    public int DEF { get => m_DEF; set => m_DEF = value; }
    public int Golden { get => m_Golden; set => m_Golden = value; }

    private PlayerData()
    {
        m_HPMax = 80;
        m_Golden = 100;
        m_HP = 80;
        m_MP = 4;
        m_ATK = 2;
        m_DEF = 2;
    }

    
}
