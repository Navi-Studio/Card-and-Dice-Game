using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitGameEvent : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void ExitGame(){
#if UNITY_EDITOR    // 调试时
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
    
}
