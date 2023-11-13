using System;
using UnityEngine.EventSystems;
using UnityEngine.UI;


namespace Battle.UIEvents
{
    public class DiceController : Button
    {
        private static Dice k_DiceCup = new Dice(DiceType.D6);
        private static bool k_IsDiceRolling;
        private Text[] m_TextGO;
        
        // public static event Action onDiceStop;
        public static int diceCup { get => k_DiceCup.value; }
        public static bool isInteractable = false;
        public static bool isAIDiceRolling { get; set; }
        

        void Start()
        {
            isAIDiceRolling = false;
            k_IsDiceRolling = false;
            m_TextGO = this.GetComponentsInChildren<Text>();
            m_TextGO[1].text = k_DiceCup.diceType.ToString();
        }

        // private void Update()
        // {
        //     interactable = isInteractable;
        //     if (isAIDiceRolling || isInteractable && k_IsDiceRolling)
        //     {
        //         k_DiceCup.RollDiceOnce();
        //         m_TextGO[0].text = k_DiceCup.value.ToString();
        //     }
        // }
        

        // Button is Pressed
        public override void OnPointerDown(PointerEventData eventData)
        {
            // if (isInteractable)
            // {
            //     base.OnPointerDown(eventData);
            //     k_IsDiceRolling = true;
            // }
        }

        // Button is released
        public override void OnPointerUp(PointerEventData eventData)
        {
            // if (isInteractable)
            // {
            //     base.OnPointerUp(eventData);
            //     k_IsDiceRolling = false;
            //     onDiceStop?.Invoke();
            // }
        }
    }
}