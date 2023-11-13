using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GoodsBuy : MonoBehaviour
{
    private int goodsID;
    private string goodsName;
    private int goodsPrice;
    private Sprite goodsImg;

    private Dictionary<int, string> m_enumName = new Dictionary<int, string>()
    {
        // HP, MaxHP, MaxMp, atk, def
        { 0, "HP" },
        { 1, "MaxHP" },
        { 2, "MaxMP" },
        { 3, "ATK" },
        { 4, "DEF" }
    };
    private Dictionary<int, int> m_enumPrice = new Dictionary<int, int>()
    {
        { 0, 10 },
        { 1, 20 },
        { 2, 20 },
        { 3, 20 },
        { 4, 20 }
    };

    public List<Sprite> itemsImg = new List<Sprite>();

    // Start is called before the first frame update
    void Start()
    {
        //gameObject.GetComponentInChildren<Button>().interactable = true;
        //goodsID = Random.Range(0, 5);
        //if (goodsID == 2) goodsID = 0;
        //goodsName = m_enumName[goodsID];
        //goodsPrice = m_enumPrice[goodsID];
        //goodsImg = itemsImg[goodsID];
        //gameObject.GetComponent<Image>().sprite = goodsImg;

        ////gameObject.GetComponentInChildren<TMP_Text>().text = goodsName + "+1: " + goodsPrice.ToString();
        //if (goodsName == "HP")
        //{
        //    gameObject.GetComponentInChildren<TMP_Text>().text = "生命值+1: " + goodsPrice.ToString() + "\n购买";
        //}
        //else if (goodsName == "MaxHP")
        //{
        //    gameObject.GetComponentInChildren<TMP_Text>().text = "生命值上限+1: " + goodsPrice.ToString() + "\n购买";
        //}
        //else if (goodsName == "MaxMP")
        //{
        //    gameObject.GetComponentInChildren<TMP_Text>().text = "能量值+1: " + goodsPrice.ToString() + "\n购买";
        //}
        //else if (goodsName == "ATK")
        //{
        //    gameObject.GetComponentInChildren<TMP_Text>().text = "攻击+1: " + goodsPrice.ToString() + "\n购买";
        //}
        //else if (goodsName == "DEF")
        //{
        //    gameObject.GetComponentInChildren<TMP_Text>().text = "防御+1: " + goodsPrice.ToString() + "\n购买";
        //}
        reStart();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void reStart()
    {
        gameObject.GetComponentInChildren<Button>().interactable = true;
        goodsID = Random.Range(0, 5);
        if (goodsID == 2) goodsID = 0;
        goodsName = m_enumName[goodsID];
        goodsPrice = m_enumPrice[goodsID];
        goodsImg = itemsImg[goodsID];
        gameObject.GetComponent<Image>().sprite = goodsImg;
        //gameObject.GetComponentInChildren<TMP_Text>().text = goodsName + "+1: " + goodsPrice.ToString();
        if (goodsName == "HP")
        {
            gameObject.GetComponentInChildren<TMP_Text>().text = "生命值+1: " + goodsPrice.ToString() + "\n购买";
        }
        else if (goodsName == "MaxHP")
        {
            gameObject.GetComponentInChildren<TMP_Text>().text = "生命值上限+1: " + goodsPrice.ToString() + "\n购买";
        }
        else if (goodsName == "MaxMP")
        {
            gameObject.GetComponentInChildren<TMP_Text>().text = "能量值+1: " + goodsPrice.ToString() + "\n购买";
        }
        else if (goodsName == "ATK")
        {
            gameObject.GetComponentInChildren<TMP_Text>().text = "攻击+1: " + goodsPrice.ToString() + "\n购买";
        }
        else if (goodsName == "DEF")
        {
            gameObject.GetComponentInChildren<TMP_Text>().text = "防御+1: " + goodsPrice.ToString() + "\n购买";
        }
    }    

    public void Buy()
    {
        // 商品生效
        //gameObject.GetComponent
        //if (goodsName == "HP")
        //{
        //    if (goodsPrice <= PlayerData.Instance.Golden)
        //    {
        //        PlayerData.Instance.Golden -= goodsPrice;
        //        PlayerData.Instance.HP += 1;
        //        gameObject.GetComponent<Image>().sprite = goodsImg;
        //        gameObject.GetComponentInChildren<Button>().interactable = false;
        //    }
        //}
        //else if (goodsName == "MaxHP")
        //{
        //    if (goodsPrice <= PlayerData.Instance.Golden)
        //    {
        //        PlayerData.Instance.Golden -= goodsPrice;
        //        PlayerData.Instance.MaxHP += 1;
        //        gameObject.GetComponentInChildren<Button>().interactable = false;
        //    }
        //}
        //else if (goodsName == "MaxMP")
        //{
        //    if (goodsPrice <= PlayerData.Instance.Golden)
        //    {
        //        PlayerData.Instance.Golden -= goodsPrice;
        //        PlayerData.Instance.MP += 1;
        //        gameObject.GetComponentInChildren<Button>().interactable = false;
        //    }
        //}
        //else if (goodsName == "ATK")
        //{
        //    if (goodsPrice <= PlayerData.Instance.Golden)
        //    {
        //        PlayerData.Instance.Golden -= goodsPrice;
        //        PlayerData.Instance.ATK += 1;
        //        gameObject.GetComponentInChildren<Button>().interactable = false;
        //    }
        //}
        //else if (goodsName == "DEF")
        //{
        //    if (goodsPrice <= PlayerData.Instance.Golden)
        //    {
        //        PlayerData.Instance.Golden -= goodsPrice;
        //        PlayerData.Instance.DEF += 1;
        //        gameObject.GetComponentInChildren<Button>().interactable = false;
        //    }
        //}
        //gameObject.GetComponentInChildren<Button>().interactable = false;
        if (goodsPrice <= PlayerData.Instance.Golden)
        {
            if (goodsName == "HP")
            {
                PlayerData.Instance.HP += 1;
            }
            else if (goodsName == "MaxHP")
            {
                PlayerData.Instance.MaxHP += 1;
            }
            else if (goodsName == "MaxMP")
            {
                PlayerData.Instance.MP += 1;
            }
            else if (goodsName == "ATK")
            {
                PlayerData.Instance.ATK += 1;
            }
            else if (goodsName == "DEF")
            {
                PlayerData.Instance.DEF += 1;
            }
            PlayerData.Instance.Golden -= goodsPrice;
            //gameObject.GetComponent<Image>().sprite = goodsImg;
            gameObject.GetComponentInChildren<Button>().interactable = false;
        }
    }
}
