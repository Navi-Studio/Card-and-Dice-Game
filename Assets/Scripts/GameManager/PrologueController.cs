using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class PrologueController : MonoBehaviour
{
    private TMP_Text m_Text;
    private TMP_Text m_Continue;
    private bool isPlayEnd = false;
    
    
    // Start is called before the first frame update
    void Start()
    {
        m_Text = GetComponentsInChildren<TMP_Text>()[0];
        m_Continue = GetComponentsInChildren<TMP_Text>()[1];
        m_Continue.text = "";
        
        string text = m_Text.text;
        m_Text.text = "";
        m_Text.DOText(text, 10).OnComplete(() => {
            isPlayEnd = true;
            m_Continue.text = "继续 ..";
            m_Continue.DOFade(0, 1f)
                .SetEase(Ease.InOutFlash)
                .SetLoops(-1, LoopType.Yoyo);
        });
    }
    

    // Update is called once per frame
    void Update()
    {
        if (isPlayEnd)
        {
            if (Input.anyKeyDown)
            {
                ToNextScene();
            }
        }
    }
    
    private void ToNextScene()
    {
        m_Continue.text = "";
        m_Text.text = "第一章：义净之死";
        m_Text.fontSize = 80;
        m_Text.alignment = TextAlignmentOptions.Center;
            
        string text = m_Text.text;

        m_Text.DOScale(1.2f, 2).OnComplete(() =>
        {
            m_Text.DOFade(0f, 2).OnComplete(() =>
            {
                SceneManager.LoadScene("MainMap");
            });;
        });;
        
    }
}
