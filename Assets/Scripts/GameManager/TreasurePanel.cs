using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TreasurePanel : MonoBehaviour
{
    private int treasure;
    // Start is called before the first frame update
    void Start()
    {
        treasure = Random.Range(10, 50);
        gameObject.GetComponentInChildren<TMP_Text>().text = "获得金币奖励：" + treasure.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetTreasure()
    {
        // get num
        //TMP_Text nums = gameObject.GetComponentInChildren<TMP_Text>();
        //int number = int.Parse(nums.text.ToString());
        PlayerData.Instance.Golden += treasure;
        bool state = gameObject.activeSelf;
        gameObject.SetActive(!state);
    }
}
