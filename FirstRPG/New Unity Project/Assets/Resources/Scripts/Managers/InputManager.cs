using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager
{
    public bool usingKeyboard=true; //키보드 컨트롤 or 터치 컨트롤 조절
    GameObject _player;
    //bool QuestUIOpen = false;
    UI_Popup QuestUI; // 여기에 퀘스트목록 받아오면됨


    // Update is called once per frame
    public void OnUpdate()
    {
        if (Input.anyKey == false)
            return;
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Esc");
            GameManager.UI.ClosePopupUI();
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            if (!QuestUI.isActiveAndEnabled)// 여기에 다른 ui가 떠잇으면 안되게 조건 추가해야함
                QuestUI.gameObject.SetActive(true);
            else
                QuestUI.gameObject.SetActive(false);
        }
    }
    public void Init()
    {
        QuestUI = GameManager.UI.ShowPopupUI<UI_Popup>("Quest");
        QuestUI.gameObject.SetActive(false);
        //Debug.Log(QuestUI);
    }
}
