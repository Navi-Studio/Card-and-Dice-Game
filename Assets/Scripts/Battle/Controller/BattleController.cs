using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Battle.Cards.Player;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Random = UnityEngine.Random;
using DG.Tweening;
using Live2D.Cubism.Framework.Json;
using UnityEngine.SceneManagement;


public enum BattlePhase
{
    BattleStart,
    DiceTurn = 0,
    PlayerTurn = 1,
    EnemyTurn = 2,
    SettlementTurn = 3
}



public enum DicePhase
{
    PlayerAttack = 0,
    PlayerDefense = 1,
    EnemyAttack = 2,
    EnemyDefense = 3,
    PlayerAttackFirst = 4,
    EnemyAttackFirst = 5,
}

public enum PlayerOrEnemy
{
    Player = 0,
    Enemy = 1
}

namespace Battle
{
    public class BattleController : MonoSingleton<BattleController>
    {
        private CardPool m_PlayerCardPool;
        private CardPool m_EnemyCardPool;
        private List<Card> m_PlayerHands = new List<Card>();
        private List<Card> m_EnemyHands = new List<Card>();
        private List<Card> m_PlayerDropList = new List<Card>();
        private List<Card> m_EnemyDropList = new List<Card>();
        private Card[] m_CardBlocks = new Card[7];
        private int[] m_Dices = new int[4];
        private BattlePhase m_BattlePhase;
        private int m_RoundNumber;
        private string m_EnemyName;


        // load data
        private int m_PlayerHP;
        private static int k_MaxPlayerHP;
        private int m_EnemyHP;
        private static int k_MaxEnemyHP;
        private int m_PlayerMP;
        private static int k_MaxPlayerMP;
        private int m_EnemyMP;
        private static int k_MaxEnemyMP;

        [SerializeField] private AudioSource[] m_AudioSource = new AudioSource[2];
        [SerializeField]private GameObject m_CardPrefab;
        [SerializeField]private GameObject m_PlayerHandsGO;
        [SerializeField]private GameObject m_BuffPrefab;
        [SerializeField]private GameObject m_PlayerBuffGO;
        [SerializeField]private GameObject m_EnemyBuffGO;
        [Tooltip("PlayerAttack PlayerDefense EnemyAttack EnemyDefense PlayerAttackFirst EnemyAttackFirst")]
        [SerializeField]private GameObject[] m_DiceBlocksGO = new GameObject[6];
        [Tooltip("PlayerAttack PlayerDefense EnemyAttack EnemyDefense Player Enemy DropBlock")]
        [SerializeField]private GameObject[] m_CardBlocksGO = new GameObject[7];   
        [SerializeField]private Text m_RoundTextGO;  
        [SerializeField]private Transform m_PlayerMPGO;
        [SerializeField]private Transform m_EnemyMPGO;
        public Slider m_PlayerSliderGO;
        public Slider m_EnemySliderGO;
        
        private TMP_Text m_PlayerSliderText;
        private TMP_Text m_EnemySliderText;
        private GameObject[] m_CardInBlocksGO = new GameObject[6];
        private GameObject m_PlayerDataGO;
        public GameObject m_EnemyDataGO;
        private Dictionary<string, GameObject> m_BuffsGO = new Dictionary<string, GameObject>();
        
        
        public enum BattlePhaseEvents
        {
            OnBattleStartTrigger,
            OnDiceTurnEndTrigger,
            OnPlayerStartTurnTrigger,
            OnEnemyTurnStartTrigger,
            OnEnemyTurnEndTrigger,
            OnSettlementTurnTrigger
        }
        public Action[] OnBattlePhaseEvents = new Action[6];

        public event Action OnUpdateTrigger;

        public void TriggerEvents(BattlePhaseEvents _battlePhaseEvents)
        {
            OnBattlePhaseEvents[(int)_battlePhaseEvents]?.Invoke();
        }

