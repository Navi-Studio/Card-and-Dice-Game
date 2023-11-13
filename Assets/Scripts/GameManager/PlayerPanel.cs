using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerPanel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        // foreach name
        // 获取父GameObject的所有子Transform
        Transform[] children = gameObject.GetComponentsInChildren<Transform>();

        // 遍历子Transform
        foreach (Transform child in children)
        {
            var name = child.name;
            // 检查子Transform是否有Text组件
            TMP_Text textComponent = child.GetComponent<TMP_Text>();
            if (textComponent != null)
            {
                // 找到了Text组件
                // 在这里可以对textComponent进行操作
                if(name == "HP") textComponent.text = $"血量:{PlayerData.Instance.HP.ToString()}/{PlayerData.Instance.MaxHP.ToString()}" ;
                if(name == "MP") textComponent.text = "能量:" + PlayerData.Instance.MP.ToString();
                if(name == "ATK") textComponent.text = "攻击力:" + PlayerData.Instance.ATK.ToString();
                if(name == "DEF") textComponent.text = "防御力:" + PlayerData.Instance.DEF.ToString();
                if(name == "Golden") textComponent.text = "金币:" + PlayerData.Instance.Golden.ToString();
            }
        }
    }

    public void OpenPlayer()
    {
        // open log window
        bool state = gameObject.activeSelf;
        gameObject.SetActive(!state);
    }
}
