using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;

public class ItemData : SerializeSingleton<ItemData>
{
    private Dictionary<int, int> m_enumMap = new Dictionary<int, int>()
    {
        // 药剂， 强化， 强化2，迷雾
        { 1, 0 },
        { 2, 0 },
        { 3, 0 },
        { 4, 0 }
    };

    public Dictionary<int, int> enumMap { get => m_enumMap; }

    private ItemData()
    {
        m_enumMap[1] = 0;
        m_enumMap[2] = 0;
        m_enumMap[3] = 0;
        m_enumMap[4] = 0;
    }


}
