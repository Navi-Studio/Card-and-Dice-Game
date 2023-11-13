using System;
using System.Collections;
using System.Collections.Generic;
using BehaviorDesigner.Runtime.Tasks;
using Battle;
using Battle.DiceSystem;
using Battle.UIEvents;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Action = BehaviorDesigner.Runtime.Tasks.Action;


[TaskCategory("BattleAction")]
[TaskDescription("[功能]: Dialog")]
public class Dialog : Action
{
	[SerializeField] private GameObject m_PlayerBubbleGO;
	[SerializeField] private GameObject m_EnemyBubbleGO;
	private BattleController m_BattleController;
	private Dictionary<string, List<Tuple<int, string>>> m_DialogDic = new Dictionary<string, List<Tuple<int, string>>>();
	private List<Tuple<bool, string>> m_DialogList = new List<Tuple<bool, string>>();
	private bool isDialogEnd = false;

	public override void OnAwake()
	{
		base.OnAwake();
		m_BattleController = BattleController.Instance;
		InitDialog();
	}

	public override void OnStart()
	{
		isDialogEnd = false;
		GetDialogList();
		StartCoroutine(PlayDialog());
	}
	
	private IEnumerator PlayDialog()
	{
		yield return new WaitForSeconds(2f);
		foreach (var tuple in m_DialogList)
		{
			GameObject bubbleGO = tuple.Item1 ? m_PlayerBubbleGO : m_EnemyBubbleGO;
			bubbleGO.SetActive(true);
			bubbleGO.GetComponentInChildren<TMP_Text>().text = "";
			float waitTime = 2f + tuple.Item2.Length/10;
			bubbleGO.GetComponentInChildren<TMP_Text>().DOText(tuple.Item2, waitTime-1f).OnComplete(() => { });
			yield return new WaitForSeconds(waitTime);
			bubbleGO.SetActive(false);
		}
		isDialogEnd = true;
	}

	public override TaskStatus OnUpdate()
	{
		if (isDialogEnd)
		{
			return TaskStatus.Success;
		}
		return TaskStatus.Running;
	}

