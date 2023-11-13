using BehaviorDesigner.Runtime.Tasks;
using Battle;


[TaskCategory("BattleAction")]
[TaskDescription("[功能]: 回合开始")]
public class TurnStart : Action
{
	private BattleController m_BattleController;


	public override void OnAwake()
	{
		base.OnAwake();
		m_BattleController = BattleController.Instance;
	}

	public override void OnStart()
	{
		m_BattleController.TurnStart();
	}

	public override TaskStatus OnUpdate()
	{
		return TaskStatus.Success;
	}
}