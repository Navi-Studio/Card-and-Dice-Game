using System.IO;
using Newtonsoft.Json;
using UnityEngine;

public class SerializeSingleton<T> where T : class
{
    protected static T instance;
    
#if UNITY_EDITOR
    static readonly string k_SerializeFilePath = Application.dataPath + "/Data/"+ typeof(T).ToString() +".json";
#else
    static readonly string k_SerializeFilePath = Application.persistentDataPath + "/Data/"+ typeof(T).ToString() +".json";
#endif   
    
    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                if (File.Exists(k_SerializeFilePath))
                {
                    instance = DeserializePlayerData();
                }
                else
                {
                    instance = (T)System.Activator.CreateInstance(typeof(T), true);
                    SerializePlayerData();
                }
                
            }
            return instance;
        }
    }
    
    
    protected static void SerializePlayerData()
    {
        string json = JsonConvert.SerializeObject(instance);
        if (!Directory.Exists(Path.GetDirectoryName(k_SerializeFilePath)))
        {
            Directory.CreateDirectory(Path.GetDirectoryName(k_SerializeFilePath));
        }
        File.WriteAllText(k_SerializeFilePath, json);
    }
    
    protected static T DeserializePlayerData()
    {
        string json = File.ReadAllText(k_SerializeFilePath);
        return JsonConvert.DeserializeObject<T>(json);
    }

}
