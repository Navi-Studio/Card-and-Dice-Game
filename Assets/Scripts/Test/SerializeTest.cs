using System.Collections.Generic;
using UnityEngine;

namespace Test
{
    public class SerializeTest : MonoBehaviour
    {
        public void TestSerializeCard()
        {
            // Card card1 = new CommonCard("card1", "这是一个Common", "-1","Add", "9");
            // Card card2 = new TestCard("card2", "这是一个Common","1");
            // Card card3 = new CommonCard("card3", "这是一个Common", "3","Add", "-3");
            // Dictionary<Card, int> d1 = new Dictionary<Card, int>();
            // d1.Add(card1,1);
            // d1.Add(card2,3);
            // CardPool cardPool = new CardPool(d1);
            // Dictionary<string, CardPool> d2 = new Dictionary<string, CardPool>();
            // d2.Add("boss",cardPool);
            // d2.Add("player",cardPool);
            //
            // CardLibrary cardLibrary = CardLibrary.Instance;
            // cardLibrary.setDictionary(d2);
            // cardLibrary.SerializeCardLibrary();
        }
        
        public void TestDeserializeCard()
        {
            CardLibrary cardLibrary = CardLibrary.Instance;
            cardLibrary.DeserializeCardLibrary();
            // cardLibrary.SerializeCardLibrary();
        }
    }
}