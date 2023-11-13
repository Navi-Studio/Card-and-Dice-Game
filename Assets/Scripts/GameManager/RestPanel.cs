using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RestPanel : MonoBehaviour
{
    private int treasure;
    // Start is called before the first frame update
    void Start()
    {
        treasure = Random.Range(10, 20);
        gameObject.GetComponentInChildren<TMP_Text>().text = "休息回复生命值：" + treasure.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetHP()
    {
        // get num
        //TMP_Text nums = gameObject.GetComponentInChildren<TMP_Text>();
        //int number = int.Parse(nums.text.ToString());
        PlayerData.Instance.HP += treasure;
        bool state = gameObject.activeSelf;
        gameObject.SetActive(!state);
    }
}
