using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Map;

public class LogPanel : MonoBehaviour
{
    private static Dictionary<string, string> enumMap = new Dictionary<string, string>()
    {
        { "Entry1", "鬼马龙一的手札: \n\t我，已经为大唐卖过命了，东瀛四国道的名下武士，监天司铜穗伏子，我的一生都是别人的棋子，为了长岛大名潜入大唐，又作为监天司的伏子藏入西域，东瀛不以我为乡子，大唐不以我为亲胡，这里离我的故乡足有万里之遥，我本来已经做好了客死他乡，无名无姓的一生的准备。直到，我真的见到了真佛！玄奘带回来的经书相比于义净携带的真经根本不值一提，是了，佛，如果不能满足宏愿，不能展现神异，还叫佛嘛？真佛，愿吾为您扫清尘障。" },
        { "Entry2", "义净的帛书: \n\t我错了，我被欺骗了，假的，假的，都是假的，根本没有什么所谓的佛，也没有什么所谓的真经，雪域大西天的阿弥行者是大智慧的，我早该听闻祂的劝告。我是罪人，我亲手将这一切带回到大唐，不，不，我还可以弥补，只要我死了，祂就会永远的被埋藏在无上密之地，被密言忘记，佛祖阿弥，望弟子的禅机悟的还不算晚。" },
        { "Entry3", "密刹陀罗帝的无上密言: \n\t西天湿婆摩，有一群自称“密刹陀罗帝”的禅宗行者，他们修“炼假成真”之密言，流传着一个关于无可知之无上密行者的传言，即“傩”或称“大傩”。传闻，只要禅心坚定，修持得道，便能凭借此密言，心想事成，炼假成真，成就阿弥无上妙菩萨法身。相传，雪域大西天的阿弥行者，便是为义净所携带的“傩”的《阿弥云上枇玉经》所污染，滞留于千尘古道，以慈悲相度化缘人，以贪嗔相吞噬往者。" },
        { "Entry4", "摩勀无量玄经: \n\t莫奤莫勀，量生物莲，巨化成驱……记载着不知名天竺文字的量经，不知为何被窄袖观音携带，不过，你似乎在义净的手札中看到过关于他的记载，只要带着他，在一定的时刻念诵经文，就能透过无声量莫勀界，和祂对视。就算你未曾演戏过佛法，也能知道，祂的存在，不仅仅只是愚人的佛偶，而是真正的，邪恶的佛，又或者，傩！" },
        { "Entry5", "司命的星弥: \n\t你胜了。这是凡人的胜利，一个无知的凡俗用傩的力量杀死了傩，这似乎值得炫耀，但是又不值得炫耀，你的力量消失了，但司命的力量却一直存在，也许傩将自己分为了许多份的司命，又也许司命有着自己的力量来源，你都不在乎，重要的是，随着傩的消失，司命已然悄无声息的嵌入到大唐的各个角落，也许你未来的路途会更加坎坷，又或者更加轻松？谁知道呢？" }
    };

    private static Dictionary<string, int> numMap = new Dictionary<string, int>()
    {
        {"Entry1", 0 },    
        {"Entry2", 2 },    
        {"Entry3", 2 },    
        {"Entry4", 4 },    
        {"Entry5", 4 }   
    };

    private static Dictionary<string, string> realNameMap = new Dictionary<string, string>()
    {
        {"Entry1", "手札" },
        {"Entry2", "帛书" },
        {"Entry3", "密言" },
        {"Entry4", "玄经" },
        {"Entry5", "星弥" }
    };

    public GameObject contextPanel;
    public GameObject tracker;
    public MapManager mapManager;
    private string detail;
    private string realName;
    private int logNum;

    private int currentPath;
    // Start is called before the first frame update
    void Start()
    {
        GameObject currentGameObject = gameObject;
        string akey = gameObject.name.ToString();
        enumMap.TryGetValue(akey, out detail);
        realNameMap.TryGetValue(akey, out realName);
        numMap.TryGetValue(akey, out logNum);

        gameObject.GetComponentInChildren<TMP_Text>().text = "*****";
        //MapPlayerTracker trackerScp = tracker.GetComponent<MapPlayerTracker>();
        //logNum = trackerScp.logNums;
    }

    // Update is called once per frame
    void Update()
    {
        //MapPlayerTracker trackerScp = tracker.GetComponent<MapPlayerTracker>();
        if (mapManager.CurrentMap.path.Count > 0)
        {
            currentPath = mapManager.CurrentMap.path[mapManager.CurrentMap.path.Count - 1].y;
            if (logNum <= currentPath)
            {
                gameObject.GetComponentInChildren<TMP_Text>().text = realName;
            }
        }

    }

    public void UpdateContext()
    {
        //MapPlayerTracker trackerScp = tracker.GetComponent<MapPlayerTracker>();
        //Debug.Log(trackerScp.mapManager.CurrentMap.path.Count);
        //int path = trackerScp.mapManager.CurrentMap.path[trackerScp.mapManager.CurrentMap.path.Count - 1].y;


        if (contextPanel != null)
        {
            if (logNum <= currentPath)
            {
                contextPanel.GetComponentInChildren<TMP_Text>().text = detail;
            }

        }
    }
}
