using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StorePanel : MonoBehaviour
{

    public List<GameObject> Goods;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateStore()
    {

        if (10 <= PlayerData.Instance.Golden)
        {
            PlayerData.Instance.Golden -= 10;
            foreach (var obj in Goods)
            {
                //obj.SetActive(false);
                //obj.SetActive(true);
                obj.GetComponent<GoodsBuy>().reStart();
            }
        }
    }
}
