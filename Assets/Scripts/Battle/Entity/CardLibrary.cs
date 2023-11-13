using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using Unity.VisualScripting;


public class CardLibrary : Singleton<CardLibrary>
{
    private Dictionary<string, CardPool> m_CardLibrary = new Dictionary<string, CardPool>();

    private CardLibrary()
    {
        DeserializeCardLibrary();
    }
    
#if UNITY_EDITOR
    // private static readonly string k_SerializeFilePath = Application.dataPath + "/Data/CardLibrary.csv";
    private static readonly string k_SerializeFilePath = Application.dataPath + "/Data/CardLibrary.csv";
#else
    // private static readonly string k_SerializeFilePath = Application.persistentDataPath + "/Data/CardLibrary.csv";
    private static readonly string k_SerializeFilePath = Application.streamingAssetsPath + "/Data/CardLibrary.csv";
#endif
    
    public CardPool GetCardPoolByName(string name)
    {
        return m_CardLibrary[name].Clone();
    }
    
    // TODO test stub
    public void setDictionary(Dictionary<string, CardPool> d)
    {
        this.m_CardLibrary = d;
    }
    

    // public void SerializeCardLibrary()
    // {
    //     string filePath;
    //
    //     FileInfo fi = new FileInfo(k_SerializeFilePath);
    //     if (!fi.Directory.Exists)
    //     {
    //         fi.Directory.Create();
    //     }
    //     using (FileStream fs = new FileStream(k_SerializeFilePath, FileMode.Create, FileAccess.Write))
    //     {
    //         using (StreamWriter sw = new StreamWriter(fs, System.Text.Encoding.UTF8))
    //         {
    //             // CardLibrary CardPool Type Card<T>
    //             string strHead = "CardPool,Count,Type,Name,Description,MP,Operator,Value";
    //             sw.WriteLine(strHead);
    //             foreach (var item in m_CardLibrary)
    //             {
    //                 string strCardPool = item.Key;
    //                 CardPool cardPool = item.Value;
    //                 foreach (var dic in cardPool.GetDictionary())
    //                 {
    //                     string strCount = dic.Value.ToString();
    //                     Card card = dic.Key;
    //                     string strType = card.GetType().Name;
    //                     string strCard = card.SerializeObject();
    //                     sw.WriteLine($"{strCardPool},{strCount},{strType},{strCard}");
    //                 }
    //             }
    //             sw.Close();
    //             fs.Close();
    //         }
    //     }
    // }
    
    public void DeserializeCardLibrary()
    {
        if (File.Exists(k_SerializeFilePath))
        {
            if (m_CardLibrary != null)
            {
                m_CardLibrary.Clear();
            }

            
            string[] lines = File.ReadAllLines(k_SerializeFilePath);
            string strCardPool = "";
            
            for (int i=1;i<lines.Length;i++)
            {
                string[] data = lines[i].Split(',');
                strCardPool = data[0];
                if (!m_CardLibrary.ContainsKey(strCardPool))
                {
                    CardPool _cardPool = new CardPool(new Dictionary<Card, int>());
                    m_CardLibrary.Add(strCardPool, _cardPool);
                }
                int count = int.Parse(data[1]);
                Type type = Type.GetType(data[2]);
                List<object> objectList = new List<object>();
                for (int j = 3; j < data.Length; j++)
                {
                    if (!string.IsNullOrEmpty(data[j]))
                    {
                        objectList.Add(data[j]);
                    }
                }
                object[] para = objectList.ToArray();
                Card card = (Card)Activator.CreateInstance(type, para);
                m_CardLibrary[strCardPool].AddDictionary(card,count);
            }
        }
        else
        {
            Debug.LogError("Player data file not found!");
        }
    }
    
    
    // private string readCardClass
}
