using Battle;
using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;


[TaskCategory("BattleConditional")]
[TaskDescription("[判断]: 是否满足打牌条件")]
public class IsMeetConditions : Conditional
{
    public override TaskStatus OnUpdate()
    {
        return (BattleController.Instance.enemyMP > 0 && BattleController.Instance.enemyCardPool.GetKindCount() > 0) ? TaskStatus.Success : TaskStatus.Failure;
    }
}
