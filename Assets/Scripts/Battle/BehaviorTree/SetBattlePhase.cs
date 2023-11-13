using BehaviorDesigner.Runtime.Tasks;
using Battle;
using UnityEngine;


[TaskCategory("BattleAction")]
public class SetBattlePhase : Action
{
	[SerializeField] private BattlePhase m_BattlePhase;
	
	public override TaskStatus OnUpdate()
	{
		BattleController.Instance.battlePhase = m_BattlePhase;
		return TaskStatus.Success;
	}
}