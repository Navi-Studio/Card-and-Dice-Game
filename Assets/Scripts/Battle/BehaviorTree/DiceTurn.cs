using BehaviorDesigner.Runtime.Tasks;
using Battle;
using Battle.DiceSystem;
using Battle.UIEvents;
using UnityEngine;
using UnityEngine.UI;


[TaskCategory("BattleAction")]
[TaskDescription("[功能]: 骰子回合")]
public class DiceTurn : Action
{
	[SerializeField]private DicePhase m_DicePhase;
	private bool isTurnEnd;
	private BattleController m_BattleController;
	
	public override void OnAwake()
	{
		base.OnAwake();
		m_BattleController = BattleController.Instance;
	}

	public override void OnStart()
	{
		isTurnEnd = false;
		// DiceController.onDiceStop += OnDiceStop;
		DiceSwipeControl.onDiceStop += OnDiceStop;
		// DiceController.isInteractable = true;
		DiceSwipeControl.isInteractable = true;
		m_BattleController.setDiceHighLight(m_DicePhase,true);
	}

	private void OnDiceStop(int value)
	{
		// DiceController.onDiceStop -= OnDiceStop;
		DiceSwipeControl.onDiceStop -= OnDiceStop;
		// DiceController.isInteractable = false;
		
		// m_BattleController.setDice(m_DicePhase,DiceController.diceCup);
		m_BattleController.setDice(m_DicePhase,value);
		m_BattleController.setDiceHighLight(m_DicePhase,false);
		isTurnEnd = true;
	}

	public override TaskStatus OnUpdate()
	{
		if (isTurnEnd)
		{
			return TaskStatus.Success;
		}
		else
		{
			return TaskStatus.Running;
		}
	}
}