        static int k_PlayerHandsMaxCount = 3;
        
        
        public string enemyName { get => m_EnemyName; }
        public CardPool enemyCardPool { get => m_EnemyCardPool; }
        public GameObject[] cardBlocks { get => m_CardBlocksGO; }
        public GameObject cardPrefab { get => m_CardPrefab; }
        public GameObject playerHandsGO { get => m_PlayerHandsGO; }
        public Dictionary<string, GameObject> buffsGO { get => m_BuffsGO; set => m_BuffsGO = value; }
        public void RemovePlayerHandsCard(Card card) { m_PlayerHands.Remove(card); }
        public BattlePhase battlePhase { get => m_BattlePhase; set => m_BattlePhase = value; }
        public int playerHP {
            get => m_PlayerHP;
            set
            {
                int _value = value <= k_MaxPlayerHP ? value : k_MaxPlayerHP;
                if (_value < m_PlayerHP)
                {
                    int randomInt = Random.Range(1, 3);
                    m_AudioSource[0].clip = Resources.Load<AudioClip>($"Audio/PlayerHurt{randomInt}");
                    m_AudioSource[0].Play();
                }
                m_PlayerHP = _value;
                PlayerData.Instance.HP = _value;
                Image image = m_PlayerDataGO.GetComponentsInChildren<Image>()[0];
                image.transform.DOShakePosition(1f, 0.3f).SetDelay(0.5f).OnComplete(() =>
                {
                    // image.fillAmount = (k_MaxPlayerHP-_value) / (float)k_MaxPlayerHP;
                    DOTween.To(() => image.fillAmount, x =>image.fillAmount = x, (float)(k_MaxPlayerHP-_value) / (float)k_MaxPlayerHP, 0.5f)
                        .SetEase(Ease.OutSine);
                });
                
            }
        }
        public int enemyHP {
            get => m_EnemyHP;
            set
            {
                int _value = value <= k_MaxEnemyHP ? value : k_MaxEnemyHP;
                if (_value < m_EnemyHP)
                {
                    m_AudioSource[1].clip = Resources.Load<AudioClip>($"Audio/{enemyName}");
                    m_AudioSource[1].Play();
                }
                m_EnemyHP = _value;
                m_EnemyDataGO.GetComponentInChildren<Text>().text = _value.ToString();
                DOTween.To(() => m_EnemyDataGO.GetComponentInChildren<Slider>().value, x =>m_EnemyDataGO.GetComponentInChildren<Slider>().value = x, (float)(value / (float)maxEnemyHP), 0.5f)
                    .SetEase(Ease.OutSine);
            }
        }
        public int playerMP {
            get => m_PlayerMP;
            set
            {
                int _value = value <= k_MaxPlayerMP ? value : k_MaxPlayerMP;
                m_PlayerMP = _value;
                for (int i = 0; i < m_PlayerMPGO.childCount; i++)
                {
                    m_PlayerMPGO.GetChild(i).gameObject.SetActive(i < _value);
                }
            }
        }
        public int enemyMP {
            get => m_EnemyMP;
            set
            {
                int _value = value <= k_MaxEnemyMP ? value : k_MaxEnemyMP;
                m_EnemyMP = _value;
                for (int i = 0; i < m_EnemyMPGO.childCount; i++)
                {
                    m_EnemyMPGO.GetChild(i).gameObject.SetActive(i < _value);
                }
            }
        }
        public int maxEnemyHP { get => k_MaxEnemyHP; }
        public int maxEnemyMP { get => k_MaxEnemyMP; }
        public int getDice(DicePhase dicePhase) { return m_Dices[(int)dicePhase]; }
        public void setDice(DicePhase dicePhase, int value)
        {
            m_Dices[(int)dicePhase] = value;
            m_DiceBlocksGO[(int)dicePhase].GetComponentInChildren<Text>().text = value.ToString();

            float playerPercent = getStrengthSlider(getDice(DicePhase.PlayerAttack), getDice(DicePhase.EnemyDefense));
            float enemyPercent = getStrengthSlider(getDice(DicePhase.EnemyAttack), getDice(DicePhase.PlayerDefense));
            if (Math.Abs(playerPercent - 0.5f) < 0.00001f)
            {
                m_PlayerSliderText.text = "均势";
            }
            else if (playerPercent < 0.5f)
            {
                m_PlayerSliderText.text = "劣势";
            }
            else
            {
                m_PlayerSliderText.text = "优势";
            }
            
            if (Math.Abs(enemyPercent - 0.5f) < 0.00001f)
            {
                m_EnemySliderText.text = "均势";
            }else if (enemyPercent > 0.5f)
            {
                m_EnemySliderText.text = "劣势";
            }
            else
            {
                m_EnemySliderText.text = "优势";
            }
            
            DOTween.To(() => m_PlayerSliderGO.value, x => m_PlayerSliderGO.value = x, playerPercent, 0.5f)
                .SetEase(Ease.InQuad);
            DOTween.To(() => m_EnemySliderGO.value, x => m_EnemySliderGO.value = x,enemyPercent , 0.5f)
                .SetEase(Ease.InQuad);
        }

