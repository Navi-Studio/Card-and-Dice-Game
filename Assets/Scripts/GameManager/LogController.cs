
using UnityEngine;


public class LogController : MonoBehaviour
{
    public GameObject panel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenLog(){
        // open log window
        bool state = panel.activeSelf;
        panel.SetActive(!state);
    }

}