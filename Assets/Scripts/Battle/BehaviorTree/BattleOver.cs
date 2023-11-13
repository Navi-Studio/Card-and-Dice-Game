using System.Security.Cryptography;
using Battle;
using BehaviorDesigner.Runtime.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class BattleOver : Action
{
    [SerializeField] private GameObject m_BattleOverGO;
    [SerializeField] private PlayerOrEnemy m_PlayerOrEnemy;
    private Image m_Image;
    private TMP_Text m_Text;
    private TMP_Text m_Continue;
    private bool isPlayEnd = false;
    
    public override void OnAwake()
    {
        base.OnAwake();
        m_Image = m_BattleOverGO.GetComponent<Image>();
        m_Text = m_BattleOverGO.GetComponentsInChildren<TMP_Text>()[0];
        m_Continue = m_BattleOverGO.GetComponentsInChildren<TMP_Text>()[1];
    }

    public override void OnStart()
    {
        base.OnStart();
        if (m_PlayerOrEnemy == PlayerOrEnemy.Enemy)
        {
            m_BattleOverGO.SetActive(true);
            AudioSource audioSource = GameObject.FindGameObjectWithTag("BGM").GetComponent<AudioSource>();
            audioSource.clip = Resources.Load<AudioClip>($"Audio/Win");
            audioSource.Play();
            PlayerData.Instance.Golden += 20;
            m_Image.DOFade(0.8f, 2.5f).From(0f).OnComplete(() =>
            {
                isPlayEnd = true;
                m_Continue.text = "继续 ..";
                m_Continue.DOFade(0, 1f)
                    .SetEase(Ease.InOutFlash)
                    .SetLoops(-1, LoopType.Yoyo);
            });
        }
        else if (m_PlayerOrEnemy == PlayerOrEnemy.Player)
        {
            ToNextScene("GameOver");
        }
    }

    public override TaskStatus OnUpdate()
    {
        if (isPlayEnd)
        {
            if (Input.anyKeyDown)
            {
                ToNextScene("MainMap");
                return TaskStatus.Success;
            }
        }
        return TaskStatus.Running;
    }
    
    
    private void ToNextScene(string name)
    { 
        SceneManager.LoadScene(name);
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
    }
}
