using Battle;
using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;


[TaskCategory("BattleConditional")]
[TaskDescription("[判断]: 是否 当前HP <= 参数阈值\n" +
                    "[返回]: <=返回Failure，>返回Success\n" +
                    "[参数]: healthThreshold HP阈值")]
public class IsHealthUnderParam : Conditional
{

    [SerializeField] private int m_HealthThreshold;
    [SerializeField] private PlayerOrEnemy m_PlayerOrEnemy;

    public override TaskStatus OnUpdate()
    {
        int hp = 0;
        switch (m_PlayerOrEnemy)
        {
            case PlayerOrEnemy.Player : hp = BattleController.Instance.playerHP; break;
            case PlayerOrEnemy.Enemy : hp = BattleController.Instance.enemyHP; break;
        }
        
        if(hp <= m_HealthThreshold){
            return TaskStatus.Failure;
        }
        else{
            return TaskStatus.Success;
        }
	}
}
