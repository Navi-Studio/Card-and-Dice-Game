using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenStore()
    {
        // open log window
        bool state = gameObject.activeSelf;
        gameObject.SetActive(!state);
    }
}
