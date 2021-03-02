using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestAcceptButton : MonoBehaviour
{
    // Start is called before the first frame update
    public void BackToMain()
    {
        GameObject.Find("QuestCollider").SetActive(false);
        GameObject.Find("Character").transform.Find("Player").gameObject.SetActive(true);
        CameraManager.Instance.CamChange(0);
        transform.parent.gameObject.SetActive(false);
        QuestManager.QuestList.Add(transform.parent.GetComponent<ForQuestTransfer>().questinfo);
    }
}
