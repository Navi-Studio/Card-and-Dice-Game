namespace Battle.Cards.Player
{
    [BuffAttribute("易：乾命","每回合投掷防御,攻击骰子的结果分别增加",10,PlayerOrEnemy.Player)]
    public class FeaturePlayer : Card, BuffInterface
    {
        public FeaturePlayer(string _Name, string _Description, string _MP) : base("特性", $"每回合投掷防御骰子的结果+{PlayerData.Instance.DEF},攻击骰子的结果++{PlayerData.Instance.ATK}", "0")
        {
        }


        public override Card Clone()
        {
            throw new System.NotImplementedException();
        }

        public override void CalculateCardEffects(EffectiveBlock effectiveBlock)
        {
            throw new System.NotImplementedException();
        }

        public override bool GainJudgment(EffectiveBlock effectiveBlock)
        {
            throw new System.NotImplementedException();
        }

        public void OnBuffStart() { }

        public void OnBuffEnd()
        {
        }

        public void OnBuffPerTurn()
        {
        }

        public void TriggerBuff()
        {
        }
    }
}