        public float getStrengthSlider(float attack, float defence)
        {
            float total = attack + defence;
            total = total > 0 ? total : 0.00001f;
            float value = 0;
            if (defence <= 0 && attack > 0)
            {
                value = 1f;
            }
            if (attack <= 0 && defence > 0)
            {
                value = 0f;
            }
            else if (attack == 0 && attack == 0)
            {
                value = 0.5f;
            }
            else
            {
                value = attack / total;
            }
            
            return value;
        }
        
        public void setDiceHighLight(DicePhase dicePhase, bool isActive)
        {
            Transform[] children = m_DiceBlocksGO[(int)dicePhase].GetComponentsInChildren<Transform>(true);
            foreach (Transform child in children)
            {
                if (child.name == "Highlight")
                {
                    child.gameObject.SetActive(isActive);
                    break;
                }
            }
        }
        public int roundNumber
        {
            get => m_RoundNumber;
            set
            {
                m_RoundNumber = value;
                m_RoundTextGO.text = "Round " + m_RoundNumber;
            }
        }

        private void Start()
        {
            LoadBattleData();
            m_BattlePhase = BattlePhase.BattleStart;
            roundNumber = 0;
            for (int i = 0; i < m_Dices.Length; i++)
            {
                setDice((DicePhase)i,0);
            }
            AddBuff(new FeaturePlayer(null,null,null));
        }

        private void Update()
        {
            OnUpdateTrigger?.Invoke();
            
        }

