using BehaviorDesigner.Runtime.Tasks;
using Battle;
using Battle.UIEvents;
using BehaviorDesigner.Runtime;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


[TaskCategory("BuffAction")]
[TaskDescription("[功能]: GenJiaBuff")]
public class GenJiaBuff : Action
{
    private BattleController m_BattleController;
    private float m_delayTime;

    private int num = 0;
	
    public override void OnAwake()
    {
        base.OnAwake();
        m_BattleController = BattleController.Instance;
    }
    

    public override TaskStatus OnUpdate()
    {
        var genJiaTrigger = (SharedBool)GlobalVariables.Instance.GetVariable("k_GenJiaTrigger");
        if (genJiaTrigger.Value)
        {
            num++;
            if( num >= 2)
            {                
                // FIXME 如果本回合打一张，下回合再打一张也会触发
                num = 0;
                SharedBool value = false;
                GlobalVariables.Instance.SetVariable("k_GenJiaTrigger",value);
                if (m_BattleController.buffsGO.ContainsKey("艮甲"))
                {
                    BuffInterface buff = m_BattleController.buffsGO["艮甲"].GetComponent<BuffController>().card as BuffInterface;
                    buff.TriggerBuff();
                }
            }
        }
        return TaskStatus.Success;
    }
}

