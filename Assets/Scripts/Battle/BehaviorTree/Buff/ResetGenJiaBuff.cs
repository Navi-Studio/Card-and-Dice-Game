using BehaviorDesigner.Runtime.Tasks;
using Battle;
using Battle.UIEvents;
using BehaviorDesigner.Runtime;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

[TaskCategory("BuffAction")]
[TaskDescription("[功能]: GenJiaBuff")]
public class ResetGenJiaBuff : Action
{
    
    private int num = 0;
    public static event System.Action On;

    public override TaskStatus OnUpdate()
    {
        var genJiaTrigger = (SharedBool)GlobalVariables.Instance.GetVariable("k_GenJiaTrigger");
        if (genJiaTrigger.Value)
        {
            // TODO num 要设置为变量 或者用负数代替 bool 全局判断
            num = 0;
        }
        return TaskStatus.Failure;
    }
}

