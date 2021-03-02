using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Define;

public class QuestCube : Cube
{
    private void Awake()
    {
        camnum = 1;
    }
    public override void ShowUI()
    {
        // 2. UI 켜기
        ArrayList qinfo = XmlReader.ReadByTag("Quest.xml", "Quest", "Main1");
        UI_Popup questUI = GameManager.UI.ShowPopupUI<UI_Popup>("MainQuest");
        QuestInfo qinfotoStrucct = new QuestInfo();
        qinfotoStrucct.Qname = (string)qinfo[0];
        qinfotoStrucct.Qtext = (string)qinfo[1];
        qinfotoStrucct.Tag = (string)qinfo[2];
        qinfotoStrucct.Targetnum = int.Parse((string)qinfo[3]);
        qinfotoStrucct.currentnum = (int)qinfo[6];
        qinfotoStrucct.completed = bool.Parse((string)qinfo[5]);
        qinfotoStrucct.reward = int.Parse((string)qinfo[4]);

        questUI.GetComponent<ForQuestTransfer>().questinfo = qinfotoStrucct;
        questUI.transform.Find("QuestName").gameObject.GetComponent<Text>().text = $"{qinfo[0].ToString()}";
        questUI.transform.Find("QuestContext").gameObject.GetComponent<Text>().text = $"{qinfo[1].ToString().Replace("\\n", "\n")}";
    }
}

