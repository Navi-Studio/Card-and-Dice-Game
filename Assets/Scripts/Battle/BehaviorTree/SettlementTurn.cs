using System;
using BehaviorDesigner.Runtime.Tasks;
using Battle;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using Action = BehaviorDesigner.Runtime.Tasks.Action;


[TaskCategory("BattleAction")]
[TaskDescription("[功能]: 结算回合")]
public class SettlementTurn : Action
{
	[SerializeField] private GameObject m_PlayerShake;
	[SerializeField] private GameObject m_EnemyShake;
	private bool isEnd = false;
	private BattleController m_BattleController;

	public override void OnStart()
	{
		base.OnStart();
		m_BattleController = BattleController.Instance;
		isEnd = false;
		Settlement();
	}

	private void Settlement()
	{
		float playerPercent = m_BattleController.getStrengthSlider(m_BattleController.getDice(DicePhase.PlayerAttack), m_BattleController.getDice(DicePhase.EnemyDefense));
		float enemyPercent = m_BattleController.getStrengthSlider(m_BattleController.getDice(DicePhase.EnemyAttack), m_BattleController.getDice(DicePhase.PlayerDefense));
		
		playerPercent = playerPercent > 0.5f ? 1f : 0.5f;
		DOTween.To(() => m_BattleController.m_PlayerSliderGO.value, x => m_BattleController.m_PlayerSliderGO.value = x, playerPercent, 0.3f)
			.SetEase(Ease.Linear).OnComplete(() =>
			{
				BattleController.Instance.Settlement(PlayerOrEnemy.Player);
				if (Mathf.Approximately(playerPercent, 1f))
				{
					m_EnemyShake.transform.DOShakePosition(1f,0.3f).SetDelay(0.5f);
				}
				isEnd = true; 
			});
		enemyPercent = enemyPercent > 0.5f ? 1f : 0.5f;
		DOTween.To(() => m_BattleController.m_EnemySliderGO.value, x => m_BattleController.m_EnemySliderGO.value = x,enemyPercent , 0.3f)
			.SetEase(Ease.Linear).OnComplete(() =>
			{
				BattleController.Instance.Settlement(PlayerOrEnemy.Enemy);
				if (Mathf.Approximately(enemyPercent, 1f))
				{
					m_PlayerShake.transform.DOShakePosition(1f,0.3f).SetDelay(0.5f);
				}
				isEnd = true; 
			});
		
	}

	public override TaskStatus OnUpdate()
	{
		if (isEnd)
		{
			return TaskStatus.Success;
		}

		return TaskStatus.Running;
	}
}