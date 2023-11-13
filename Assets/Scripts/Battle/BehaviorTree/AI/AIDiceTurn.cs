using BehaviorDesigner.Runtime.Tasks;
using Battle;
using Battle.DiceSystem;
using Battle.UIEvents;
using UnityEngine;
using UnityEngine.UI;


[TaskCategory("BattleAction")]
[TaskDescription("[功能]: AI 骰子回合")]
public class AIDiceTurn : Action
{
	[SerializeField]private DicePhase m_DicePhase;
	private BattleController m_BattleController;
	private DiceSwipeControl m_DiceSwipeControl;
	private float m_delayTime;
	private bool isDiceStop = false;
	public override void OnAwake()
	{
		base.OnAwake();
		m_BattleController = BattleController.Instance;
		m_DiceSwipeControl = DiceSwipeControl.Instance;
	}

	public override void OnStart()
	{
		m_delayTime = 1f;
		isDiceStop = false;
		// DiceController.isAIDiceRolling = true;
		m_BattleController.setDiceHighLight(m_DicePhase,true);
		
		m_DiceSwipeControl.buttonEvent();
		DiceSwipeControl.onDiceStop += OnDiceStop;
	}

	private void OnDiceStop(int value)
	{
		DiceSwipeControl.onDiceStop -= OnDiceStop;
		// DiceController.isAIDiceRolling = false;
		// m_BattleController.setDice(m_DicePhase,DiceController.diceCup);
		m_BattleController.setDice(m_DicePhase, value);
		m_BattleController.setDiceHighLight(m_DicePhase,false);
		isDiceStop = true;
	}

	public override TaskStatus OnUpdate()
	{
		// m_delayTime -= Time.deltaTime;
		// if(m_delayTime <= 0)
		// {
		// 	OnDiceStop();
		// 	return TaskStatus.Success;
		// }
		// else
		// {
		// 	return TaskStatus.Running;
		// }
		if (isDiceStop)
		{
			isDiceStop = false;
			return TaskStatus.Success;
		}
		else
		{
			return TaskStatus.Running;
		}
		
		
	}
}