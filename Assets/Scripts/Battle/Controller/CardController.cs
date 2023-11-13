using Battle;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public enum CardOwner
{
    PlayerHands,
    CardBlock,
    CardPool,
    DropPool
}

public class CardController : MonoBehaviour, IDragHandler, IEndDragHandler
{
    private Card m_Card;
    private TMP_Text m_CardName;
    private GameObject m_CardMP;
    private TMP_Text m_CardDescription;
    private Image m_Background;
    private GameObject m_BackGO;
    private RectTransform m_RectTransform;
    private Vector3 m_InitPosition;
    private CardOwner m_CardOwner;
    private Transform m_Hands;
    private GameObject[] m_CardBlocks;
    

    public Card card { get => m_Card; set => m_Card = value; }
    public CardOwner cardOwner { set => m_CardOwner = value; }
    public bool isDraging { get; set; }
    
    public bool isBack { get; set; }

    private void Awake()
    {
        isDraging = false;
        isBack = false;
        Transform parentTransform = transform.Find("Tips");
        m_CardName = parentTransform.Find("Name").gameObject.GetComponent<TMP_Text>();
        m_CardMP = parentTransform.Find("MPGroup").gameObject;
        m_CardDescription = parentTransform.Find("Description").gameObject.GetComponent<TMP_Text>();
        m_BackGO = transform.Find("Back").gameObject;
        m_RectTransform = GetComponent<RectTransform>();
        m_Hands = transform.parent.parent.Find("Hands");
        m_CardBlocks = BattleController.Instance.cardBlocks;
    }

    void Start()
    {
        if (m_Card != null)
        {
            if (isBack)
            {
                ShowBack();
            }
            else
            {
                ShowCard();
            }
        }
    }
    
    public void ShowCard()
    {
        m_BackGO.SetActive(false);
        m_CardName.text = m_Card.name;
        m_CardDescription.text = m_Card.description;
        int mp = m_Card.mp;
        Transform mpGroupTransform = m_CardMP.transform;
        for (int i = 0; i < mpGroupTransform.childCount; i++)
        {
            mpGroupTransform.GetChild(i).gameObject.SetActive(i < mp);
        }
        // TODO set background
    }

    public void ShowBack()
    {
        m_BackGO.SetActive(true);
    }
    

    public void OnDrag(PointerEventData eventData)
    {
        if (BattleController.Instance.battlePhase == BattlePhase.PlayerTurn)
        {
            if (m_CardOwner == CardOwner.PlayerHands)
            {
                isDraging = true;
                transform.Find("Tips").gameObject.SetActive(false);
                transform.parent = m_Hands.transform.parent.transform;
                BattleController.Instance.ControlBlockHighLight(m_Card,true);
                
                if (RectTransformUtility.ScreenPointToWorldPointInRectangle(m_RectTransform, eventData.position,
                        eventData.pressEventCamera, out Vector3 MousePosition))
                // if (RectTransformUtility.ScreenPointToLocalPointInRectangle(m_RectTransform, eventData.position,
                //         eventData.pressEventCamera, out Vector2 MousePosition))
                {
                    // Drag range limit
                    Vector2 cardVector2 = new Vector2(150/2,200/2);
                    MousePosition.x = Mathf.Clamp(MousePosition.x, cardVector2.x, Screen.width - cardVector2.x);
                    MousePosition.y = Mathf.Clamp(MousePosition.y, cardVector2.y, Screen.height - cardVector2.y);
                    // MousePosition.z = 0;
                    transform.position = MousePosition;
                }
            }
        }
    }


    public void OnEndDrag(PointerEventData eventData)
    {
        isDraging = false;
        if (BattleController.Instance.battlePhase == BattlePhase.PlayerTurn && m_CardOwner == CardOwner.PlayerHands)
        {
            transform.Find("Tips").gameObject.SetActive(false);
            BattleController.Instance.ControlBlockHighLight(m_Card,false);
            float x = transform.position.x;
            float y = transform.position.y;
            for (int i = 0; i < m_Card.effectiveBlocks.Count; i++)
            {
                Transform cardBlock = m_CardBlocks[(int)m_Card.effectiveBlocks[i]].transform;
                if (m_Card.effectiveBlocks[i] == EffectiveBlock.Player || m_Card.effectiveBlocks[i] == EffectiveBlock.Enemy)
                {
                    cardBlock = cardBlock.parent;
                }
                if (cardBlock.position.x - 75 < x && x < cardBlock.position.x + 75 
                                                  && cardBlock.position.y - 100 < y && y < cardBlock.position.y + 100)
                {
                    if (BattleController.Instance.PlayCard(transform.gameObject,m_Card.effectiveBlocks[i]))
                    {
                        return;
                    }
                    else
                    {
                        // Insufficient MP 
                        break;
                    }
                }
            }
        
            transform.SetParent(m_Hands);
        }
    }
    
}
