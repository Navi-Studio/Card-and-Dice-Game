using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdateStore : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponentInChildren<TMP_Text>().text = PlayerData.Instance.Golden.ToString();
    }
}
