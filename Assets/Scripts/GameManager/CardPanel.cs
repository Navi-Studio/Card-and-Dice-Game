using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardPanel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // foreach grid and add component
        // list from ItemsData
        // create random golden to text
        int itemnums = ItemData.Instance.enumMap[1]
                        + ItemData.Instance.enumMap[2]
                        + ItemData.Instance.enumMap[3]
                        + ItemData.Instance.enumMap[4];

        List<int> items = new List<int>();
        for(int i = 1; i <= 4; i++)
        {
            for (int j = 0; j < ItemData.Instance.enumMap[i]; j++)
            {
                items.Add(i);
            }
        }

        int gridNums = itemnums > 16 ? 16 : itemnums;
        // get grid
        Transform[] children = gameObject.GetComponentsInChildren<Transform>();
        List<Transform> grids = new List<Transform>();

        // 遍历子Transform
        foreach (Transform child in children)
        {
            // 检查子Transform是否有Text组件
            if (child.name.Contains("Grid"))
            {
                grids.Add(child);
            }
        }

        for (int i = 0; i < gridNums; i++)
        {
            string itemName;
            // grid i
            switch (items[i])
            {
                case 1:
                    itemName = "Healling";
                    break;
                case 2:
                    itemName = "Healling";
                    break;
                case 3:
                    itemName = "Healling";
                    break;
                case 4:
                    itemName = "Healling";
                    break;
                default:
                    itemName = "Healling";
                    break;
            }
            grids[i].GetComponent<Image>();
            grids[i].GetComponent<Button>();
        }
    }
}
