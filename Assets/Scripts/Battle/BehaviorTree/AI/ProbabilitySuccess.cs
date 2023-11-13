using Battle;
using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public enum ProbabilitySeed
{
    Decrease,
    DependOnMP
}

[TaskCategory("AIBattleAction")]
[TaskDescription("[判断]: 以 P 的概率返回成功\n" +
                 "[参数]: m_Probability 概率 [0,1]")]
public class ProbabilitySuccess : Action
{
    [SerializeField] private ProbabilitySeed m_Seed;
    [SerializeField] private float m_InitP;
    [SerializeField] private float m_P;
    [SerializeField] private float m_Step;


    public override TaskStatus OnUpdate()
    {
        float random = Random.Range(0f, 1f);
        if (m_Seed == ProbabilitySeed.Decrease)
        {
            if (random <= m_P)
            {
                m_P -= m_Step;
                return TaskStatus.Success;
            }
            else
            {
                // FIXME may not fail when isMeetConditions fail
                m_P = m_InitP;
                return TaskStatus.Failure;
            }
        }
        else if(m_Seed == ProbabilitySeed.DependOnMP)
        {
            int mp = BattleController.Instance.enemyMP;
            int maxMP = BattleController.Instance.maxEnemyMP;
            return (random <= mp/(float)maxMP) ? TaskStatus.Success : TaskStatus.Failure;
        }
        return TaskStatus.Failure;

    }

}
