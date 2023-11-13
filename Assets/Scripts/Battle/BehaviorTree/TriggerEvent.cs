using BehaviorDesigner.Runtime.Tasks;
using Battle;
using UnityEngine;


[TaskCategory("AIBattleAction")]
[TaskDescription("[功能]: 触发事件")]
public class TriggerEvent : Action
{
	private BattleController m_BattleController;
	[SerializeField] private BattleController.BattlePhaseEvents m_BattlePhaseEvents;


	public override void OnAwake()
	{
		base.OnAwake();
		m_BattleController = BattleController.Instance;
	}
	
	
	public override TaskStatus OnUpdate()
	{
		// m_BattleController.TriggerEvents(m_BattlePhaseEvents);
		return TaskStatus.Success;
	}
}