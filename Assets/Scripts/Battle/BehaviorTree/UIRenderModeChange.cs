using BehaviorDesigner.Runtime.Tasks;
using Battle;
using Battle.DiceSystem;
using Battle.UIEvents;
using UnityEngine;
using UnityEngine.UI;


[TaskCategory("BattleAction")]
[TaskDescription("[功能]: 骰子回合")]
public class UIRenderModeChange : Action
{
	
	[SerializeField]private Canvas m_Canvas;
	[SerializeField]private RenderMode m_RenderMode;
	


	public override void OnStart()
	{
		m_Canvas.renderMode = m_RenderMode;
	}
	

	public override TaskStatus OnUpdate()
	{

		return TaskStatus.Success;
	}
}