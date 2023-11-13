using System.Collections;
using System.Collections.Generic;
using Battle.DiceSystem;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkipTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SkipScene()
    {
        
        SceneManager.LoadScene("MainMap");
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
    }
    
}