	private void InitDialog()
	{
		List<Tuple<int, string>> YaoGuaiList = new List<Tuple<int, string>>();
		YaoGuaiList.Add(new Tuple<int, string>(10,"（似乎红色的点数代表攻击。）"));
		YaoGuaiList.Add(new Tuple<int, string>(10,"（那么蓝色的点数代表就防御。）"));
		YaoGuaiList.Add(new Tuple<int, string>(10,"（还有这卡牌？嗯....）"));
		YaoGuaiList.Add(new Tuple<int, string>(10,"（没准能派上大用场。）"));
		YaoGuaiList.Add(new Tuple<int, string>(20,"（原来只要让攻击值大于防御值，就可以给对方造成伤害啊。）"));
		YaoGuaiList.Add(new Tuple<int, string>(20,"（但是攻击值如果不够，就没法造成伤害了。）"));
		YaoGuaiList.Add(new Tuple<int, string>(30,"（每张卡牌都有自己的能量，能量不足就打不出去。）"));
		YaoGuaiList.Add(new Tuple<int, string>(30,"（那么只要我有足够多的绿色能量，就可以大干一场了。）"));
		m_DialogDic.Add("妖怪",YaoGuaiList);
		
		List<Tuple<int, string>> GuiMaList = new List<Tuple<int, string>>();
		GuiMaList.Add(new Tuple<int, string>(10,"你是义净大师的随从？"));
		GuiMaList.Add(new Tuple<int, string>(11,"监天司，走狗的味道。你没有办法阻挡佛，我会为真佛扫除一切尘障。"));
		GuiMaList.Add(new Tuple<int, string>(10,"铜穗伏子，见到银牌刑提武士，还不速速下跪？"));
		GuiMaList.Add(new Tuple<int, string>(11,"樱花木流心一剑道，这是四国的剑，唐人的命，我可不听。"));
		GuiMaList.Add(new Tuple<int, string>(10,"勿谓言之不预也。"));
		GuiMaList.Add(new Tuple<int, string>(21,"我已经成佛啦，没人再是我的对手，刑提武士也不行。"));
		GuiMaList.Add(new Tuple<int, string>(20,"人不人，诡不诡，你和义净当初到底遭遇了什么？"));
		GuiMaList.Add(new Tuple<int, string>(21,"我只是接受了真佛的信仰，至于义净，佛对他的宠爱更多，只可惜，他命缘浅薄。"));
		GuiMaList.Add(new Tuple<int, string>(20,"那便去见你的真佛吧！"));
		m_DialogDic.Add("鬼马龙一",GuiMaList);
		
		List<Tuple<int, string>> GuanYinList = new List<Tuple<int, string>>();
		GuanYinList.Add(new Tuple<int, string>(10,"你究竟是什么东西？"));
		GuanYinList.Add(new Tuple<int, string>(11,"阿弥，施主着相了，人生人相，畜生畜相，我生我相，相貌如何，由心不由己。"));
		GuanYinList.Add(new Tuple<int, string>(10,"你和义净见过面？祂究竟是什么？"));
		GuanYinList.Add(new Tuple<int, string>(11,"（宝相庄严）义净是痴顽，竟然妄图堪破无上密，下场也是自寻因果。"));
		GuanYinList.Add(new Tuple<int, string>(10,"无上密是什么？"));
		GuanYinList.Add(new Tuple<int, string>(11,"无上密既是无上密，既使我告诉施主，施主也不会晓得的。"));
		GuanYinList.Add(new Tuple<int, string>(10,"既然如此，那便得罪大师了！"));
		GuanYinList.Add(new Tuple<int, string>(20,"种因得果，善因得善果，恶因得恶果，普慈在此杀人无数，也是在渡人嘛？"));
		GuanYinList.Add(new Tuple<int, string>(21,"我因种他果，他因种我果，善因化为善果报，恶因化为恶果报，施主如何知道，我施加的善因，报在他人身上又何尝不是恶果？"));
		GuanYinList.Add(new Tuple<int, string>(20,"这么说，大师杀了他们反倒是在帮他们？"));
		GuanYinList.Add(new Tuple<int, string>(21,"莫要被眼前的迷障遮蔽，当你发现真实相，一切都会不同……"));
		GuanYinList.Add(new Tuple<int, string>(20,"多言无益，且做过一场罢。"));
		GuanYinList.Add(new Tuple<int, string>(21,"痴儿！"));
		GuanYinList.Add(new Tuple<int, string>(30,"怎么回事，发生什么了。"));
		GuanYinList.Add(new Tuple<int, string>(31,"啊啊啊啊啊啊啊啊！！！！！"));
		m_DialogDic.Add("窄袖观音",GuanYinList);
		
		List<Tuple<int, string>> DaTanList = new List<Tuple<int, string>>();
		DaTanList.Add(new Tuple<int, string>(10,"你，你究竟是什么？"));
		DaTanList.Add(new Tuple<int, string>(11,"（无声）……"));
		DaTanList.Add(new Tuple<int, string>(10,"我懂了。(颂念经文)"));
		DaTanList.Add(new Tuple<int, string>(10,"原来，是如此……"));
		DaTanList.Add(new Tuple<int, string>(11,"（无声）……"));
		DaTanList.Add(new Tuple<int, string>(10,"不，我不会这样。"));
		DaTanList.Add(new Tuple<int, string>(10,"只是枯燥的、麻木的、死亡的、一切嘛……"));
		DaTanList.Add(new Tuple<int, string>(10,"也许你是对的，但，对不起……"));
		DaTanList.Add(new Tuple<int, string>(10,"我将杀死你，那么，来接招吧！"));
		m_DialogDic.Add("大傩",DaTanList);
	}

	private void GetDialogList()
	{
		m_DialogList = new List<Tuple<bool, string>>();
		List<Tuple<int, string>> tempList = m_DialogDic[m_BattleController.enemyName];
		foreach (var tuple in tempList)
		{
			if (tuple.Item1 / 10 == m_BattleController.roundNumber)
			{
				bool player = tuple.Item1 % 10 == 0;
				m_DialogList.Add(new Tuple<bool, string>(player,tuple.Item2));
			}
		}
	}
}