        private void LoadBattleData()
        {
            m_PlayerDataGO = m_CardBlocksGO[(int)EffectiveBlock.Player].transform.parent.gameObject;
            m_EnemyDataGO = m_CardBlocksGO[(int)EffectiveBlock.Enemy].transform.parent.gameObject;
            // m_PlayerDataGO.GetComponentsInChildren<Text>()[1].text = PlayerData.Instance.ATK.ToString();
            // m_PlayerDataGO.GetComponentsInChildren<Text>()[2].text = PlayerData.Instance.DEF.ToString();
            k_MaxPlayerHP = PlayerData.Instance.HP;
            playerHP = k_MaxPlayerHP;
            k_MaxPlayerMP = PlayerData.Instance.MP;
            playerMP = k_MaxPlayerMP;
            k_MaxEnemyHP = 10;  // TODO
            k_MaxEnemyMP = 4;   // TODO
            CardLibrary cardLibrary = CardLibrary.Instance;
            string sceneName = SceneManager.GetActiveScene().name;
            Color nameColor = Color.white;
            switch (sceneName)
            {
                case "C1B1" :
                    m_EnemyName = "妖怪";
                    k_MaxEnemyHP = 15;
                    break;
                case "C1B2" : 
                    m_EnemyName = "鬼马龙一";
                    k_MaxEnemyHP = 25;
                    break;
                case "C1B3" : 
                    m_EnemyName = "窄袖观音";
                    k_MaxEnemyHP = 40;
                    break;
                case "C1B4" : 
                    m_EnemyName = "大傩";
                    k_MaxEnemyHP = 30;
                    nameColor = Color.red;
                    break;
                default:
                    m_EnemyName = "窄袖观音";
                    k_MaxEnemyHP = 10;
                    break;
            }
            m_EnemyCardPool = cardLibrary.GetCardPoolByName(m_EnemyName);
            m_EnemyDataGO.GetComponentsInChildren<TMP_Text>()[0].text = m_EnemyName;
            m_EnemyDataGO.GetComponentsInChildren<TMP_Text>()[0].color = nameColor;
            enemyHP = k_MaxEnemyHP;
            enemyMP = k_MaxEnemyMP;
            m_PlayerCardPool = cardLibrary.GetCardPoolByName("季渊");
            // m_PlayerCardPool = cardLibrary.GetCardPoolByName("鬼马龙一"); // Test Enemy Cards
            m_PlayerSliderText = m_PlayerSliderGO.GetComponentInChildren<TMP_Text>();
            m_EnemySliderText = m_EnemySliderGO.GetComponentInChildren<TMP_Text>();
        }

        public void TurnStart()
        {
            if (roundNumber == 2 && enemyName == "窄袖观音")
            {
                GameObject.FindGameObjectWithTag("UI").transform.DOShakePosition(6, 2f).SetEase(Ease.Linear);
                GameObject.FindGameObjectWithTag("MainCamera").transform.DOShakePosition(6, 2f).SetEase(Ease.Linear).OnComplete(() =>
                {
                    SceneManager.LoadScene("C1B4");
                    SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
                });
            }
            playerMP += 2;
            enemyMP += 2;
            roundNumber++;
            for (int i = 0; i < m_Dices.Length; i++)
            {
                setDice((DicePhase)i,0);
            }
            for (int i = 0; i < m_CardInBlocksGO.Length; i++)
            {
                if (m_CardInBlocksGO[i] != null)
                {
                    DropCard(m_CardInBlocksGO[i]);
                }
            }
            m_BattlePhase = BattlePhase.PlayerTurn;
            DrawCard(2);
        }
        
        public void DrawCard(int count = 1)
        {
            if(count == 0)return;
            if (m_PlayerHands.Count < k_PlayerHandsMaxCount)
            {
                Card card = m_PlayerCardPool.DrawCardRandomly();
                if (card == null)
                {
                    // TODO cardpool has none card
                    Debug.Log("none card!");
                }
                else
                {
                    m_PlayerHands.Add(card);
                    // create Card
                    GameObject newCard = GameObject.Instantiate(m_CardPrefab, m_PlayerDataGO.transform);
                    Sprite sprite = Resources.Load<Sprite>($"Card/{card.GetType().Name}");
                    if (sprite != null)
                    {
                        newCard.GetComponentsInChildren<Image>()[0].sprite = sprite;
                    }
                    newCard.GetComponentsInChildren<TMP_Text>()[0].text = card.name;
                    newCard.GetComponentsInChildren<TMP_Text>()[1].text = card.mp.ToString();
                    
                    newCard.GetComponent<CardController>().card = card;
                    newCard.GetComponent<CardController>().cardOwner = CardOwner.PlayerHands;
                    newCard.transform.DOMove(m_PlayerHandsGO.transform.position,1) .OnComplete(() =>
                    {
                        newCard.transform.parent = m_PlayerHandsGO.transform;
                        DrawCard(count--);
                    });
                  
                }
            }
            
        }

        

