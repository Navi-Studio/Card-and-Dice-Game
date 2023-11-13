using BehaviorDesigner.Runtime.Tasks;
using Battle;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;


[TaskCategory("BattleAction")]
[TaskDescription("[功能]: 玩家回合")]
public class PlayTurn : Action
{

	private bool isTurnEnd;
	[SerializeField]private Button m_TurnEndBtn;
	[SerializeField]private Button m_DrawCardBtn;
	
	public override void OnAwake()
	{
		base.OnAwake();
		TurnEndEvent.onPlayerTurnEnd += TurnEnd;
	}

	public override void OnStart()
	{
		m_TurnEndBtn.interactable = true;
		m_DrawCardBtn.interactable = true;
		isTurnEnd = true;
		GameObject.FindGameObjectWithTag("Coin").transform.DORotate(new Vector3(90f, 0f, 0f), 0.5f).SetEase(Ease.Linear);
	}

	private void TurnEnd()
	{
		m_TurnEndBtn.interactable = false;
		m_DrawCardBtn.interactable = false;
		isTurnEnd = false;
	}

	public override TaskStatus OnUpdate()
	{
		return isTurnEnd ? TaskStatus.Running : TaskStatus.Success;
	}
}