using BehaviorDesigner.Runtime.Tasks;
using Battle;



[TaskCategory("BattleAction")]
[TaskDescription("[功能]: 基础攻击防御补正")]
public class BaseValueCorrection : Action
{
    private BattleController m_BattleController;

    public override void OnAwake()
    {
        base.OnAwake();
        m_BattleController = BattleController.Instance;
    }

    public override TaskStatus OnUpdate()
    {
        m_BattleController.setDice(DicePhase.PlayerAttack,m_BattleController.getDice(DicePhase.PlayerAttack)+PlayerData.Instance.ATK);
        m_BattleController.setDice(DicePhase.PlayerDefense,m_BattleController.getDice(DicePhase.PlayerDefense)+PlayerData.Instance.DEF);
        return TaskStatus.Success;
    }
}