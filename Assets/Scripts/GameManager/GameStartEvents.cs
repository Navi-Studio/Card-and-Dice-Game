using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStartEvents : MonoBehaviour
{
    public GameObject ResumeButton;
    
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {
        // 在游戏启动时删除PlayerPrefs缓存数据
        PlayerPrefs.DeleteAll();
    }

    public void ResumeGameEvent()
    {
        // TODO
        SceneManager.LoadScene("Prologue");
        string currentSceneName = SceneManager.GetActiveScene().name;
        StartCoroutine(UnloadSceneAsync(currentSceneName));
    }

    public void NewGameEvent()
    {
        // 存在缓存数据，进行删除操作
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("Prologue");
        string currentSceneName = SceneManager.GetActiveScene().name;
        StartCoroutine(UnloadSceneAsync(currentSceneName));
    }

    public void ExitGameEvent()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
    
    private IEnumerator UnloadSceneAsync(string sceneName)
    {
        AsyncOperation asyncOperation = SceneManager.UnloadSceneAsync(sceneName);
        yield return null;
        // while (!asyncOperation.isDone)
        // {
        //     yield return null;
        // }
    }
}
