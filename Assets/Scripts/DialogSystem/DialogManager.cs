using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogManager : MonoBehaviour
{
    /// <summary>
    /// 对话文本文件，csv
    /// </summary>
    public TextAsset dialogDataFile;

    /// <summary>
    /// 左侧角色图像
    /// </summary>
    public SpriteRenderer spriteLeft;

    /// <summary>
    /// 左侧角色图像
    /// </summary>
    public SpriteRenderer spriteRight;

    /// <summary>
    /// 角色名字文本
    /// </summary>
    public TMP_Text nameText;

    /// <summary>
    /// 对话内容文本
    /// </summary>
    public TMP_Text dialogText;

    public List<Sprite> sprites = new List<Sprite>();

    Dictionary<string, Sprite> imageDic = new Dictionary<string, Sprite>();
    private void Awake()
    {
        imageDic["player"] = sprites[0];

    }
    // Start is called before the first frame update
    void Start()
    {
        UpdateText("player", "To begin, you need to create a custom class that you can create a custom inspector for, which is either a MonoBehaviour or a ScriptableObject. This guide works with a MonoBehaviour script that represents a simple car with properties, such as model and color.");
        UpdateImage("player", true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateText(string _name, string _text)
    {
        nameText.text = _name;
        dialogText.text = _text;
    }

    public void UpdateImage(string _name, bool _atLeft)
    {
        if(_atLeft)
        {
            spriteRight.sprite = imageDic[_name];
        }
        else
        {
            spriteRight.sprite = imageDic[_name];
        }
    }
}
