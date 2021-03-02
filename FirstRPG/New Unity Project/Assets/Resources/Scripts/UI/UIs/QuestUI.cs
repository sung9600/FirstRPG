using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Define;

public class QuestUI : MonoBehaviour
{
    private void OnEnable()
    {
        Text[] child = this.transform.Find("ScrollView").transform.Find("Viewport").transform.Find("Content").GetComponentsInChildren<Text>();
        foreach(var iter in child)
        {
            //Debug.Log(iter.name);
            Destroy(iter.gameObject);
        }
        Transform parent = this.transform.Find("ScrollView").transform.Find("Viewport").transform.Find("Content");
        foreach ( QuestInfo q in QuestManager.QuestList)
        {
            Text t= GameManager.Resource.Instantiate("UI/Popup/QuestInfo").GetComponent<Text>();
            t.text = $"\t{q.Qname}\n\t{q.Qtext}\n\t{q.currentnum} / {q.Targetnum}\n\tReward: Coin x {q.reward}".Replace("\\n", "\n\t");
            t.transform.SetParent(parent);
        }
    }
}