        public void DropCard(GameObject cardGO)
        {
            if (cardGO != null)
            {
                Card card = cardGO.GetComponent<CardController>().card;
                cardGO.GetComponent<CardController>().cardOwner = CardOwner.DropPool;
                cardGO.transform.SetParent(m_CardBlocksGO[(int)EffectiveBlock.DropBlock].transform);
                cardGO.SetActive(false);
                m_PlayerDropList.Add(card);
            }
        }
        
        
        public bool PlayCard(GameObject cardGO, EffectiveBlock effectiveBlock)
        {
            Card card = cardGO.GetComponent<CardController>().card;
            switch (effectiveBlock)
            {
                case EffectiveBlock.PlayerAttackBlock : 
                case EffectiveBlock.PlayerDefenseBlock : 
                case EffectiveBlock.EnemyAttackBlock : 
                case EffectiveBlock.EnemyDefenseBlock:
                {
                    if (m_BattlePhase == BattlePhase.PlayerTurn && card.mp <= playerMP)
                    {
                        playerMP -= card.mp;
                        PlayCardInDiceBlock(cardGO,effectiveBlock);
                    }
                    else if(m_BattlePhase == BattlePhase.EnemyTurn && card.mp <= enemyMP)
                    {
                        enemyMP -= card.mp;
                        PlayCardInDiceBlock(cardGO,effectiveBlock);
                    }
                    else
                    {
                        return false;
                    }
                    break;
                }
                case EffectiveBlock.Player:
                case EffectiveBlock.Enemy:
                {
                    if (m_BattlePhase == BattlePhase.PlayerTurn && card.mp <= playerMP)
                    {
                        playerMP -= card.mp;
                        // PlayCardInDataBlock(cardGO,effectiveBlock);
                        PlayCardInDiceBlock(cardGO,effectiveBlock);
                    }                    
                    else if(m_BattlePhase == BattlePhase.EnemyTurn && card.mp <= enemyMP)
                    {
                        enemyMP -= card.mp;
                        // PlayCardInDataBlock(cardGO,effectiveBlock);
                        PlayCardInDiceBlock(cardGO,effectiveBlock);
                    }
                    else
                    {
                        return false;
                    }
                    break;
                }
                case EffectiveBlock.DropBlock:
                {
                    m_PlayerHands.Remove(card);
                    // cardGO.GetComponent<CardController>().cardOwner = CardOwner.DropPool;
                    DropCard(cardGO);
                    break;
                }
            }
            return true;
        }
        
        

        public void PlayCardInDiceBlock(GameObject cardGO, EffectiveBlock effectiveBlock)
        {
            Card card = cardGO.GetComponent<CardController>().card;
            if (m_CardInBlocksGO[(int)effectiveBlock] != null)
            {
                DropCard(m_CardInBlocksGO[(int)effectiveBlock]);
            }
            m_CardBlocks[(int)effectiveBlock] = card;
            m_PlayerHands.Remove(card);
            cardGO.GetComponent<CardController>().cardOwner = CardOwner.CardBlock;
            cardGO.transform.SetParent(m_CardBlocksGO[(int)effectiveBlock].transform);
            cardGO.transform.localScale = Vector3.one;
            m_CardInBlocksGO[(int)effectiveBlock] = cardGO;
            // Calculate
            card.CalculateCardEffects(effectiveBlock);
            if (card.GetType().IsDefined(typeof(BuffAttribute), inherit: true))
            {
                AddBuff(card);
            }
        }
        
        // private void PlayCardInDataBlock(GameObject cardGO, EffectiveBlock effectiveBlock)
        // {
        //     Card card = cardGO.GetComponent<CardController>().card;
        //     m_PlayerHands.Remove(card);
        //     // Calculate
        //     card.CalculateCardEffects(effectiveBlock);
        //     DropCard(cardGO);
        // }
        
        public void ControlBlockHighLight(Card card, bool isShow)
        {
            foreach (var effectiveBlock in card.effectiveBlocks)
            {
                if (isShow)
                {
                    m_CardBlocksGO[(int)effectiveBlock].GetComponent<CardBlockScript>().ShowHighLight();
                }
                else
                {
                    m_CardBlocksGO[(int)effectiveBlock].GetComponent<CardBlockScript>().CloseHighLight();
                }
            }
        }

        public void AddBuff(Card card)
        {
            BuffAttribute attribute = (BuffAttribute)Attribute.GetCustomAttribute(card.GetType(), typeof(BuffAttribute));
            BuffInterface buff = card as BuffInterface;

            if (m_BuffsGO.ContainsKey(attribute.buffName))
            {
                TMP_Text[] textGO = m_BuffsGO[attribute.buffName].transform.GetComponentsInChildren<TMP_Text>();
                textGO[1].text = (int.Parse(textGO[1].text) + attribute.duration).ToString();
            }
            else
            {
                GameObject parent = attribute.playerOrEnemy == PlayerOrEnemy.Player ? m_PlayerBuffGO : m_EnemyBuffGO;
                GameObject newBuffGO = GameObject.Instantiate(m_BuffPrefab, parent.transform);
                newBuffGO.GetComponent<BuffController>().card = card;
                TMP_Text[] textGO = newBuffGO.transform.GetComponentsInChildren<TMP_Text>(true);
                textGO[0].text = attribute.buffName;
                textGO[1].text = attribute.duration.ToString();
                if (attribute.buffName == "易：乾命")
                {
                    textGO[2].text = $"{attribute.buffDescription}{PlayerData.Instance.ATK}和{PlayerData.Instance.DEF}";
                }
                else
                {
                    textGO[2].text = attribute.buffDescription;
                }
                m_BuffsGO.Add(attribute.buffName,newBuffGO);
            }
            buff.OnBuffStart();
            // newCard.GetComponent<CardController>().card = card;
        }

        public void Settlement(PlayerOrEnemy playerOrEnemy)
        {
            int damage = 0;
            if (playerOrEnemy == PlayerOrEnemy.Player)
            {
                damage = getDice(DicePhase.EnemyAttack) - getDice(DicePhase.PlayerDefense);
                if (damage > 0)
                {
                    playerHP -= damage;
                }
            }
            else
            {
                damage = getDice(DicePhase.PlayerAttack) - getDice(DicePhase.EnemyDefense);
                if (damage > 0)
                {
                    enemyHP -= damage;
                }

                SettlementBuff();   // only Settlement once
            }
        }

        public void SettlementBuff(String buffName = null)
        {
            if (buffName == null)
            {
                List<string> keysToRemove = new List<string>();
                foreach (KeyValuePair<string, GameObject> pair in m_BuffsGO)
                {
                    BuffInterface buff = pair.Value.GetComponent<BuffController>().card as BuffInterface;
                    buff.OnBuffPerTurn();
                    TMP_Text[] textGO = pair.Value.transform.GetComponentsInChildren<TMP_Text>();
                    textGO[1].text = (int.Parse(textGO[1].text) - 1).ToString();
                    if (int.Parse(textGO[1].text) <= 0)
                    {
                        keysToRemove.Add(pair.Key);
                    }
                }
                for (int i = 0; i < keysToRemove.Count; i++)
                {
                    BuffInterface buff = m_BuffsGO[keysToRemove[i]].GetComponent<BuffController>().card as BuffInterface;
                    buff.OnBuffEnd();
                    Destroy(m_BuffsGO[keysToRemove[i]]);
                    m_BuffsGO.Remove(keysToRemove[i]);
                }
            }
            else
            {
                BuffInterface buff = m_BuffsGO[buffName].GetComponent<BuffController>().card as BuffInterface;
                buff.OnBuffEnd();
                Destroy(m_BuffsGO[buffName]);
                m_BuffsGO.Remove(buffName);
            }
        }
        
    }
}